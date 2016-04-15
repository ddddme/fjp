using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mySocketClient
{
    /// <summary>
    /// Ticket 的摘要说明
    /// </summary>
    public class CheCi
    {
        private string fcDate;
        private string fcTime;
        private string checi;
        private string destination;
        private string chexing;
        private string licheng;
        private string yupiao;
        private string price;
        private string seat;
        private string runline;
        private string memorial;
        private string code;
        private string actionCode;

        public CheCi()
        {

        }

        public CheCi(string fcDate, string fcTime, string checi, string destination, string chexing, string licheng, string yupiao, string price, string seat, string runline, string memorial, string code, string actionCode)
        {
            this.fcDate = fcDate;
            this.fcTime = fcTime;
            this.checi = checi;
            this.destination = destination;
            this.chexing = chexing;
            this.licheng = licheng;
            this.yupiao = yupiao;
            this.price = price;
            this.seat = seat;
            this.runline = runline;
            this.memorial = memorial;
            this.code = code;
            this.actionCode = actionCode;
        }

        public string toString()
        {
            return fcDate + "," + fcTime + "," + checi + "," + destination + "," + chexing + "," + licheng + "," + yupiao + "," + price + "," + seat + "," + runline + "," + memorial + "," + code + "," + actionCode;
        }

        public string FcDate
        {
            get
            {
                return fcDate;
            }

            set
            {
                fcDate = value;
            }
        }

        public string FcTime
        {
            get
            {
                return fcTime;
            }

            set
            {
                fcTime = value;
            }
        }

        public string Checi
        {
            get
            {
                return checi;
            }

            set
            {
                checi = value;
            }
        }

        public string Destination
        {
            get
            {
                return destination;
            }

            set
            {
                destination = value;
            }
        }

        public string Chexing
        {
            get
            {
                return chexing;
            }

            set
            {
                chexing = value;
            }
        }

        public string Licheng
        {
            get
            {
                return licheng;
            }

            set
            {
                licheng = value;
            }
        }

        public string Yupiao
        {
            get
            {
                return yupiao;
            }

            set
            {
                yupiao = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string Seat
        {
            get
            {
                return seat;
            }

            set
            {
                seat = value;
            }
        }

        public string Runline
        {
            get
            {
                return runline;
            }

            set
            {
                runline = value;
            }
        }

        public string Memorial
        {
            get
            {
                return memorial;
            }

            set
            {
                memorial = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string ActionCode
        {
            get
            {
                return actionCode;
            }

            set
            {
                actionCode = value;
            }
        }

    }
}