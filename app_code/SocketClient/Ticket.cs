using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mySocketClient
{
    /// <summary>
    /// Ticket 的摘要说明
    /// </summary>
    public class Ticket
    {
        private string coach;
        private string run_date;
        private string run_time;
        private string origin;
        private string gate;
        private string seat;
        private string station;
        private string price;
        private string attach;
        private string distance;
        private string seat_type;

        public Ticket()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Ticket(string coach, string run_date, string run_time, string origin, string gate, string seat, string station, string price, string attach, string distance, string seat_type)
        {
            this.coach = coach;
            this.run_date = run_date;
            this.run_time = run_time;
            this.origin = origin;
            this.gate = gate;
            this.seat = seat;
            this.station = station;
            this.price = price;
            this.attach = attach;
            this.distance = distance;
            this.seat_type = seat_type;
        }

        public string toString()
        {
            return coach + "," + run_date + "," + run_time + "," + origin + "," + gate + "," + seat + "," + station + "," + price + "," + attach + "," + distance + "," + seat_type;
        }

        public string Coach
        {
            get
            {
                return coach;
            }

            set
            {
                coach = value;
            }
        }

        public string Run_date
        {
            get
            {
                return run_date;
            }

            set
            {
                run_date = value;
            }
        }

        public string Run_time
        {
            get
            {
                return run_time;
            }

            set
            {
                run_time = value;
            }
        }

        public string Origin
        {
            get
            {
                return origin;
            }

            set
            {
                origin = value;
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

        public string Station
        {
            get
            {
                return station;
            }

            set
            {
                station = value;
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

        public string Attach
        {
            get
            {
                return attach;
            }

            set
            {
                attach = value;
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

        public string Seat_type
        {
            get
            {
                return seat_type;
            }

            set
            {
                seat_type = value;
            }
        }

    }
}