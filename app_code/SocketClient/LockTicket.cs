using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mySocketClient
{
    /// <summary>
    /// LockTicket 的摘要说明
    /// </summary>
    public class LockTicket : TicketsBase
    {
        private CheCi cheCi;
        private int buyCount;
        private string buyerName;
        private string idCardNumber;
        private string phoneNumber;

        public LockTicket() : base()
        {

        }

        public LockTicket(SocketClient cilent, string sessionID, CheCi cheCi, int buyCount, string buyerName, string idCardNumber, string phoneNumber) : base(cilent, sessionID)
        {
            this.cheCi = cheCi;
            this.buyCount = buyCount;
            this.buyerName = buyerName;
            this.idCardNumber = idCardNumber;
            this.phoneNumber = phoneNumber;

        }

        public bool lockTicket()
        {
            var actionCode = cheCi.ActionCode;
            if (string.IsNullOrEmpty(actionCode))
            {
                return false;
            }
            var request001 = "JUNLYFUNC_001?" + actionCode + "`" + _sessionID + "`" + buyerName + "`" + idCardNumber + "`" + phoneNumber + "`" + buyCount + "`" + _ProxyID + "junly";
            _Client.SendMessage(request001);
            var response001 = _Client.ReceiveMessage();

            var response001Parts = response001.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result001Parts = response001Parts[0].Split('`');
            if (result001Parts[1] == "OK!")
            {
                return true;
            }

            return false;
        }
    }
}