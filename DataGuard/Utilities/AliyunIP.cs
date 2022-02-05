using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;

namespace DataGuard.Utilities
{
    public class AliyunIP
    {
        private const String host = "https://api01.aliyun.venuscn.com";
        private const String path = "/ip";
        private const String method = "GET";
        private const String appcode = "a0e7ca2b59fc4e4595489e8580f5d24d";



        /// <summary>
        /// 返回如下：JSON
        /// {"data":{"area":"华南","city":"深圳","city_id":"440300","country":"中国","country_id":"CN","ip":"113.87.188.238","isp":"电信","long_ip":"1901575406","region":"广东","region_id":"440000"},"log_id":"B47EDF0B-18CB-4BD1-9422-5762674AF826","msg":"success","ret":200}
        /// </summary>
        /// <param name="queryIP"></param>
        /// <returns></returns>
        public static string IpQuery(string queryIP)
        {
            String querys = "ip=" + queryIP;
            String bodys = "";
            String url = host + path;
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (host.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }
            Stream st = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));

            string getQueryResult = reader.ReadToEnd();
            JObject jo = JObject.Parse(getQueryResult);
            string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                if (string.IsNullOrEmpty(values[i]))
                {
                    values[i] = "0";
                }
                if (values[i].Contains("127.0.0.1"))
                {
                    return "local";
                }
            }
            JavaScriptSerializer ss = new JavaScriptSerializer();
            SourceAreaName sourceAreaName = ss.Deserialize<SourceAreaName>(values[0]);
            return string.Format("{0}{1}{2} {3}{4} {5}", sourceAreaName.country, sourceAreaName.area, sourceAreaName.county, sourceAreaName.region, sourceAreaName.city, sourceAreaName.isp);
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
    public struct Qryresult
    {
        public string code;
        public string data;
        public SourceAreaName sourceAreaName;
    }
    public struct SourceAreaName
    {
        public string area;
        public string area_id;
        public string city;
        public string city_id;
        public string country;
        public string country_id;
        public string county;
        public string county_id;
        public string ip;
        public string isp;
        public string isp_id;
        public string region;
        public string region_id;
    }
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string area_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city_id { get; set; }
        /// <summary>
        /// 香港
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string county { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string county_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isp_id { get; set; }
        /// <summary>
        /// 香港特别行政区
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region_id { get; set; }
    }
}
