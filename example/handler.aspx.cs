using System;
using System.Collections.Generic;
using FlowRecharge.Wechat;
using System.Net;
using App.FunctionLibrary;
using yangNetCl;
using System.Threading;
using mySocketClient;

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
                case mo_myKz.en_clFun.获取用户信息:
                    GetUserinfo();
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
                case mo_myKz.en_clFun.保存用户信息:
                    saveUser();
                    break;

            }
        }
        catch {
            Response.Write(new { success = false, msg="系统错误！" }.ToJSONString());
        }
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
            List<FjpTick.Station.StationOut> stations = FjpTick.Station.getStation();
            if (stations == null)
            {
                Response.Write(new { success = false, msg = "查询站点失败" }.ToJSONString());
                return;
            }
            Response.Write(new { success = true, value = stations.ToJSONString() }.ToJSONString());
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
            string tGuid = Cl_StrMag.getGuid();
            FindCheCis findTicket = new FindCheCis(new SocketClient(), tGuid
                , DateTime.Now.ToString("yyyy.MM.dd"), DateTime.Now.ToString("yyyy.MM.dd"), Request["ddz"]);
            List<CheCi> cheCis = findTicket.findCheCi();
            if (cheCis == null)
            {
                Response.Write(new { success = false, msg = "查询失败" }.ToJSONString());
                return;
            }
            if (cheCis.Count==0)
            {
                Response.Write(new { success = false, msg = "目前没有到该地区的车票！" }.ToJSONString());
                return;
            }
            Response.Write(new { success = true, BatchID = tGuid, value = cheCis.ToJSONString() }.ToJSONString());
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
            dic["body"] = "武汉-" + Request["Destination"] + " " + Request["Checi"] + " " + Cl_StrMag.YanForDa_1(Request["FcDate"]) + " " + Request["FcTime"];    //商品描述
            dic["attach"] = "";    //商品大小
            dic["out_trade_no"] = Request["BatchID"];    //商户订单号
            //dic["pbOrderID"] = WxPayApi.GenerateOutTradeNo();   //预支付订单号
            orderResult = pubdim.makeOrder(dic);
        }
        catch (WxPayException ex)
        {
            Log.WriteLog("微信支付发生异常:" + ex.Messages());
            Response.Write(new { success = false, msg = "微信支付发生异常，请返回重试！" }.ToJSONString());
            return;
        }
        catch (WebException ex)
        {
            Log.WriteLog("网络发生异常:" + ex.Messages());
            Response.Write(new { success = false, msg = "网络发生异常，请返回重试！" }.ToJSONString());
            return;

        }
        catch (Exception ex)
        {
            Log.WriteLog("创建预支付订单错误：" + ex.Messages());
            Response.Write(new { success = false, msg = "微信支付发生异常，请返回重试！" }.ToJSONString());
            return;
        }

        try
        {
            d_fjp.tb_order order = new d_fjp.tb_order();
            order.tb_order_wxbs = Request["openid"];
            order.tb_order_BatchID = Request["BatchID"];                       //商户订单号
            order.tb_order_prepayID = orderResult.GetValue("prepay_id").ToString();    //预支付会话标识
            order.tb_order_Amount = Request["Amount"].CDec();   //订单金额
            order.tb_order_Status = "未支付";  //因为进入页面就会调用统一下单函数，所以每次进入这个页面都会有个订单，给客户列出订单的时候，这部分应该不显示，应该显示后面以后状态的订单
            order.tb_order_cc = Request["Checi"];
            order.tb_order_ddz = Request["Destination"];
            order.tb_order_fcsj = Convert.ToDateTime(Cl_StrMag.YanForDa_2(Request["FcDate"] + " " + Request["FcTime"] + ":00"));
            order.tb_order_pj = Convert.ToDecimal(Request["Price"]);
            order.add();
        }
        catch (Exception ex)
        {
            Log.WriteLog("保存预支付订单错误：" + ex.Messages());
            Response.Write(new { success = false, msg = "微信支付发生异常，请返回重试！" }.ToJSONString());
            return;
        }
        try
        {
            var result = pubdim.GetJsApiParameters(orderResult);
            Log.WriteLog("下预支付订单正常：" + new { success = true, value = result.ToJson() }.ToJSONString());
            Response.Write(new { success = true, value = result.ToJson() }.ToJSONString());
            return;
        }
        catch (Exception ex)
        {
            Log.WriteLog("获取支付参数错误：" + ex.Messages());
            Response.Write(new { success = false, msg = "微信支付发生异常，请返回重试！" }.ToJSONString());
        }
    }
    /// <summary>
    /// 获取用户信息
    /// </summary>
    private void GetUserinfo()
    {
        List<d_fjp.tb_user> userinfo = d_fjp.tb_user.GetModelList("tb_user_wxbs='" + Request["wxbs"]+"'");
        if (userinfo.Count == 0)
            Response.Write(new { success = false, msg = "没有该用户信息！" }.ToJSONString());
        else
            Response.Write(new { success = true, value = userinfo[0].ToJSONString() }.ToJSONString());
    }
    private void saveUser()
    {
        int rvid = 0;    
        if (string.IsNullOrEmpty(Request["tb_user_ID"]))
        {
            //添加
            if (d_fjp.tb_user.GetModelList("tb_user_sfz='"+ Request["tb_user_sfz"].Trim()+ "'").Count>0)
            {
                Response.Write(new { success = false, msg = "该身份证信息已被注册！" }.ToJSONString());
                return;
            }
            if (d_fjp.tb_user.GetModelList("tb_user_phone='" + Request["tb_user_phone"].Trim() + "'").Count > 0)
            {
                Response.Write(new { success = false, msg = "该手机号码已被注册！" }.ToJSONString());
                return;
            }
            rvid= Cl_DataMag.saveRequestData("tb_user");
        }
        else
        {
            //修改
            if (d_fjp.tb_user.GetModelList("tb_user_sfz='" + Request["tb_user_sfz"].Trim() + "' and tb_user_ID<>" + Request["tb_user_ID"].Trim()).Count > 0)
            {
                Response.Write(new { success = false, msg = "该身份证信息已被注册！" }.ToJSONString());
                return;
            }

            if (d_fjp.tb_user.GetModelList("tb_user_phone='" + Request["tb_user_phone"].Trim() + "' and tb_user_ID<>" + Request["tb_user_ID"].Trim()).Count > 0)
            {
                Response.Write(new { success = false, msg = "该手机号码已被注册！" }.ToJSONString());
                return;
            }
            Cl_DataMag.modRequestData("tb_user", Request["tb_user_ID"].Trim());
            rvid = Request["tb_user_ID"].Trim().ToString().CInt();
        }
        Response.Write(new { success = true, value = d_fjp.tb_user.getNewModel(rvid).ToJSONString() }.ToJSONString());
    }
}