using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace CPUNichiconSupportWIP
{
    public static class Ultils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isChecked"></param>
        /// <param name="executablePath"></param>
        public static void RegisterInStartup(bool isChecked, string executablePath)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", executablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="model"></param>
        /// <param name="productId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        public static void CreateFolderBackupLog(string fileName,string model, string productId, string status, string process)
        {
            string backup_log_folder = @"C:\backup_log\";
            bool exists = Directory.Exists(backup_log_folder);
            if (!exists)
                Directory.CreateDirectory(backup_log_folder);
        }



        /// <summary>
        /// create log
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        public static void CreateFileLog(string model, string productId, string status, string process, string dateCheck)
        {
            
            string fileName = $"{dateCheck}_{productId}.txt";
            string folderRoot = @"C:\LOGPROCESS\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateCheck}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateCheck}|{status}|{process}");
                    tw.Close();
                }
            }
        }

        /// <summary>
        /// Check process is runing
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRunning(string name)
        {
            return Process.GetProcessesByName(name).Length > 0 ? true : false;
        }

        /// <summary>
        /// Lấy thông tin ngày giờ từ server
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNetworkDateTime()
        {
            //default Windows time server
            //const string ntpServer = "time.windows.com"; //Internet
            const string ntpServer = "172.28.64.8";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);

            //Stops code hang if NTP is blocked
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public static void WriteFile(string content)
        {
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}.txt";
            string folderRoot = @"C:\text content\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (StreamWriter tw = new StreamWriter(fs))
                {
                    tw.WriteLine(content);
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (StreamWriter tw = new StreamWriter(fs))
                {
                    tw.WriteLine(content);
                    tw.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public static void WriteFile(string fileName, string content)
        {
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            var fullName = fileName + $"{dateTime}.txt";
            string folderRoot = @"C:\text content\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fullName;

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (StreamWriter tw = new StreamWriter(fs))
                    {
                        tw.WriteLine(content);
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (StreamWriter tw = new StreamWriter(fs))
                    {
                        tw.WriteLine(content);
                        tw.Close();
                    }
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetLine(StringBuilder fileName, int line)
        {
            //string line = fileName..Skip(14).Take(1).First();

            using (var sr = new StringReader(fileName.ToString()))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CPU-NICHICON-SUPPORTS-MES\Configs");
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                key.SetValue(keyName, content);
                key.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistryArray(string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CPU-NICHICON-SUPPORTS-MES\Configs");
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                string exitsValue = GetValueRegistryKey(keyName);
                if (exitsValue != null)
                {
                    exitsValue += content + ";";
                    key.SetValue(keyName, exitsValue);
                }
                else
                {
                    key.SetValue(keyName, content + ";");
                }
                key.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueRegistryKey(string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CPU-NICHICON-SUPPORTS-MES\Configs");
            string value = null;
            if (key != null)
            {
                if (key.GetValue(keyName) != null)
                {
                    value = key.GetValue(keyName).ToString();
                    key.Close();
                    return value;
                }
            }

            return null;
        }
    }
}
