using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// BuyTicket 的摘要说明
/// </summary>
public class BuyTicket : TicketsBase
{
    private int totalFeeInt;
    private string trade_no;
    private string zfType;

    public BuyTicket() :base()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public BuyTicket(SocketTestClient cilent, string sessionID,int totalFeeInt, string trade_no, string zfType) : base(cilent, sessionID)
    {
        this.totalFeeInt = totalFeeInt;
        this.trade_no = trade_no;
        this.zfType = zfType;
    }

    public List<Ticket> buyTicket() {
        List<Ticket> tickets = new List<Ticket>();
        var slinkOri = "out_trade_no=" + _sessionID + "&total_fee=" + totalFeeInt.ToString("D12") +
               "&trade_no=" + trade_no + "&zfType=" + zfType;
        var slinkEncrypted = GetEnCode(slinkOri);
        var request003 = "JUNLYFUNC_003?" + _sessionID + "`" + totalFeeInt.ToString("D12") + "`" + trade_no + "`" + zfType + "`" + slinkEncrypted + "`" + _ProxyID + "junly";
        _Client.SendMessage(request003);
        var response003 = _Client.ReceiveMessage();

        var response003Parts = response003.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var result003Part0 = response003Parts[0].Split('`');
        if (result003Part0[1] == "OK!")
        {
            for (int i = 4; i < response003Parts.Length; i++)
            {
                var result003Parts = response003Parts[i].Split('`');

                var coach = response003Parts[i].Split('`')[0];
                var run_date = response003Parts[i].Split('`')[1];
                var run_time = response003Parts[i].Split('`')[2];
                var origin = response003Parts[i].Split('`')[3];
                var gate = response003Parts[i].Split('`')[4];
                var seat = response003Parts[i].Split('`')[5];
                var station = response003Parts[i].Split('`')[6];
                var price = response003Parts[i].Split('`')[7];
                var attach = response003Parts[i].Split('`')[8];
                var distance = response003Parts[i].Split('`')[9];
                var seat_type = response003Parts[i].Split('`')[10];

                var ticket = new Ticket(coach, run_date, run_time, origin, gate, seat, station, price, attach, distance, seat_type);

                tickets.Add(ticket);
                
              }
            return tickets;
        }
        return null;   
    }
}