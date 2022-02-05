using Common;
using Newtonsoft.Json;
using StarGateway.ModelApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.GateWay
{
    public class CWRG
    {
        const string sHostName = "https://cwrg.cic.hk";
        public string TimeStamp = String.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now.AddYears(-5));
        private static GatewayConfig _config;
        public static GatewayConfig Config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
            }
        }

        public CWRG()
        { 
            GatewayConfig config1 = new GatewayConfig(); 
            _config = config1;
            if (config1.TokenExpiryDate< DateTime.Now)
            {
                RefreshToken refreshToken = RefreshTokenWhenExpire();
                if(refreshToken!=null)
                {
                    config1.Token = refreshToken.Token;
                    config1.RefreshToken = refreshToken.Token;
                    config1.TokenExpiryDate = refreshToken.TokenExpiryDate;
                    config1.Save(config1);
                }
            } 
        }
        public GatewayConfig GetConfig()
        {
            return _config;
        }
        public ReturnTokenObj InitializeSecurityToken()
        { 
            if (Config.TokenExpiryDate > DateTime.Now)
            {
                ReturnTokenObj returnTokenObj = new ReturnTokenObj
                {
                    Roles = Config.Roles,
                    ContractorId = Config.ContractorId,
                    Token = Config.Token,
                    Name = Config.Name,
                    AccountId = Config.Account
                };
                return returnTokenObj;
            }
            string sRequestURIString = "{0}/api/integration/SecurityToken";
            sRequestURIString = string.Format(sRequestURIString, sHostName);
            try
            {
                const string quote = "\"";
                 
                // Create a request using a URL that can receive a post. 
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(sRequestURIString);

                // Set the Method property of the request to POST.
                webRequest.Method = "POST";
                webRequest.KeepAlive = false;
                webRequest.ProtocolVersion = HttpVersion.Version11;
                // Create POST data and convert it to a byte array.
                string postData = "{" + quote + "Login" + quote + ":" + quote + Config.Account + quote + "," + quote + "Password" + quote + ":" + quote + Config.Password + quote + "}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                webRequest.ContentType = "application/json; charset=UTF-8";
                // Set the ContentLength property of the WebRequest.
                webRequest.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = webRequest.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                responseFromServer = responseFromServer.Replace("[", "");
                responseFromServer = responseFromServer.Replace("]", "");

                ReturnTokenObj returnTokenObj = JsonConvert.DeserializeObject<ReturnTokenObj>(responseFromServer);

                //------------------------------------------------------------------------------------------------
                Config.ContractorId = returnTokenObj.ContractorId;
                Config.Roles = returnTokenObj.Roles;
                Config.Token = returnTokenObj.Token;
                Config.Name = returnTokenObj.Name;
                Config.TokenExpiryDate = returnTokenObj.TokenExpiryDate;
                Config.Save(Config);

                return returnTokenObj; 
            }
            catch (Exception ex)
            {
                string LoggerLine = string.Format("[ERROR] [Exception Caught!] [Get ReturnTokenObj FAIL][{0}][{1}]", sRequestURIString, ex.Message);
                CommonBase.OperateDateLoger(LoggerLine);
                return null;
            }
        }
        public RefreshToken RefreshTokenWhenExpire()
        {
            try
            {
                string sRequestURIString = "{0}/api/integration/RefreshToken";
                sRequestURIString = string.Format(sRequestURIString, sHostName);

                // Create a request using a URL that can receive a post. 
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(sRequestURIString);

                // Set the Method property of the request to POST.
                webRequest.Method = "POST";
                webRequest.KeepAlive = false;
                webRequest.ProtocolVersion = HttpVersion.Version11;
                webRequest.Headers.Add("Authorization", "Bearer " + Config.Token);
                // Create POST data and convert it to a byte array.
                string postData = "{\"token\":\"" + Config.Token + "\"}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the 'ContentType' property of the WebRequest.
                webRequest.ContentType = "application/json; charset=UTF-8";
                // Set the 'ContentLength' property of the WebRequest.
                webRequest.ContentLength = byteArray.Length;
                // Gets a Stream object to use to write request data.
                Stream dataStream = webRequest.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close(); 

                var refreshToken = JsonConvert.DeserializeObject<RefreshToken>(responseFromServer);

                return refreshToken;

            }
            catch (Exception ex)
            {
                CommonBase.OperateDateLoger(string.Format("[FUN::RefreshToken {0} [EXCEPTION]]", ex.Message));
                return null;
            }
        }
         
        public List<Contract> GetContractNoByAccount()
        {
            try
            {
                string sRequestURIString = "{0}/api/integration/Account/Contracts";
                sRequestURIString = string.Format(sRequestURIString, sHostName);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(sRequestURIString);
                string responseFromServer;
                webRequest.Method = "GET";
                webRequest.KeepAlive = false;
                webRequest.ProtocolVersion = HttpVersion.Version11;
                webRequest.Headers.Add("Authorization", string.Format("Bearer {0}", Config.Token));

                webRequest.ContentType = "application/json; charset=UTF-8";
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    // Gets a Stream object to use to write request data.
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        responseFromServer = reader.ReadToEnd();
                    }
                } 
                List<Contract> contracts = JsonConvert.DeserializeObject<List<Contract>>(responseFromServer); 
                return contracts;
            }
            catch (Exception ex)
            {
                CommonBase.OperateDateLoger(string.Format("[FUN::GetContractNoByAccount {0} [EXCEPTION]]", ex.Message));
                return null;
            }
        }

        public List<GoodList> GetGoodList(string sContractID,string TimeStamp1)
        {
            string GoodListUrlApi = "{0}/api/integration/contract/{1}/deltaTimestamp/{2}/goodlists";
            GoodListUrlApi = string.Format(GoodListUrlApi, sHostName, sContractID, TimeStamp1);//

            using (var client = new HttpClient())
            { 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.Token);
                string responseBody = string.Empty;
                try
                {
                    HttpResponseMessage response = client.GetAsync(GoodListUrlApi).Result;
                    response.EnsureSuccessStatusCode();
                    responseBody = response.Content.ReadAsStringAsync().Result;
                    List<GoodList> goodLists = JsonConvert.DeserializeObject<List<GoodList>>(responseBody);
                    return goodLists;
                }
                catch (Exception ex)
                {
                    string LoggerLine = string.Format("[ERROR] [Exception Caught!] [GetGoodList][{0}]", GoodListUrlApi);
                    CommonBase.OperateDateLoger(LoggerLine, ex.Message);
                    return null;
                }
            }

        } 
    }
}
