using AESUtils;
using Framework.Entity;
using App.FunctionLibrary;
using System;

namespace FjpTick
{
    /// <summary>
    /// pubdim 的摘要说明
    /// </summary>
    public static class pubdim
    {
        /// <summary>
        /// 字符串加密组件
        /// </summary>
        public static IAESED aes = new AESEDClass();
        /// <summary>
        /// 站点代码
        /// </summary>
        public static string ProxyID = Configer.Find("SocketClient", "ProxyID");
        /// <summary>
        /// 字符串加密关键字
        /// </summary>
        public static string EncryptKey = Configer.Find("SocketClient", "EncryptKey");
        /// <summary>
        /// 站点标识
        /// </summary>
        public static int StationID = Configer.Find("SocketClient", "StationID").Value.CInt();

        public static string GetEnCode(string str)
        {
            return (string)aes.GetEn(EncryptKey, str);
        }
        public static string GetDeCode(string str)
        {
            return (string)aes.GetDe(EncryptKey, str);
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy.MM.dd");
        }
    }
}
