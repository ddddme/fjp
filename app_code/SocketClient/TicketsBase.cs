using System;
using AESUtils;
using Framework.Entity;
using App.FunctionLibrary;
using System.Reflection;

namespace mySocketClient
{
    /// <summary>
    /// TicketsBase 的摘要说明
    /// </summary>
    public class TicketsBase
    {
        private static object _lockObj = new object();
        private static IAESED _aes = new AESEDClass();
        protected string _ProxyID = Configer.Find("SocketClient", "ProxyID");
        protected string _EncryptKey = Configer.Find("SocketClient", "EncryptKey");
        protected int _StationID = Configer.Find("SocketClient", "StationID").Value.CInt();
        protected SocketClient _Client;
        protected string _sessionID;

        public TicketsBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public TicketsBase(SocketClient cilent, string sessionID)
        {
            _Client = cilent;
            _sessionID = sessionID;
        }

        public TicketsBase(SocketClient cilent)
        {
            _Client = cilent;
        }


        protected string GetEnCode(string str)
        {
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            lock (_lockObj)
            {
                return (string)_aes.GetEn(_EncryptKey, str);
            }

        }
        protected string GetDeCode(string str)
        {
            lock (_lockObj)
            {
                //return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
                return (string)_aes.GetDe(_EncryptKey, str);
            }

        }

        protected string FormatDate(DateTime date)
        {
            return date.ToString("yyyy.MM.dd");
        }

    }
}