using System;
using Framework.Entity;

public partial class example_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Framework.Entity.Configer.IsDebugging)
        {
            yangNetCl.Cl_fileMag.setEnumJsFile(typeof(FlowRecharge.Wechat.mo_myKz),
              Server.MapPath(@"\") + @"js\userFun\enumPubdim.js");
        }
        if (!IsPostBack && !Configer.IsDebugging)
        {
            var jsApiPay = new FlowRecharge.Wechat.JsApiPay(this);
            try
            {
                //调用【网页授权获取用户信息】接口获取用户的openid和access_token
                jsApiPay.GetOpenidAndAccessToken();
                ViewState["openid"] = jsApiPay.openid;
            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错，请重试 ...\r\n\r\n" + ex.Message + "</span>");
            }
        }
    }
}
