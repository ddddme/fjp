using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mySocketClient
{
    /// <summary>
    ///车站信息
    /// </summary>
    public class Station
    {
        private string _stationname;
        private string _zjm;//助记码
        private string _distance;
        private string _qym;//区域码

        public Station(string stationname, string zjm, string distance, string qym)
        {
            this._stationname = stationname;
            this._zjm = zjm;
            this._distance = distance;
            this._qym = qym;
        }
        public string toString()
        {
            return _stationname + "," + _zjm + "," + _distance + "," + _qym;
        }
        public Station()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 站名
        /// </summary>
        public string Stationname
        {
            get
            {
                return _stationname;
            }

            set
            {
                _stationname = value;
            }
        }
        /// <summary>
        /// 助记码
        /// </summary>
        public string Zjm
        {
            get
            {
                return _zjm;
            }

            set
            {
                _zjm = value;
            }
        }
        public string Distance
        {
            get
            {
                return _distance;
            }

            set
            {
                _distance = value;
            }
        }
        /// <summary>
        /// 区域码
        /// </summary>
        public string Qym
        {
            get
            {
                return _qym;
            }

            set
            {
                _qym = value;
            }
        }
    }
}