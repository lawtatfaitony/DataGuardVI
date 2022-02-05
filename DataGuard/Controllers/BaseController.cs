
using LanguageResource;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace DataGuard.Controllers
{
    public class BaseController : Controller
    {
        private DataGuard.Context.ApplicationDbContext db = new DataGuard.Context.ApplicationDbContext();

        public string SwitchLanguageCode(LangParamsType langParamsType)
        {
            switch (langParamsType)
            {
                case LangParamsType.Route:
                    string _language = RouteData.Values["Language"].ToString().Trim();
                    return _language;
                case LangParamsType.CultureUI:
                    return LangUtilities.LanguageCode;
                default:
                    return "en-US";
            }
        }

        public string DoPost(string url, string data)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            byte[] postData = Encoding.UTF8.GetBytes(data);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length); reqStream.Close();
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }
        public HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            req.ContentType = "text/json";
            req.Method = method;
            req.KeepAlive = true;
            req.Timeout = 1000000;
            req.Proxy = null;
            return req;
        }
        public string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            StringBuilder result = new StringBuilder();
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                // 每次读取不大于256个字符，并写入字符串
                char[] buffer = new char[256];
                int readBytes = 0;
                while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(buffer, 0, readBytes);
                }
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }

            return result.ToString();
        }

        public string ReadTxtContent(string Path)
        {
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            string line;
            string content = "";
            while ((line = sr.ReadLine()) != null)
            {
                // Console.WriteLine(line.ToString());
                content += sr.ReadLine();
            }

            return content;
        }
        public string SaveUrlImage(string UrlImage, string NewFileName, string SubPath)
        {
            if (string.IsNullOrEmpty(UrlImage))
            {
                return UrlImage;
            }
            string MediaRootPath = "Upload";
            string LocalPath = string.Format("/{0}/{1}", MediaRootPath, SubPath);
            if (!System.IO.Directory.Exists(LocalPath))
            {
                System.IO.Directory.CreateDirectory(LocalPath);
            }
            string FilePath = string.Format("/{0}/{1}/{2}", MediaRootPath, SubPath, NewFileName);
            string oFilePath = System.Web.HttpContext.Current.Server.MapPath(FilePath);
            Image Image1 = Image.FromStream(WebRequest.Create(UrlImage).GetResponse().GetResponseStream());
            Image1.Save(oFilePath, GetFormat(oFilePath));
            return FilePath;
        }
        //Get the corresponding storage type based on the file extension name
        public static ImageFormat GetFormat(string filePath)
        {
            ImageFormat format = ImageFormat.MemoryBmp;
            String Ext = System.IO.Path.GetExtension(filePath).ToLower();

            if (Ext.Equals(".png")) format = ImageFormat.Png;
            else if (Ext.Equals(".jpg") || Ext.Equals(".jpeg")) format = ImageFormat.Jpeg;
            else if (Ext.Equals(".bmp")) format = ImageFormat.Bmp;
            else if (Ext.Equals(".gif")) format = ImageFormat.Gif;
            else if (Ext.Equals(".ico")) format = ImageFormat.Icon;
            else if (Ext.Equals(".emf")) format = ImageFormat.Emf;
            else if (Ext.Equals(".exif")) format = ImageFormat.Exif;
            else if (Ext.Equals(".tiff")) format = ImageFormat.Tiff;
            else if (Ext.Equals(".wmf")) format = ImageFormat.Wmf;
            else if (Ext.Equals(".memorybmp")) format = ImageFormat.MemoryBmp;

            return format;
        }

    }
}