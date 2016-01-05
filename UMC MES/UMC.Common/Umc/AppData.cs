using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Umc
{
    public static class AppData
    {
        // Fields
        private static string _Local_Path;
        private static readonly Dictionary<string, object> _Parameters_ = new Dictionary<string, object>();
        private static string _Product;
        private static Assembly _Startup_Assembly;
        private static string _Startup_File;
        private static string _Startup_Path;
        private static string _Version;

        // Methods
        public static void ClearParameters()
        {
            _Parameters_.Clear();
        }

        private static string GetLocalPath()
        {
            return (_Local_Path ?? (_Local_Path = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath));
        }

        public static object GetParameter(string name)
        {
            object obj2;
            if (string.IsNullOrEmpty(name))
            {
                throw Error.Argument("invalid parameter name!");
            }
            _Parameters_.TryGetValue(name, out obj2);
            return obj2;
        }

        public static TResult GetParameter<TResult>(string name)
        {
            object parameter = GetParameter(name);
            if (parameter is TResult)
            {
                return (TResult)parameter;
            }
            return default(TResult);
        }

        private static string GetProduct()
        {
            if (_Product == null)
            {
                AssemblyProductAttribute attribute = Attribute.GetCustomAttribute(GetStartupAssembly(), typeof(AssemblyProductAttribute), false) as AssemblyProductAttribute;
                _Product = (attribute != null) ? attribute.Product : string.Empty;
            }
            return _Product;
        }

        private static Assembly GetStartupAssembly()
        {
            return (_Startup_Assembly ?? (_Startup_Assembly = Assembly.GetEntryAssembly()));
        }

        private static string GetStartupFile()
        {
            return (_Startup_File ?? (_Startup_File = Path.Combine(GetStartupPath(), AppDomain.CurrentDomain.FriendlyName)));
        }

        private static string GetStartupPath()
        {
            return (_Startup_Path ?? (_Startup_Path = Path.GetDirectoryName(GetLocalPath())));
        }

        private static string GetVersion()
        {
            return (_Version ?? (_Version = GetStartupAssembly().GetName().Version.ToString()));
        }

        public static void SetParameter(string name, object value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw Error.Argument("invalid parameter name!");
            }
            _Parameters_.TrySetValue<string, object>(name, value);
        }

        // Properties
        public static string Product
        {
            get
            {
                return GetProduct();
            }
        }

        public static string StartupFile
        {
            get
            {
                return GetStartupFile();
            }
        }

        public static string StartupPath
        {
            get
            {
                return GetStartupPath();
            }
        }

        public static string Version
        {
            get
            {
                return GetVersion();
            }
        }
    }

}