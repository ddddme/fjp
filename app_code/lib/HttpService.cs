using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
using App.FunctionLibrary;

namespace FlowRecharge.Wechat
{
    /// <summary>
    /// http连接基础类，负责底层的http通信
    /// </summary>
    public class HttpService
    {
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }

        public static string Post(string xml, string url, bool isUseCert, int timeout)
        {
            var result = "";//返回结果
            HttpWebRequest request = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;

                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = timeout * 1000;

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                var data = Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //是否使用证书
                if (isUseCert)
                {
                    var certFile = Filer.WorkPath + WxPayConfig.SSLCERT_PATH;
                    Log.WriteLog("CertificateFile:" + certFile + "\t Password:" + WxPayConfig.SSLCERT_PASSWORD);

                    var cert = new X509Certificate2(certFile, WxPayConfig.SSLCERT_PASSWORD, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                    Log.WriteLog("已创建证书:" + cert.Subject);

                    request.ClientCertificates.Add(cert);
                    Log.WriteLog("证书已追加到请求中 ...");
                }

                //往服务器写入数据
                using (var reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }

                //获取服务端返回
                using (var response = (HttpWebResponse)request.GetResponse())
                //获取服务端返回数据
                using (var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd().Trim();
                }
            }
            catch (ThreadAbortException e)
            {
                Log.WriteLog("Thread - caught ThreadAbortException - resetting.");
                Log.WriteLog(e.Message);
                Thread.ResetAbort();
            }
            catch (WebException e)
            {
                Log.WriteLog(e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Log.WriteLog("StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    Log.WriteLog("StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw new WxPayException(e.ToString());
            }
            catch (Exception e)
            {
                Log.WriteLog(e.Message);
                throw new WxPayException(e.ToString());
            }
            finally
            {
                //关闭连接和流 
                if (request != null)
                    request.Abort();
            }

            return result;
        }

        /// <summary>
        /// 处理http GET请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns>http GET成功后返回的数据，失败抛WebException异常</returns>
        public static string Get(string url)
        {
            var result = "";
            HttpWebRequest request = null;

            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;

                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                /***************************************************************
                * 下面设置HttpWebRequest的相关属性
                * ************************************************************/
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                //设置代理
                WebProxy proxy = new WebProxy();
                proxy.Address = new Uri(WxPayConfig.PROXY_URL);
                //request.Proxy = proxy;

                //获取服务器返回
                using (var response = (HttpWebResponse)request.GetResponse())
                //获取HTTP返回数据
                using (var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd().Trim();
                }
            }
            catch (ThreadAbortException e)
            {
                Log.WriteLog("Thread - caught ThreadAbortException - resetting.");
                Log.WriteLog(e.Message);
                Thread.ResetAbort();
            }
            catch (WebException e)
            {
                Log.WriteLog(new HttpService().ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Log.WriteLog("StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    Log.WriteLog("StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }

                throw new WxPayException(e.ToString());
            }
            catch (Exception e)
            {
                Log.WriteLog(e.Message);
                throw new WxPayException(e.ToString());
            }
            finally
            {
                if (request != null)
                    request.Abort();
            }

            return result;
        }
    }
}