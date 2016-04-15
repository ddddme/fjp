using System;
using Framework.Entity;
using FlowRecharge.Wechat;

public partial class example_NotifyPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ResultNotify resultNotify = new ResultNotify(this);
        resultNotify.ProcessNotify();
    }
}