using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mySocketClient
{
    /// <summary>
    /// Order 的摘要说明
    /// </summary>
    public class Order
    {
        private string jyzt;//交易状态
        private string orderID;
        private string jytime;
        private string fktime;
        private string qxtime;
        private string qptime;
        private string tptime;
        private string phonenumber;
        private string IDcard;
        private string name;
        private string dzqpm;//电子取票码
        private string count;
        private string price;
        private string totalfee;
        private string fcdate;
        private string fctime;
        private string checi;
        private string detination;
        private string jf;//积分是否兑换
        private string orign;
        private string gate;
        private string seat;
        private string ticketNO;
        private string distance;

        public Order(string jyzt, string orderID, string jytime, string fktime, string qxtime, string qptime, string tptime, string phonenumber, string IDcard, string name, string dzqpm, string count, string price, string totalfee, string fcdate, string fctime, string checi, string detination, string jf, string orign, string gate, string seat, string ticketNO, string distance)
        {
            this.jyzt = jyzt;
            this.orderID = orderID;
            this.jytime = jytime;
            this.fktime = fktime;
            this.qxtime = qxtime;
            this.qptime = qptime;
            this.tptime = tptime;
            this.phonenumber = phonenumber;
            this.IDcard = IDcard;
            this.name = name;
            this.dzqpm = dzqpm;
            this.count = count;
            this.price = price;
            this.totalfee = totalfee;
            this.fcdate = fcdate;
            this.fctime = fctime;
            this.checi = checi;
            this.detination = detination;
            this.jf = jf;
            this.orign = orign;
            this.gate = gate;
            this.seat = seat;
            this.ticketNO = ticketNO;
            this.distance = distance;

        }

        public string toString()
        {
            return jyzt + "," + orderID + "," + jytime + "," + fktime + "," + qxtime + "," + qptime + "," + tptime + "," + phonenumber + "," + IDcard + "," + name + "," + dzqpm + "," + count + "," + price + "," + totalfee + "," + fcdate + "," + fctime + "," + checi + "," + detination + "," + jf + "," + orign + "," + gate + "," + seat + "," + ticketNO + "," + distance;
        }

        public Order()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public string Jyzt
        {
            get
            {
                return jyzt;
            }

            set
            {
                jyzt = value;
            }
        }

        public string OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
            }
        }

        public string Jytime
        {
            get
            {
                return jytime;
            }

            set
            {
                jytime = value;
            }
        }

        public string Fktime
        {
            get
            {
                return fktime;
            }

            set
            {
                fktime = value;
            }
        }

        public string Qxtime
        {
            get
            {
                return qxtime;
            }

            set
            {
                qxtime = value;
            }
        }

        public string Qptime
        {
            get
            {
                return qptime;
            }

            set
            {
                qptime = value;
            }
        }

        public string Tptime
        {
            get
            {
                return tptime;
            }

            set
            {
                tptime = value;
            }
        }

        public string Phonenumber
        {
            get
            {
                return phonenumber;
            }

            set
            {
                phonenumber = value;
            }
        }

        public string IDcard1
        {
            get
            {
                return IDcard;
            }

            set
            {
                IDcard = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Dzqpm
        {
            get
            {
                return dzqpm;
            }

            set
            {
                dzqpm = value;
            }
        }

        public string Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
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

        public string Totalfee
        {
            get
            {
                return totalfee;
            }

            set
            {
                totalfee = value;
            }
        }

        public string Fcdate
        {
            get
            {
                return fcdate;
            }

            set
            {
                fcdate = value;
            }
        }

        public string Fctime
        {
            get
            {
                return fctime;
            }

            set
            {
                fctime = value;
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

        public string Detination
        {
            get
            {
                return detination;
            }

            set
            {
                detination = value;
            }
        }

        public string Jf
        {
            get
            {
                return jf;
            }

            set
            {
                jf = value;
            }
        }

        public string Orign
        {
            get
            {
                return orign;
            }

            set
            {
                orign = value;
            }
        }

        public string Gate
        {
            get
            {
                return gate;
            }

            set
            {
                gate = value;
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

        public string TicketNO
        {
            get
            {
                return ticketNO;
            }

            set
            {
                ticketNO = value;
            }
        }

        public string Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

    }
}