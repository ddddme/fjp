using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace mySocketClient
{
    /// <summary>
    /// FindTickets 的摘要说明
    /// </summary>
    public class FindCheCis : TicketsBase
    {
        private string _startDateTime;
        private string _endDateTime;
        private string _destination;
        public FindCheCis() : base()
        {

        }
        public FindCheCis(SocketClient cilent, string sessionID, string startDateTime, string endDateTime, string destination) : base(cilent, sessionID)
        {
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
            _destination = destination;
        }

        public List<CheCi> findCheCi()
        {
            var cheCis = new List<CheCi>();
            var actionCode = "";

            if (string.IsNullOrEmpty(_startDateTime) || string.IsNullOrEmpty(_endDateTime) || string.IsNullOrEmpty(_sessionID))
            {
                return null;
            }
            var request000 = "JUNLYFUNC_000?" + _StationID + "`" + _destination + "`" + _startDateTime + "`" + _endDateTime + "`" + _sessionID + "`" + _ProxyID + "junly";
            bool isConnected = _Client.Connect();
            if (!isConnected)
            {
                return null;
            }
            _Client.SendMessage(request000);
            var response000 = _Client.ReceiveMessage();

            var response000Parts = response000.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (response000Parts.Count() < 5)
            {
                return null;
            }

            for (int i = 4; i < response000Parts.Length; i++)
            {
                var result000Parts = response000Parts[i].Split('`');
                if (result000Parts.Length == 13)
                {
                    actionCode = response000Parts[i].Split('`')[12];
                }

                var fcDate = response000Parts[i].Split('`')[0];
                var fcTime = response000Parts[i].Split('`')[1];
                var checi = response000Parts[i].Split('`')[2];
                var destination = response000Parts[i].Split('`')[3];
                var chexing = response000Parts[i].Split('`')[4];
                var licheng = response000Parts[i].Split('`')[5];
                var yupiao = response000Parts[i].Split('`')[6];
                var price = response000Parts[i].Split('`')[7];
                var seat = response000Parts[i].Split('`')[8];
                var runline = response000Parts[i].Split('`')[9];
                var memorial = response000Parts[i].Split('`')[10];
                var code = response000Parts[i].Split('`')[11];

                var cheCi = new CheCi(fcDate, fcTime, checi, destination, chexing, licheng, yupiao, price, seat, runline, memorial, code, actionCode);

                cheCis.Add(cheCi);


            }

            return cheCis;
        }

    }
}