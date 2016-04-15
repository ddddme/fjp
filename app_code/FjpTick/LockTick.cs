using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FjpTick
{
    /// <summary>
    /// 索票信息
    /// </summary>
    public class LockTick
    {
        public LockTick()
        {
        }
       public static List<LockTickOut>  getLockTick(LockTickIn pIn)
        {
            return null;
        }

        /// <summary>
        /// 锁票入参
        /// </summary>
        public class LockTickIn
        {
            private string _sessionId;
            private string _cheCi;
            private int _buyCount = 1;
            private string _buyerName;
            private string _idCardNumber;
            private string _phoneNumber;
            public LockTickIn()
            {
            }
            /// <summary>
            /// 车次
            /// </summary>
            public string cheCi { get { return _cheCi; } set { _cheCi = value; } }
            /// <summary>
            /// 购票数量（每一交易只能购买同一车次多张车票）
            /// </summary>
            public int buyCount { get { return _buyCount; } set { _buyCount = value; } }
            /// <summary>
            /// 姓名（总代理机构名称）
            /// </summary>
            public string buyerName { get { return _buyerName; } set { _buyerName = value; } }
            /// <summary>
            /// 身份证号（总代理机构地址）
            /// </summary>
            public string idCardNumber { get { return _idCardNumber; } set { _idCardNumber = value; } }
            /// <summary>
            /// 电话（总代理机构联系电话）
            /// </summary>
            public string phoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        }
        /// <summary>
        /// 锁票返回参数
        /// </summary>
        public class LockTickOut
        {
            //车次`发车日期`发车时间`起点站`检票口`座位号`到达站`票价`附加费`里程数`车型
            private string _rv_0;
            private string _rv_1;
            private string _rv_2;
            private string _rv_3;
            private string _rv_4;
            private string _rv_5;
            private string _rv_6;
            private string _rv_7;
            private string _rv_8;
            private string _rv_9;
            private string _rv_10;
            public LockTickOut()
            {
            }
            /// <summary>
            /// 车次
            /// </summary>
            public string rv_0 { get { return _rv_0; } set { _rv_0 = value; } }
            /// <summary>
            /// 发车日期
            /// </summary>
            public string rv_1 { get { return _rv_1; } set { _rv_1 = value; } }
            /// <summary>
            /// 发车时间
            /// </summary>
            public string rv_2 { get { return _rv_2; } set { _rv_2 = value; } }
            /// <summary>
            /// 起点站
            /// </summary>
            public string rv_3 { get { return _rv_3; } set { _rv_3 = value; } }
            /// <summary>
            /// 检票口
            /// </summary>
            public string rv_4 { get { return _rv_4; } set { _rv_4 = value; } }
            /// <summary>
            /// 座位号
            /// </summary>
            public string rv_5 { get { return _rv_5; } set { _rv_5 = value; } }
            /// <summary>
            /// 到达站
            /// </summary>
            public string rv_6 { get { return _rv_6; } set { _rv_6 = value; } }
            /// <summary>
            /// 票价
            /// </summary>
            public string rv_7 { get { return _rv_7; } set { _rv_7 = value; } }
            /// <summary>
            /// 附加费
            /// </summary>
            public string rv_8 { get { return _rv_8; } set { _rv_8 = value; } }
            /// <summary>
            /// 里程数
            /// </summary>
            public string rv_9 { get { return _rv_9; } set { _rv_9 = value; } }
            /// <summary>
            /// 车型
            /// </summary>
            public string rv_10 { get { return _rv_10; } set { _rv_10 = value; } }          

        }
    }
}
