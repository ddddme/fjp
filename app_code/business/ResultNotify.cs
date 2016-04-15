using System;
using System.Web.UI;
using App.FunctionLibrary;
using System.Data;
using yangNetCl;
using _D = yangNetCl.Cl_DataMag;
using System.Collections.Generic;
using mySocketClient;

namespace FlowRecharge.Wechat
{
    /// <summary>
    /// 支付结果通知回调处理类
    /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
    /// </summary>
    public class ResultNotify : Notify
    {
        static readonly object locker = new object();
        public ResultNotify(Page page) : base(page) { }
        private enum en_OrderStatus
        {
            未检查,
            正常,
            订单无,
            已处理,
            无此产品,
            金额不对
        }

        public override void ProcessNotify()
        {
            var notifyData = GetNotifyData();

            #region 验证微信回调的参数
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                var res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");

                Log.WriteLog("支付回调：订单查询失败 : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            //微信订单号
            var transaction_id = notifyData.GetValue("transaction_id").ToString();
            //预支付订单号
            var pbOrderID = notifyData.GetValue("out_trade_no").ToString();
            //支付金额
            decimal amountWxback = notifyData.GetValue("total_fee").CDec();
            Log.WriteLog("支付回调：微信订单号：" + transaction_id + "预支付订单号：" + pbOrderID + "支付金额：" + amountWxback);
            //判断预支付订单号是否为空
            if (pbOrderID == "")
            {
                var result = Refund.Run(transaction_id, "", amountWxback, amountWxback);
                var res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中商户订单号不存在");
                page.Response.Write(res.ToXml());
                page.Response.End();
                return;
            }
            //设置数据库连接
            Log.WriteLog("数据库连接：" + _D.ConnStr);
            en_OrderStatus orderStatus = en_OrderStatus.未检查;
            try
            {
                lock (locker)
                {
                    string sql = "select * from tb_order where tb_order_BatchID='" + pbOrderID + "'";
                    Log.WriteLog("根据预支付订单获取订单：" + sql);
                    DataTable dt = sql.YanGetDb();
                    if (dt.Rows.Count != 1)
                    {
                        orderStatus = en_OrderStatus.订单无;
                        throw new Exception("没有检查到订单,或多重订单！");
                    }
                    if (dt.YanDtValue2("tb_order_TransID") != "")
                    {
                        orderStatus = en_OrderStatus.已处理;
                        throw new Exception("订单已处理！");
                    }
                    if (dt.YanDtValue2("tb_order_Status") != "未支付")
                    {
                        orderStatus = en_OrderStatus.已处理;
                        throw new Exception("订单已处理！");
                    }
                    //验证产品与金额是否相符
                    //List<PriceItem> ltPrice = FlowRechargeService.Get_Prices();
                    //List<PriceItem> tLttm = ltPrice.FindAll(x => x.MerchandiseID == dt.YanDtValue2("tb_order_MerchandiseID"));
                    //if (tLttm.Count != 1)
                    //{
                    //    orderStatus = en_OrderStatus.无此产品;
                    //    throw new WxPayException("下订单出错,不存在的产品");
                    //}
                    //decimal tFee = tLttm[0].Price;
                    ////数据库中读取的订单金额要等于产品金额，微信订单的金额要等于产品金额*100
                    //if (dt.YanDtValue2("tb_order_Amount").CDec() != tFee || amountWxback != tFee * 100)
                    //{
                    //    orderStatus = en_OrderStatus.金额不对;
                    //    throw new WxPayException("下订单出错,订单金额错误！");
                    //}

                    sql = "update tb_order set tb_order_TransID='" + transaction_id + "' where tb_order_ID='" + dt.YanDtValue2("tb_order_ID") + "'";
                    Log.WriteLog("更新微信订单号：" + sql);
                    sql.YanDbExe();
                    //更新订单
                    orderStatus = en_OrderStatus.正常;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("支付回调：" + ex.Message);
            }
            WxPayData resErr;
            switch (orderStatus)
            {
            case en_OrderStatus.已处理:
                //已处理的情况只会给微信发送回执，并不会退款，
                resErr = new WxPayData();
                resErr.SetValue("return_code", "FAIL");
                resErr.SetValue("return_msg", "此订单已处理！");
                page.Response.Write(resErr.ToXml());
                page.Response.End();
                return;
            case en_OrderStatus.正常:
                //只有在正常的情况下才会继续运行程序
                break;
            default:
                var result = Refund.Run(transaction_id, "", amountWxback, amountWxback);
                resErr = new WxPayData();
                resErr.SetValue("return_code", "FAIL");
                resErr.SetValue("return_msg", "商户订单号不存在！");
                page.Response.Write(resErr.ToXml());
                page.Response.End();
                return;
            }
            #endregion

            //为安全起见，这里要在查询一次微信订单
            WxPayData wxOrderRes;
            if (pubdim.QueryOrder(transaction_id, out wxOrderRes))
            {
                var res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");

                #region 查询订单成功
                var amount = wxOrderRes.GetValue("total_fee").CDec();
                bool isSubmitRecharge = false;
                try
                {
                    #region 调用购票接口,同时更新支付状态
                    string sql = @" select * 
                                    from tb_order as a left join  
                                    where tb_order_BatchID='" + pbOrderID + "' and tb_order_TransID='" + transaction_id + "'";
                    Log.WriteLog("根据预商户订单和微信订单获取订单：" + sql);
                    DataTable dt = sql.YanGetDb();                    
                    if (dt.Rows.Count != 1)
                    {
                        throw new Exception("商户订单号 {0} 未发现,或有多重订单！".Formatting(pbOrderID));
                    }
                    //锁票                  
                    //LockTicket lockTicket = new LockTicket(new SocketClient(), pbOrderID, dt.YanDtValue2("tb_order_cc"), 1, "", "", "");
                    //mySocketClient. LockTicket lockTicket = new LockTicket();
                    string orderId = "";
                    isSubmitRecharge = true;
                    sql = @"update  tb_order 
                                set tb_order_BatchID='" + orderId + @"',
                                    tb_order_Status='支付成功',
                                    tb_order_payStatus='支付成功',
                            where tb_order_ID='" + dt.YanDtValue2("tb_order_ID") + "'";
                    Log.WriteLog("提交充值成功更新状态：" + sql);
                    sql.YanDbExe();
                    //throw new Exception("抛出错误测试提交充值成功的情况");
                    #endregion
                }
                catch (Exception ex)
                {
                    #region 手机充值异常，做微信支付退款操作
                    Log.WriteLog("支付回调-提交充值失败:" + ex.Messages());
                    if (isSubmitRecharge == false)
                    {
                        //提交充值时发生了错误，需要退费
                        WxPayData result = Refund.Run(transaction_id, "", amount, amount);
                        Log.WriteLog("支付回调：退款返回结果！" + result.ToPrintStr());
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic["tb_order_Status"] = "充值失败，已提交退款";
                        dic["tb_order_refundStatus"] = result.GetValue("result_code").CStr().EqualsIgnoreCase("SUCCESS") ? "成功" : "失败";
                        dic["tb_order_refundid"] = result.GetValue("refund_id").CStr();
                        dic["tb_order_refundTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string sql = _D.getUpdateStr("tb_order", dic, "tb_order_pbOrderID='" + pbOrderID + "' and tb_order_TransID='" + transaction_id + "'");
                        Log.WriteLog("更新提交退款：" + sql);
                        sql.YanDbExe();
                    }
                    if (isSubmitRecharge)
                    {
                        //表示已经成功提交了充值申请，这时不能退费了
                        string sql = "update tb_order set tb_order_Status='提交充值成功' where tb_order_pbOrderID='" + pbOrderID + "' and tb_order_TransID='" + transaction_id + "'";
                        Log.WriteLog("支付成功，提交充值成功，后续发生错误：" + sql);
                        sql.YanDbExe();
                    }
                    #endregion
                }

                page.Response.Write(res.ToXml());
                page.Response.End();
                #endregion
            }
            else
            {
                #region 查询订单，判断订单真实性,若订单查询失败，则立即返回结果给微信支付后台
                var res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                Log.WriteLog("支付回调：订单查询失败 : " + res.ToXml());

                //支付失败也要记录
                string sql = "update tb_order set tb_order_Status='支付失败' where tb_order_pbOrderID='" + pbOrderID + "' and tb_order_TransID='" + transaction_id + "'";
                Log.WriteLog("更新提交充值失败：" + sql);
                sql.YanDbExe();

                page.Response.Write(res.ToXml());
                page.Response.End();
                #endregion
            }
        }
    }
}