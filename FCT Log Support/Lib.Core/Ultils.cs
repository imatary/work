using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lib.Core
{
    public static class Ultils
    {
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
        /// 
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="isOk"></param>
        public static void SuspendOrResumeCurentProcess(string processName, bool isOk=false)
        {
            var id = Process.GetProcessesByName(processName).FirstOrDefault();
            var process = Process.GetProcessById(id.Id);
            

            if (isOk == true)
            {
                process.Suspend();
            }
            else if (isOk == false)
            {
                process.Resume();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<string[]> ReadCsv(string path)
        {
            char[] separator = new[] { ',' };
            string currentLine;

            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream, Encoding.Default, true, 1024))
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        yield return currentLine.Split(separator, StringSplitOptions.None);
                    }
                    reader.Dispose();
                    reader.Close();
                }
                stream.Dispose();
                stream.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> ReadLogTxt(string path)
        {
            List<string> data = new List<string>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (line.Contains("PASS"))
                {
                    data.Add("PASS");
                }
                else if (line.Contains("FAIL"))
                {
                    data.Add("FAIL");
                }
            }
            return data;
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
    }
}
