using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace autoconf
{
    public class WebAutoLogin
    {
        #region 属性
        /// <summary>
        /// 登陆后返回的Html
        /// </summary>
        public static string ResultHtml
        {
            get;
            set;
        }
        /// <summary>
        /// 下一次请求的Url
        /// </summary>
        public static string NextRequestUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 若要从远程调用中获取COOKIE一定要为request设定一个CookieContainer用来装载返回的cookies
        /// </summary>
        public static CookieContainer CookieContainer
        {
            get;
            set;
        }
        /// <summary>
        /// Cookies 字符创
        /// </summary>
        public static string CookiesString
        {
            get;
            set;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 用户登陆指定的网站
        /// </summary>
        /// <param name="loginUrl"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public static bool PostLogin(string loginUrl, string login_authorization)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                string postdata = "group_id=&action_mode=&action_script=&action_wait=5&current_page=Main_Login.asp&next_page=Main_Login.asp&flag=&login_authorization=" + login_authorization;
                
                request = (HttpWebRequest)WebRequest.Create(loginUrl);//实例化web访问类  
                //request.Credentials = CredentialCache.DefaultCredentials;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                request.Method = "POST";//数据提交方式为POST  
                CookiesString = "tomato_menu_status=overview.asp; tomato_status_overview_refresh=3; wireless_list=<08:D8:33:8B:24:BB>No<54:E4:3A:5F:2D:33>No; dm_install=no; dm_enable=no; hwaddr=00:72:70:33:3D:00; traffic_warning_0=2015.5:1; nwmapRefreshTime=1435365353420; " + CookiesString;
                request.Headers.Add("Cookie:" + CookiesString);
                //request.ContentType = "application/x-www-form-urlencoded";    //模拟头  
                //request.AllowAutoRedirect = false;   // 不用需自动跳转
                //必须设置CookieContainer存储请求返回的Cookies
                if (CookieContainer != null)
                {
                    request.CookieContainer = CookieContainer;
                }
                else
                {
                    request.CookieContainer = new CookieContainer();
                    CookieContainer = request.CookieContainer;
                }
                request.KeepAlive = true;
                //提交请求  
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabytes.Length;
                Stream stream;
                stream = request.GetRequestStream();
                //设置POST 数据
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //接收响应  
                response = (HttpWebResponse)request.GetResponse();
                //保存返回cookie  
                CookieContainer = request.CookieContainer;
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                CookiesString = strcrook;
                //取下一次GET跳转地址  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                return true;
                //依据登陆成功后返回的Page信息，求出下次请求的url
                //每个网站登陆后加载的Url和顺序不尽相同，以下两步需根据实际情况做特殊处理，从而得到下次请求的URL
                //string[] substr = content.Split(new char[] { '\'' });

                //NextRequestUrl = "http://" + request.Headers["Host"].ToString() + substr[1];
            }
            catch (WebException ex)
            {
                CookiesString = "";
                request = null;
                response = null;
                GC.Collect();
                //MessageBox.Show(string.Format("登陆时出错，详细信息：{0}", ex.Message));
                return false;
            }
        }
        /// <summary>
        /// 获取用户登陆后请求页面返回的内容
        /// </summary>
        /// <param name="url">想要请求的页面地址</param>
        public static void GetPage(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                //request.Credentials = CredentialCache.DefaultCredentials;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                request.Method = "GET";
                request.Referer = url;
                request.KeepAlive = true;
                CookiesString = "tomato_menu_status=overview.asp; tomato_status_overview_refresh=3; wireless_list=<08:D8:33:8B:24:BB>No<54:E4:3A:5F:2D:33>No; dm_install=no; dm_enable=no; hwaddr=00:72:70:33:3D:00; traffic_warning_0=2015.5:1; nwmapRefreshTime=1435365353420; " + CookiesString;
                //request.Headers.Add("Cookie:" + CookiesString);
                request.Headers.Add("Cookie", CookiesString);
                //request.CookieContainer = CookieContainer;
                //request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                //设置cookie  
                //CookiesString = request.CookieContainer.GetCookieHeader(request.RequestUri);
                //取再次跳转链接  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string ss = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                ResultHtml = ss;
            }
            catch (WebException ex)
            {
                MessageBox.Show(string.Format("获取页面HTML信息出错，详细信息：{0}", ex.Message));
            }
        }
        /// <summary>
        /// 获取用户登陆后请求页面返回的内容
        /// </summary>
        /// <param name="url">想要请求的页面地址</param>
        public static void GetPage1(string url,string referer_url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                //request.Credentials = CredentialCache.DefaultCredentials;
                request.Accept = "*/*";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                request.Method = "GET";
                request.Referer = referer_url;
                request.KeepAlive = true;
                //CookiesString = @"tomato_menu_status=overview.asp; tomato_status_overview_refresh=3; wireless_list=<08:D8:33:8B:24:BB>No<54:E4:3A:5F:2D:33>No<74:E5:0B:D3:FD:AC>Yes<90:FD:61:72:D0:19>Yes; dm_install=no; dm_enable=no; hwaddr=00:72:70:33:3D:00; traffic_warning_0=2015.5:1; nwmapRefreshTime=1435500586749; " + CookiesString;
                //request.Headers.Add("Cookie:" + CookiesString);
                request.Headers.Add("Cookie", CookiesString);
                //request.CookieContainer = CookieContainer;
                //request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                //设置cookie  
                CookiesString = request.CookieContainer.GetCookieHeader(request.RequestUri);
                //取再次跳转链接  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string ss = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                //依据登陆成功后返回的Page信息，求出下次请求的url
                //每个网站登陆后加载的Url和顺序不尽相同，以下两步需根据实际情况做特殊处理，从而得到下次请求的URL
                //string[] substr = ss.Split(new char[] { '"' });
                //NextRequestUrl = substr[1];
                ResultHtml = ss;
            }
            catch (WebException ex)
            {
                MessageBox.Show(string.Format("获取页面HTML信息出错，详细信息：{0}", ex.Message));
            }
        }

        public static void PostSetSS(string loginUrl, string postdata)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            //try
            //{
                request = (HttpWebRequest)WebRequest.Create(loginUrl);//实例化web访问类  
                //request.Credentials = CredentialCache.DefaultCredentials;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                request.Method = "POST";//数据提交方式为POST  
                //CookiesString = "tomato_menu_status=overview.asp; tomato_status_overview_refresh=3; wireless_list=<08:D8:33:8B:24:BB>No<54:E4:3A:5F:2D:33>No; dm_install=no; dm_enable=no; hwaddr=00:72:70:33:3D:00; traffic_warning_0=2015.5:1; nwmapRefreshTime=1435365353420; " + CookiesString;
                request.Headers.Add("Cookie", CookiesString);
                //request.CookieContainer = CookieContainer;
                request.KeepAlive = true;
                //提交请求  
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabytes.Length;
                Stream stream;
                stream = request.GetRequestStream();
                //设置POST 数据
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //接收响应  
                response = (HttpWebResponse)request.GetResponse();
                //取下一次GET跳转地址  
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                request.Abort();
                response.Close();
                //依据登陆成功后返回的Page信息，求出下次请求的url
                //每个网站登陆后加载的Url和顺序不尽相同，以下两步需根据实际情况做特殊处理，从而得到下次请求的URL
                //string[] substr = content.Split(new char[] { '\'' });

                //NextRequestUrl = "http://" + request.Headers["Host"].ToString() + substr[1];
            //}
            //catch (WebException ex)
            //{
            //    MessageBox.Show(string.Format("登陆时出错，详细信息：{0}", ex.Message));
            //}
        }
        #endregion

       
    }
}
