using System;
using System.Linq;
using System.Text;
using System.Net.Sockets;

public class SocketTestClient : IDisposable
{
    private string _ServerAddress;
    private int _ServerPort;
    private Socket _Socket;

    public SocketTestClient(string serverAddress, int port)
    {
        _ServerAddress = serverAddress;
        _ServerPort = port;
    }
    public SocketTestClient()
    {
        _ServerAddress = Framework.Entity.Configer.Find("SocketClient", "ServerAddress");
        _ServerPort = Convert.ToInt32(Framework.Entity.Configer.Find("SocketClient", "ServerPort"));
    }
    /// <summary>
    /// 连接，返回成功标识
    /// </summary>
    public bool Connect()
    {
        DisConnect();
        //string iStr = "192.168.1.4:1234";
        //System.Net.IPAddress IPadr = System.Net.IPAddress.Parse(iStr.Split(':')[0]);//先把string类型转换成IPAddress类型
        //System.Net.IPEndPoint EndPoint = new System.Net.IPEndPoint(IPadr, int.Parse(iStr.Split(':')[1]));//传递IPAddress和Port
        //_Socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        //_Socket.Bind(EndPoint);

        _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _Socket.Connect(_ServerAddress, _ServerPort);
        return _Socket.Connected;
    }
    /// <summary>
    /// 断开连接
    /// </summary>
    public void DisConnect()
    {
        if (_Socket != null && _Socket.Connected)
        {
            _Socket.Disconnect(false);
        }
    }
    //析构函数
    public void Dispose()
    {
        if (_Socket != null && _Socket.Connected)
        {
            _Socket.Disconnect(false);
            _Socket.Dispose();
        }
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    public void SendMessage(string message)
    {
        _Socket.Send(Encoding.Default.GetBytes(message));
    }
    /// <summary>
    /// 接收消息
    /// </summary>
    public string ReceiveMessage()
    {
        StringBuilder sb = new StringBuilder();
        byte[] buffer = new byte[102400];
        int count = _Socket.Receive(buffer, buffer.Length, 0);
        if (count > 0)
        {
            sb.Append(Encoding.Default.GetString(buffer.Take(count).ToArray()));
        }
        return sb.ToString();
    }
}
