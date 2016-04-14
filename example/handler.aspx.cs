using System;
using System.Collections.Generic;
using FlowRecharge.Wechat;
using System.Net;
using App.FunctionLibrary;
using yangNetCl;
using System.Threading;

public partial class example_handler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            switch ((mo_myKz.en_clFun)Request["clFun"].CInt())
            {
                case mo_myKz.en_clFun.获取到达站:
                    GetStation();
                    break;
                case mo_myKz.en_clFun.获取票列表:
                    GetTickList();
                    break;
                case mo_myKz.en_clFun.获取订单列表:
                    Response.Write("[]");
                    break;
                case mo_myKz.en_clFun.获取微信JS配置签名:
                    getSignInfo();
                    break;
                case mo_myKz.en_clFun.统一下单:
                    getPayParam();
                    break;
            }
        }
        catch { }
        finally
        {
            Response.End();
        }
    }
    /// <summary>
    /// 获取到达站
    /// </summary>
    private void GetStation()
    {
        try
        {
            SocketTestClient cilent = new SocketTestClient();
            GetStation getStation = new GetStation(cilent);
            List<Station> stations = getStation.getStation();
            if (stations == null)
            {
                Response.Write(new { success = false, msg = "查询站点失败" }.ToJSONString());
                return;
            }
            Response.Write(new { success = true,value= stations.ToJSONString() }.ToJSONString());
        }
        catch (Exception ex)
        {
            Response.Write(new { success = false, msg = ex.Message }.ToJSONString());
            Log.WriteLog(ex.Message);
        }
    }
    /// <summary>
    /// 获取票列表
    /// </summary>
    private void GetTickList()
    {
        //Thread.Sleep(3000);
        try
        {
            FindCheCis findTicket = new FindCheCis(new SocketTestClient(), 
                Cl_StrMag.getGuid(), DateTime.Now.ToString("yyyy.MM.dd"), DateTime.Now.ToString("yyyy.MM.dd"), Request["ddz"]);
            List<CheCi> cheCis = findTicket.findCheCi();
            if (cheCis == null)
            {
                Response.Write(new { success = false, msg = "查询失败" }.ToJSONString());
                return;
            }
            Response.Write(new { success = true,value= cheCis.ToJSONString() }.ToJSONString());
        }
        catch (Exception ex)
        {
            Response.Write(new { success = false, msg = ex.Message }.ToJSONString());
            Log.WriteLog(ex.Message);
        }
    }
    /// <summary>
    /// 获取微信JS配置签名
    /// </summary>
    private void getSignInfo()
    {
        var jsApiParam = new WxPayData();
        jsApiParam.SetValue("noncestr", WxPayApi.GenerateNonceStr());
        jsApiParam.SetValue("jsapi_ticket", pubdim.getJsTick());
        jsApiParam.SetValue("timestamp", WxPayApi.GenerateTimeStamp());
        jsApiParam.SetValue("url", Request["signUrl"]);
        jsApiParam.SetValue("signature", jsApiParam.MakeSign2());

        Response.Write(jsApiParam.ToJson());
        return;
    }

    /// <summary>
    /// 统一下单
    /// </summary>
    private void getPayParam()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        WxPayData orderResult = null;
        try
        {
            dic["openid"] = Request["openid"];   //微信客户标识
            dic["total_fee"] = (Convert.ToDecimal(Request["Amount"]) * 100).ToString("0");     //订单金额
            dic["pbOrderID"] = WxPayApi.GenerateOutTradeNo();   //预支付订单号
            dic["body"] = Request["MerchandiseText"];    //商品描述
            dic["attach"] = Request["MerchandiseSizeMB"] + "MB";    //商品大小
            dic["MerchandiseID"] = Request["MerchandiseID"];    //手机号
            dic["phone"] = Request["phone"];
            orderResult = pubdim.makeOrder(dic);
        }
        catch (WxPayException ex)
        {
            Log.WriteLog("微信支付发生异常:" + ex.Messages());
            Response.Write("{\"type\":\"1\",\"value\":\"微信支付发生异常，请返回重试！\"}");
            return;
        }
        catch (WebException ex)
        {
            Log.WriteLog("网络发生异常:" + ex.Messages());
            Response.Write("{\"type\":\"1\",\"value\":\"网络发生异常，请返回重试！\"}");
            return;

        }
        catch (Exception ex)
        {
            Log.WriteLog("创建预支付订单错误：" + ex.Messages());
            Response.Write("{\"type\":\"1\",\"value\":\"系统发生未知异常，请返回重试！\r\n" + ex.Message + "\"}");
            return;
        }

        try
        {
            d_fjp.tb_order order = new d_fjp.tb_order();
            order.tb_order_wxbs = Request["openid"];
            order.tb_order_TransID = dic["pbOrderID"];                       //预支付订单号
            order.tb_order_prepayID = orderResult.GetValue("prepay_id").ToString();    //预支付会话标识
            order.tb_order_Amount = Request["Amount"].CDec();
            order.tb_order_Status = "未支付";  //因为进入页面就会调用统一下单函数，所以每次进入这个页面都会有个订单，给客户列出订单的时候，这部分应该不显示，应该显示后面以后状态的订单
            order.add();
        }
        catch (Exception ex)
        {
            Log.WriteLog("保存预支付订单错误：" + ex.Messages());
            Response.Write("{\"type\":\"1\",\"value\":\"" + ex.Message + "\"}");
            return;
        }
        try
        {
            var result = pubdim.GetJsApiParameters(orderResult);
            Log.WriteLog("下预支付订单正常：" + "{\"type\":\"0\",\"value\":" + result.ToJson() + "}");
            Response.Write("{\"type\":\"0\",\"value\":" + result.ToJson() + "}");
            return;
        }
        catch (Exception ex)
        {
            Log.WriteLog("获取支付参数错误：" + ex.Messages());
            Response.Write("{\"type\":\"1\",\"value\":\"" + ex.Message + "\"}");
        }
    }
}