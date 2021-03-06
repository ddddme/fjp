﻿using System;
using System.Web.UI;
using App.FunctionLibrary;
using System.IO;
using System.Web;

namespace FlowRecharge.Wechat
{
    public class Log
    {
        //在网站根目录下创建日志目录
        public static string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";

       /**
        * 实际的写日志操作
        * @param type 日志记录类型
        * @param className 类名
        * @param content 写入内容
        */
        public static void WriteLog(string type, string content="")
        {
            if (WxPayConfig.LOG_LEVENL < 3)
            {
                return;
            }
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //创建或打开日志文件，向日志文件末尾追加记录
            StreamWriter mySw = File.AppendText(filename);

            //向日志文件写入内容
            string write_content = time + " " + type + " : " + content;
            mySw.WriteLine("--------------------------");
            mySw.WriteLine(write_content);
            mySw.WriteLine("--------------------------");

            //关闭日志文件
            mySw.Close();
        }
    }
}