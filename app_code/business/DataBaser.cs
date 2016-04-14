using System;
using App.FunctionLibrary;
using Framework.Entity;

namespace FlowRecharge.Wechat.business
{
    /// <summary>
    /// 数据库工厂重写
    /// </summary>
    [Obsolete]
    public class DataBaser : AdoDotNet
    {
        [Obsolete]
        public DataBaser() : base(new ConnectionBuilder
        {
            DBType = DBType.SQLServer,
            DataSource = Configer.Find("DbServer", "url").Value,
            DataBase = Configer.Find("DbServer", "basename").Value,
            UserID = Configer.Find("DbServer", "uid").Value,
            Password = Configer.Find("DbServer", "pwd").Value,
        })
        { }
    }
}