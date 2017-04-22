using Microsoft.Win32;
using System;
using System.Deployment.Application;
using System.IO;
using System.Net;
using System.Reflection;

namespace Nichicon_ICT_Server_Supports_MES
{
    public static class Ultils
    {
        public static string GetIP()
        {
            String strHostName = Dns.GetHostName();
            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }

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

        public static string GetLine(string path, int line)
        {
            string value;
            using (var sr = new StreamReader(path))
            {
                for (int i = 1; i < line; i++)
                {
                    sr.ReadLine();
                }
                value = sr.ReadLine();
                sr.Dispose();
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ICT-NICHICON-SUPPORTS-MES\ServerConfig");
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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ICT-NICHICON-SUPPORTS-MES\ServerConfig");
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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ICT-NICHICON-SUPPORTS-MES\ServerConfig");
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
