using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UnLockTicket 的摘要说明
/// </summary>
public class UnLockTicket : TicketsBase
{
    public UnLockTicket() :base()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public UnLockTicket(SocketTestClient cilent, string sessionID) : base(cilent, sessionID)
    {
       
    }

    public bool unLockTicket() {
        var slinkOri = "out_trade_no=" + _sessionID;
        var slinkEncrypted = GetEnCode(slinkOri);
        var request002 = "JUNLYFUNC_002?" + _sessionID + "`" + slinkEncrypted + "`" + _ProxyID + "junly";
        _Client.SendMessage(request002);
        var response002 = _Client.ReceiveMessage();

        var response002Parts = response002.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var result002Parts = response002Parts[0].Split('`');
        if (result002Parts[1] == "OK!")
        {
            return true;
        }

        return false;
    }
}