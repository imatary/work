﻿using Microsoft.Win32;
using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NichiconSystem
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
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(TextBox control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                control.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(ComboBox control)
        {
            if (control.SelectedIndex < 0)
            {
                control.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="errorProvider"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(TextBox control, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(control, "Required field");
                control.Focus();
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorProvider"></param>
        public static void ClearError(ErrorProvider errorProvider)
        {
            errorProvider.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VI-NICHICON\Config");
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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VI-NICHION\Config");
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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VI-NICHICON\Config");
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

        /// <summary>
        /// create log
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        public static void CreateFileLog(string model, string productId, string status, string process, DateTime dateCheck)
        {
            string dateTime = dateCheck.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{model}_{productId}.txt";
            string folderRoot = $@"C:\LOGPROCESS\backup\{dateCheck.ToString("yyyyMMdd")}\";

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
    }
}
