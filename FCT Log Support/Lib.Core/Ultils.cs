using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public static void CreateFileLog(string model, string productId, string status, string process)
        {
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{productId}.txt";
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
                    tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
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
    }
}
