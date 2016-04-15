using mySocketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FjpTick
{

    /// <summary>
    /// 到达站信息
    /// </summary>
    public class Station
    {
        public Station()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取可售的目标站点
        /// </summary>
        /// <param name="pStationID">站点编号</param>
        /// <param name="pProxyID">代理机构编号</param>
        public static List<StationOut> getStation(string pStationID="", string pProxyID="", mySocketClient.SocketClient pClient = null)
        {
            SocketClient _Client = pClient == null ? new SocketClient() : pClient;
            string StationID = pubdim.StationID.ToString();
            string ProxyID = pubdim.ProxyID;
            List<StationOut> stations = new List<StationOut>();

            var request010 = "JUNLYFUNC_010?" + StationID + "`" + ProxyID + "junly";

            bool isConnected = _Client.Connect();
            if (!isConnected)
            {
                return null;
            }

            _Client.SendMessage(request010);
            var response010 = _Client.ReceiveMessage();

            var response010Parts = response010.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result010Part0 = response010Parts[0].Split('`');
            if (result010Part0[1] != "OK!")
            {
                return null;
            }
            for (int i = 4; i < response010Parts.Length; i++)
            {
                StationOut station = new StationOut();
                station.stationname = response010Parts[i].Split('`')[0];
                station.zjm = response010Parts[i].Split('`')[1];
                station.distance = response010Parts[i].Split('`')[2];
                station.qym = response010Parts[i].Split('`')[3];

                stations.Add(station);
            }
            return stations;
        }
        /// <summary>
        /// 返回参数
        /// </summary>
        public class StationOut
        {
            private string _stationname; //站点名称
            private string _zjm;//助记码
            private string _distance;  //距离
            private string _qym;//区域码
            public StationOut()
            {
                //
                // TODO: 在此处添加构造函数逻辑
                //
            }
            /// <summary>
            /// 站点名称
            /// </summary>
            public string stationname { get { return _stationname; } set { _stationname = value; } }
            /// <summary>
            /// 助记码
            /// </summary>
            public string zjm { get { return _zjm; } set { _zjm = value; } }
            /// <summary>
            /// 距离
            /// </summary>
            public string distance { get { return _distance; } set { _distance = value; } }
            /// <summary>
            /// 区域码
            /// </summary>
            public string qym { get { return _qym; } set { _qym = value; } }
        }
    }

}