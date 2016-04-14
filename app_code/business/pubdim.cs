using System;
using System.Collections.Generic;
using LitJson;
using App.FunctionLibrary;

namespace FlowRecharge.Wechat
{
    public class pubdim
    {
        public static string access_token { get; set; }

        private static string jsapi_ticket = "";
        private static DateTime jsapiTime;
        private static int expires_in = 0;

        /// <summary>
        /// 统一下单接口函数
        /// </summary>
        public static WxPayData makeOrder(Dictionary<string, string> dic)
        {
            //下单的时候先验证产品与金额是否相符
            //订单金额验证
            //List<PriceItem> ltPrice = business.FlowRechargeService.Get_Prices();
            //List<PriceItem> tLttm = ltPrice.FindAll(x => x.MerchandiseID == dic["MerchandiseID"]);
            //if (tLttm.Count != 1)
            //    throw new WxPayException("下订单出错,不存在的产品！"+ dic["phone"]);

            //var tFee = tLttm[0].Price;
            decimal tFee = 0.01M;
            if (dic["total_fee"].CDec() != tFee * 100)
                throw new WxPayException("下订单出错,订单金额错误！" + dic["phone"] + ",页面金额：" + dic["total_fee"] +",套餐金额："+tFee);

            WxPayData data = new WxPayData();
            data.SetValue("body", dic["body"]);
            data.SetValue("attach", dic["attach"]);
            data.SetValue("out_trade_no", dic["pbOrderID"]);
            data.SetValue("total_fee", dic["total_fee"]);
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            data.SetValue("goods_tag", "");
            data.SetValue("trade_type", "JSAPI");
            data.SetValue("openid", dic["openid"]);

            WxPayData result = WxPayApi.UnifiedOrder(data);
            if (!result.IsSet("appid") || !result.IsSet("prepay_id") || result.GetValue("prepay_id").ToString() == "")
            {
                throw new WxPayException("下订单出错！" + dic["phone"]);
            }
            return result;
        }

        /// <summary>
        /// 获取支付所需的参数
        /// </summary>
        /// <param name="pOrderResult">统一下单返回的结构</param>
        public static WxPayData GetJsApiParameters(WxPayData pOrderResult)
        {
            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("appId", pOrderResult.GetValue("appid"));
            jsApiParam.SetValue("timeStamp", WxPayApi.GenerateTimeStamp());
            jsApiParam.SetValue("nonceStr", WxPayApi.GenerateNonceStr());
            jsApiParam.SetValue("package", "prepay_id=" + pOrderResult.GetValue("prepay_id"));
            jsApiParam.SetValue("signType", "MD5");
            jsApiParam.SetValue("paySign", jsApiParam.MakeSign());
            return jsApiParam;
        }

        /// <summary>
        /// 获取JS票据
        /// </summary>
        public static string getJsTick()
        {
            if (jsapi_ticket != "")
            {
                TimeSpan t = DateTime.Now.Subtract(jsapiTime);
                if (t.Seconds < 7000)
                {
                    return jsapi_ticket;
                }
                //int iNum=DateTime.Compare(DateTime.Now,jsapiTime)
            }

            //构造获取openid及access_token的url
            var data = new WxPayData();
            data.SetValue("appid", WxPayConfig.APPID);
            data.SetValue("secret", WxPayConfig.APPSECRET);
            data.SetValue("grant_type", "client_credential");
            var url = "https://api.weixin.qq.com/cgi-bin/token?" + data.ToUrl();

            //请求url以获取数据
            var result = HttpService.Get(url);
            var jd = JsonMapper.ToObject(result);
            access_token = (string)jd["access_token"];
            expires_in = (int)jd["expires_in"];
            jsapiTime = DateTime.Now;

            data = new WxPayData();
            data.SetValue("access_token", pubdim.access_token);
            data.SetValue("type", "jsapi");
            url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?" + data.ToUrl();
            result = HttpService.Get(url);
            jd = JsonMapper.ToObject(result);
            jsapi_ticket = (string)jd["ticket"];

            return jsapi_ticket;
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        public static bool QueryOrder(string transaction_id, out WxPayData pRes)
        {
            var req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);

            pRes = WxPayApi.OrderQuery(req);

            return pRes.GetValue("return_code").ToString().EqualsIgnoreCase("SUCCESS") &&
                   pRes.GetValue("result_code").ToString().EqualsIgnoreCase("SUCCESS");
        }
    }

    public static class mo_myKz
    {
        public enum en_clFun
        {
            获取到达站=1,
            获取票列表,
            获取订单列表,
            获取微信JS配置签名,
            统一下单
        }
    }
}