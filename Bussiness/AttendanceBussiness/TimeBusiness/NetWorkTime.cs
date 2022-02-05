using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace AttendanceBussiness.NetWorkTime
{
    /// <summary>  
    /// 网络时间  
    /// </summary>  
    public class InterNetTime
    {
        public static bool GetInternetTime(out DateTime machineTime, out DateTime internetTime, bool isUpdateTime)
        {
            machineTime = DateTime.Now;
            bool result;
            try
            {
                machineTime = DateTime.Now;
                internetTime = AliyunInterNetTime();
                if (isUpdateTime) isUpdateTime = UpdateTime.SetDate(internetTime);
                result = true;
                return result;
            }
            catch(Exception ex)
            {
                isUpdateTime = false;
                result = false;
                internetTime = DateTime.Now;  
                Console.WriteLine("\nMachineTime {0:yyyy-MM-dd HH:mm:ss fff} {1} GetInter...Time() isUpdateTime = {2}", internetTime, ex.Message.Length, isUpdateTime); 
                return result;
            }
        }
        /// <summary>
        /// time.windows.com | 國家授時中心 ntp.ntsc.ac.cn
        /// </summary>
        /// <param name="url">time.windows.com</param>
        /// <param name="dtResult"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns> 
        public static bool GetInternetTime2(out DateTime machineTime, out DateTime dtResult)
        {
            machineTime = DateTime.Now;
            string timeServer = string.Empty;
            //建立IPAddress对象与端口，创建IPEndPoint节点:
            int port = 13;
            string[] whost = { "time-nw.nist.gov", "time-a.nist.gov", "time-b.nist.gov","time.windows.com", "tick.mit.edu","clock.sgi.com" };
            IPHostEntry iphostinfo;
            IPAddress ip;
            IPEndPoint ipe;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveTimeout = 10 * 1000;
            string sEX = "";

            foreach (string strHost in whost)
            {
                try
                {
                    iphostinfo = Dns.GetHostEntry(strHost);
                    ip = iphostinfo.AddressList[0];
                    ipe = new IPEndPoint(ip, port);

                    machineTime = DateTime.Now;
                    socket.Connect(ipe);
                    if (socket.Connected)
                    {
                        timeServer = strHost; 
                        break;
                    } 
                }
                catch (Exception ex)
                {
                    sEX = ex.Message;
                }
            }

            if (!socket.Connected)
            {
                Console.WriteLine("InterNet TimeServer Connected Fail！" + sEX);
                machineTime = DateTime.Now;
                dtResult = DateTime.Now;
                return false;
            }

            //SOCKET同步接受数据
            byte[] RecvBuffer = new byte[1024];
            int nBytes, nTotalBytes = 0;
            StringBuilder sb = new StringBuilder();
            System.Text.Encoding myE = Encoding.UTF8;

            while ((nBytes = socket.Receive(RecvBuffer, 0, 1024, SocketFlags.None)) > 0)
            {
                nTotalBytes += nBytes;
                sb.Append(myE.GetString(RecvBuffer, 0, nBytes));
            }
            socket.Close();
            try
            {
                string[] o = sb.ToString().Split(' ');

                Console.WriteLine("Raw result :{0}", sb.ToString());

                TimeSpan elapsedTime = new TimeSpan();
                elapsedTime = DateTime.Now.Subtract(machineTime);

                DateTime SetDT = Convert.ToDateTime(o[1] + " " + o[2]).Subtract(-elapsedTime);// 减去中途消耗的时间

                //Time Zone +8
                dtResult = SetDT.AddHours(8);
                Console.WriteLine("Time Sychronized ", "{0} from : {1}", dtResult, timeServer);
                return true;
            }catch(Exception ex)
            {
                dtResult =DateTime.Now;
                Console.WriteLine("Time Sychronize Fail from : {0} {1}",timeServer,ex.Message);
                return false;
            }
            
        } 
        [ComVisibleAttribute(true)]
        public static void AcceptCallback(IAsyncResult iar)
        {
            //还原传入的原始套接字
            Socket MyServer = (Socket)iar.AsyncState;
            //在原始套接字上调用EndAccept方法，返回新的套接字
            Socket service = MyServer.EndAccept(iar);
        }

        public static bool InterNetTimeCheck(bool result,DateTime machineTime, DateTime interNetTime) 
        {
            bool auth = false;
            if (result)
            {
                TimeSpan timeSpan = interNetTime.Subtract(machineTime);
                if (timeSpan.TotalSeconds < 30)
                {
                    auth = true;
                }
                else
                {
                    auth = false;
                    Console.WriteLine("\n>>> [Please input password to time authorize:]");
                    if (Console.ReadLine() == string.Format("{0:yyyyMMdd}", DateTime.Now))
                    {
                        auth = true;
                    }
                    else
                    {
                        Console.WriteLine("\n>>> [Sorry,not correct password！]");
                        System.Diagnostics.Process.GetCurrentProcess().Kill(); //Application.Exit();
                    }
                }
            }else
            {
                Console.WriteLine("\n>>> [Please input password time authorzie:]");
                if (Console.ReadLine() == string.Format("{0:yyyyMMdd}", DateTime.Now))
                {
                    auth = true;
                }
                else
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill(); //Application.Exit();
                }
            }
           

            return auth;
        }

        #region ALIYUN
        public static DateTime AliyunInterNetTime(string ntpServer = "ntp1.aliyun.com")
        { 
            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];
            // Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; // LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;
            // The UDP port number assigned to NTP is 123
            IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123);

            // NTP uses UDP
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(ipEndPoint);
            // Stops code hang if NTP is blocked
            socket.ReceiveTimeout = 3000;
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            // Offset to get to the "Transmit Timestamp" field (time at which the reply 
            // departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;
            // Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
            // Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
            // Convert From big-endian to little-endian
            intPart = SwapEndian(intPart);
            fractPart = SwapEndian(fractPart);
            ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000UL);

            // UTC time
            DateTime webTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(milliseconds);
            // Local time
            return webTime.ToLocalTime();
        } 
        /// <summary>
        /// 小端存储与大端存储的转换
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static uint SwapEndian(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
            ((x & 0x0000ff00) << 8) +
            ((x & 0x00ff0000) >> 8) +
            ((x & 0xff000000) >> 24));
        }  
        #endregion
    }

    /// <summary>
    /// 更新系统时间
    /// </summary>
    public  class UpdateTime
    {
        //设置系统时间的API函数
        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }

        /// <summary>
        /// 设置系统时间
        /// </summary>
        /// <param name="dt">需要设置的时间</param>
        /// <returns>返回系统时间设置状态，true为成功，false为失败</returns>
        public static bool SetDate(DateTime dt)
        {
            SYSTEMTIME st;

            st.year = (short)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.milliseconds = (short)dt.Millisecond;
            bool rt = SetLocalTime(ref st);
            return rt;
        }
    }
    public class Sssss
    {
        public static void SetInternetTime()
        { 
            DateTime startDT = DateTime.Now; 
            //建立IPAddress对象与端口，创建IPEndPoint节点:
            int port = 13;
            string[] whost = { "5time.nist.gov", "time-nw.nist.gov", "time-a.nist.gov", "time-b.nist.gov", "tick.mit.edu", "time.windows.com", "clock.sgi.com" };
            IPHostEntry iphostinfo;
            IPAddress ip;
            IPEndPoint ipe;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            socket.ReceiveTimeout = 10 * 1000;  
            string sEX = ""; 
             
            foreach (string strHost in whost)
            {
                try
                {
                    iphostinfo = Dns.GetHostEntry(strHost);
                    ip = iphostinfo.AddressList[0];
                    ipe = new IPEndPoint(ip, port); 

                    socket.Connect(ipe); 
                    if (socket.Connected) break; 
                }
                catch (Exception ex)
                {
                    sEX = ex.Message;
                }
            }

            if (!socket.Connected)
            {
                Console.WriteLine("Time Server connected Fail！" + sEX );
                return;
            }

            //SOCKET同步接受数据
            byte[] RecvBuffer = new byte[1024];
            int nBytes, nTotalBytes = 0;
            StringBuilder sb = new StringBuilder();
            System.Text.Encoding myE = Encoding.UTF8;

            while ((nBytes = socket.Receive(RecvBuffer, 0, 1024, SocketFlags.None)) > 0)
            {
                nTotalBytes += nBytes;
                sb.Append(myE.GetString(RecvBuffer, 0, nBytes));
            }  
            socket.Close();

            string[] o = sb.ToString().Split(' '); 
             
            Console.WriteLine(sb.ToString());

            TimeSpan k = new TimeSpan();
            k = (TimeSpan)(DateTime.Now - startDT);// 得到开始到现在所消耗的时间

            DateTime SetDT = Convert.ToDateTime(o[1] + " " + o[2]).Subtract(-k);// 减去中途消耗的时间

            //处置北京时间 +8时
            SetDT = SetDT.AddHours(8);  
            Console.WriteLine("Time Synchronized", "{0}" , SetDT); 
        }
    }
}



