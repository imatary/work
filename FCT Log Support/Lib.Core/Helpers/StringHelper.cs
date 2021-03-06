﻿using System.Diagnostics;
using System.Reflection;
using System.Deployment.Application;
using System;

namespace Lib.Core.Helpers
{
    public static class StringHelper
    {
        public static string GetCurentAssemblyVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            return fvi.FileVersion;
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

        private static Version GetRunningCurentVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmptyOrNull(string value)
        {
            if(string.IsNullOrEmpty(value) || value == "" || value.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}
