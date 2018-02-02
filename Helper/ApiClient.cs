using CchMis.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace WeChat.Helper
{
    public class ApiClient
    {
        public static string host = ConfigurationManager.AppSettings["WebApi"];

        public static string GetToken()
        {
            if (DateTime.Now.Hour < 23 && HttpContext.Current != null && HttpContext.Current.Application["token"] != null)
            {
                LogHelper.Info("ApiClient","GetToken:" + HttpContext.Current.Application["token"]);
                return HttpContext.Current.Application["token"].ToString();
            }
            string key = DateTime.Now.ToString("yyyy#MM#dd");
            string vcName =ConfigurationManager.AppSettings["vcName"];
            string token = Encryption.AESEncrypt(vcName, key);
            LogHelper.Info("ApiClient", "BuildNewToken：" + token);
            if (HttpContext.Current != null)
                HttpContext.Current.Application["token"] = token;
            return token;
        }
        /// <summary>
        /// 取新订单号。
        /// </summary>
        /// <returns></returns>
        public static string Usp_get_next_no()
        {
            return Invoke("Repository", "Usp_get_next_no", null, false);
        }
        /// <summary>
        /// 将一个实体对象写入数据库。
        /// </summary>
        /// <typeparam name="T">实体类型。</typeparam>
        /// <param name="t">实体对象实例。</param>
        /// <returns></returns>
        public static bool Insert<T>(ref T t) where T : class
        {
            string table = typeof(T).Name;
            string url = string.Format("{0}/{1}/Post", host, table);
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Token", GetToken());
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                client.Encoding = Encoding.UTF8;
                string json = JsonConvert.SerializeObject(t, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                string data = string.Format("data={0}", json);
                string res = client.UploadString(url, "POST", data);
                ResponseData<T> obj = JsonConvert.DeserializeObject<ResponseData<T>>(res);
                t = obj.data;
                return obj.success;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Update<T>(T t)
        {
            string table = typeof(T).Name;
            string url = string.Format("{0}/{1}/Put", host, table);
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Token", GetToken());
                string json = JsonConvert.SerializeObject(t, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                string data = string.Format("data={0}", json);
                string res = client.UploadString(url, "POST", data);
                ResponseData<T> obj = JsonConvert.DeserializeObject<ResponseData<T>>(res);
                return obj.success;
            }
        }
        /// <summary>
        /// 调用远程接口。
        /// </summary>
        /// <param name="className">类名。</param>
        /// <param name="methodName">方法名。</param>
        /// <param name="data">调用时提交的数据。</param>
        /// <param name="isJson">指示提交的数据是否为Json格式。</param>
        /// <returns></returns>
        public static string Invoke(string className, string methodName, object data, bool isJson = true)
        {
            string url = string.Format("{0}/SqlQuery/Execute/{1}/{2}", host, className, methodName);
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Token", GetToken());
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                client.Encoding = Encoding.UTF8;
                if (data == null)
                    return client.DownloadString(url);
                string json = null;
                if (isJson)
                    json = JsonConvert.SerializeObject(data, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                else
                    json = data.ToString();
                string postdata = string.Format("data={0}", json);
                string resString = client.UploadString(url, "POST", postdata);
                return resString;
            }
        }
        /// <summary>
        /// 调用远程接口。
        /// </summary>
        /// <param name="className">类名。</param>
        /// <param name="methodName">方法名。</param>
        /// <param name="data">调用时提交的数据。</param>
        /// <param name="isJson">指示提交的数据是否为Json格式。</param>
        /// <returns></returns>
        public static T Invoke<T>(string className, string methodName, object data, bool isJson = true)
        {
            string resString = Invoke(className, methodName, data, isJson);
            return JsonConvert.DeserializeObject<T>(resString);
        }
        public static MemberInfo GetMemberInfo(string openID)
        {
            return Get<MemberInfo>("/memberinfo/get/" + openID);
        }
        public static string Post(string url, Dictionary<string, object> data)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Token", GetToken());
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //string postdata = string.Format("token={0}{1}", GetToken(), GetParameter(data));
                string resString = client.UploadString(host + url, "POST", GetParameter(data));
                return resString;
            }
        }

        public static string Get(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Token", GetToken());
                return client.DownloadString(url);
            }
        }

        public static T GetList<T>(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Token", GetToken());
                string resString = client.DownloadString(url);
                return JsonConvert.DeserializeObject<T>(resString);
            }
        }

        public static T Get<T>(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Token", GetToken());
                ResponseData<T> d = JsonConvert.DeserializeObject<ResponseData<T>>(client.DownloadString(host + url));
                if (d.success)
                    return d.data;
                return default(T);
            }
        }
        public static T Post<T>(string url, Dictionary<string, object> dict)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Token", GetToken());
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string para = GetParameter(dict);
                byte[] postBytes = Encoding.UTF8.GetBytes(para);
                byte[] resBytes = client.UploadData(url, postBytes);
                string resString = Encoding.UTF8.GetString(resBytes);
                ResponseData<T> data = JsonConvert.DeserializeObject<ResponseData<T>>(resString);
                if (data.success)
                    return data.data;
                return default(T);
            }
        }
        private static string GetParameter(Dictionary<string, object> data)
        {
            StringBuilder text = new StringBuilder();
            foreach (var item in data)
            {
                text.Append(item.Key);
                text.Append("=");
                text.Append(item.Value);
                text.Append("&");
            }
            text = text.Remove(text.Length - 1, 1);
            return text.ToString();
        }
    }
    public class ResponseData<T>
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}