using System;

namespace FlowRecharge.Wechat
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg) : base(msg) { }
    }
}