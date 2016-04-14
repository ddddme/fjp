using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 获取可到达站点
/// </summary>
public class GetStation : TicketsBase
{
    public GetStation():base()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public GetStation(SocketTestClient cilent) : base(cilent)
    {
       
    }

    public List<Station> getStation() {
        List<Station> stations = new List<Station>();

        var request010 = "JUNLYFUNC_010?" + _StationID + "`" + _ProxyID + "junly";

        bool isConnected = _Client.Connect();
        if (!isConnected)
        {
            return null;
        }

        _Client.SendMessage(request010);
        var response010 = _Client.ReceiveMessage();

        var response010Parts = response010.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var result010Part0 = response010Parts[0].Split('`');
        if (result010Part0[1] == "OK!")
        {
            for (int i = 4; i < response010Parts.Length; i++)
            {
                var result004Parts = response010Parts[i].Split('`');

                var stationname = response010Parts[i].Split('`')[0];
                var zjm = response010Parts[i].Split('`')[1];
                var distance = response010Parts[i].Split('`')[2];
                var qym = response010Parts[i].Split('`')[3];
               
                var station = new Station(stationname, zjm, distance, qym);

                stations.Add(station);

            }
            return stations;
        }

        return null;
    }
}