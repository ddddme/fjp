using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mySocketClient
{
    /// <summary>
    /// FindOrder 的摘要说明
    /// </summary>
    public class FindOrder : TicketsBase
    {
        private string sType;
        private string sCondition;
        private string sRunDate;

        public FindOrder() : base()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public FindOrder(SocketClient cilent, string sType, string sCondition, string sRunDate) : base(cilent)
        {
            this.sType = sType;
            this.sCondition = sCondition;
            this.sRunDate = sRunDate;
        }

        public List<Order> findOrder()
        {
            List<Order> orders = new List<Order>();

            var slinkOri = _StationID + "&" + sType + "&" + sCondition + "&" + sRunDate;
            var slinkEncrypted = GetEnCode(slinkOri);

            var request004 = "JUNLYFUNC_004?" + _StationID + "`" + sType + "`" + sCondition + "`" + sRunDate + "`" + slinkEncrypted + "`" + _ProxyID + "junly";

            bool isConnected = _Client.Connect();
            if (!isConnected)
            {
                return null;
            }

            _Client.SendMessage(request004);
            var response004 = _Client.ReceiveMessage();

            var response004Parts = response004.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result004Part0 = response004Parts[0].Split('`');
            if (result004Part0[1] == "OK!")
            {
                for (int i = 4; i < response004Parts.Length; i++)
                {
                    var result004Parts = response004Parts[i].Split('`');

                    var jyzt = response004Parts[i].Split('`')[0];
                    var orderID = response004Parts[i].Split('`')[1];
                    var jytime = response004Parts[i].Split('`')[2];
                    var fktime = response004Parts[i].Split('`')[3];
                    var qxtime = response004Parts[i].Split('`')[4];
                    var qptime = response004Parts[i].Split('`')[5];
                    var tptime = response004Parts[i].Split('`')[6];
                    var phonenumber = response004Parts[i].Split('`')[7];
                    var IDcard = response004Parts[i].Split('`')[8];
                    var name = response004Parts[i].Split('`')[9];
                    var dzqpm = response004Parts[i].Split('`')[10];
                    var count = response004Parts[i].Split('`')[11];
                    var price = response004Parts[i].Split('`')[11];
                    var totalfee = response004Parts[i].Split('`')[13];
                    var fcdate = response004Parts[i].Split('`')[14];
                    var fctime = response004Parts[i].Split('`')[15];
                    var checi = response004Parts[i].Split('`')[16];
                    var detination = response004Parts[i].Split('`')[17];
                    var jf = response004Parts[i].Split('`')[18];
                    var orign = response004Parts[i].Split('`')[19];
                    var gate = response004Parts[i].Split('`')[20];
                    var seat = response004Parts[i].Split('`')[21];
                    var ticketNO = response004Parts[i].Split('`')[22];
                    var distance = response004Parts[i].Split('`')[23];

                    var order = new Order(jyzt, orderID, jytime, fktime, qxtime, qptime, tptime, phonenumber, IDcard, name, dzqpm, count, price, totalfee, fcdate, fctime, checi, detination, jf, orign, gate, seat, ticketNO, distance);

                    orders.Add(order);

                }
                return orders;
            }

            return null;
        }
    }
}