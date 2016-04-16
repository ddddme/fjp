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
        //锁票操作
       public static List<LockTickOut>  getLockTick(LockTickIn pIn)
        {

            return null;
        }

        /// <summary>
        /// 锁票入参
        /// </summary>
        public class LockTickIn
        {
            /// <summary>
            /// 车次
            /// </summary>
            public string cheCi;
            /// <summary>
            /// 购票数量（每一交易只能购买同一车次多张车票）
            /// </summary>
            public int buyCount;
            /// <summary>
            /// 姓名（总代理机构名称）
            /// </summary>
            public string buyerName;
            /// <summary>
            /// 身份证号（总代理机构地址）
            /// </summary>
            public string idCardNumber;
            /// <summary>
            /// 电话（总代理机构联系电话）
            /// </summary>
            public string phoneNumber;
        }
        /// <summary>
        /// 锁票返回参数
        /// </summary>
        public class LockTickOut
        {
            /// <summary>
            /// 车次
            /// </summary>
            public string rv_0;
            /// <summary>
            /// 发车日期
            /// </summary>
            public string rv_1;
            /// <summary>
            /// 发车时间
            /// </summary>
            public string rv_2;
            /// <summary>
            /// 起点站
            /// </summary>
            public string rv_3;
            /// <summary>
            /// 检票口
            /// </summary>
            public string rv_4;
            /// <summary>
            /// 座位号
            /// </summary>
            public string rv_5;
            /// <summary>
            /// 到达站
            /// </summary>
            public string rv_6;
            /// <summary>
            /// 票价
            /// </summary>
            public string rv_7;
            /// <summary>
            /// 附加费
            /// </summary>
            public string rv_8;
            /// <summary>
            /// 里程数
            /// </summary>
            public string rv_9;
            /// <summary>
            /// 车型
            /// </summary>
            public string rv_10;

        }
    }
}
