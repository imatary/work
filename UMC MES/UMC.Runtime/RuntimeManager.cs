using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;

namespace UMC.Runtime
{
    public static class RuntimeManager
    {
        // Fields
        private static readonly Dictionary<string, Type> _Assembly_Providers_ = new Dictionary<string, Type>();
        private static readonly Dictionary<string, Assembly> _Loaded_Assemblies_ = new Dictionary<string, Assembly>();
        private const string _PLATFORM = "PC";
        private static readonly Dictionary<string, Assembly> _Resolved_Assemblies_ = new Dictionary<string, Assembly>();

        // Methods
        private static Type GetAssemblyProvider(string name)
        {
            Type type;
            _Assembly_Providers_.TryGetValue(name, out type);
            return type;
        }

        private static Exception GetInnerException(Exception error)
        {
            if (error == null)
            {
                return null;
            }
            if (error.InnerException != null)
            {
                return GetInnerException(error.InnerException);
            }
            return error;
        }

        public static Assembly GetLoadedAssembly(string name)
        {
            Assembly assembly;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("invalid assembly name!");
            }
            _Loaded_Assemblies_.TryGetValue(name, out assembly);
            return assembly;
        }

        private static IModuleLoader GetModuleLoader(Assembly assembly)
        {
            ModuleLoaderAttribute attribute =
                Attribute.GetCustomAttribute(assembly, typeof (ModuleLoaderAttribute), false) as ModuleLoaderAttribute;
            if ((attribute != null) && (attribute.Type != null))
            {
                return (Activator.CreateInstance(attribute.Type) as IModuleLoader);
            }
            return null;
        }

        private static string GetStartupPath()
        {
            return Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
        }

        private static void HandleAssemblyException(Exception error)
        {
            try
            {
                HandleAssemblyExceptionCore(error);
            }
            catch
            {
            }
            Environment.Exit(0);
        }

        private static void HandleAssemblyExceptionCore(Exception error)
        {
            StringBuilder builder = new StringBuilder();
            if (error != null)
            {
                error = GetInnerException(error);
                builder.AppendFormat("{0}\t{1}\t{2}", DateTime.Now, error.Message, error.StackTrace);
            }
            else
            {
                builder.AppendFormat("{0}\tunknown error", DateTime.Now);
            }
            WriteErrorLog(builder.ToString());
        }

        public static void Initialize()
        {
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(RuntimeManager.OnHandleAssemblyException);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(RuntimeManager.OnResolveAssembly);
            AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(RuntimeManager.OnLoadAssembly);
            LoadAssemblies();
        }

        private static void LoadAssemblies()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                LoadAssembly(assembly);
            }
            string startupPath = GetStartupPath();
            if (!string.IsNullOrEmpty(startupPath) && Directory.Exists(startupPath))
            {
                List<string> list = new List<string>();
                string[] files = Directory.GetFiles(startupPath, "*.exe");
                list.AddRange(files);
                files = Directory.GetFiles(startupPath, "*.dll");
                list.AddRange(files);
                for (int i = 0; i < list.Count; i++)
                {
                    string assemblyFile = list[i];
                    LoadAssembly(assemblyFile);
                }
            }
            LoadAssembly(typeof (int).Assembly);
            LoadAssembly(typeof (Uri).Assembly);
        }

        private static void LoadAssembly(Assembly assembly)
        {
            try
            {
                LoadAssemblyCore(assembly);
            }
            catch
            {
            }
        }

        private static void LoadAssembly(string assemblyFile)
        {
            try
            {
                LoadAssemblyCore(Assembly.LoadFrom(assemblyFile));
            }
            catch
            {
            }
        }

        private static void LoadAssemblyCore(Assembly assembly)
        {
            if (assembly != null)
            {
                string name = assembly.GetName().Name;
                if (!_Loaded_Assemblies_.ContainsKey(name))
                {
                    _Loaded_Assemblies_.Add(name, assembly);
                    IModuleLoader moduleLoader = GetModuleLoader(assembly);
                    if (moduleLoader != null)
                    {
                        moduleLoader.Run();
                    }
                }
            }
        }

        private static void OnHandleAssemblyException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleAssemblyException(e.ExceptionObject as Exception);
        }

        private static void OnLoadAssembly(object sender, AssemblyLoadEventArgs e)
        {
            LoadAssembly(e.LoadedAssembly);
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs e)
        {
            return ResolveAssembly(e.Name);
        }

        public static void RegisterAssemblyProvider<T>(string name)
        {
            RegisterAssemblyProvider(name, typeof (T));
        }

        public static void RegisterAssemblyProvider(string name, Type type)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("invalid assembly name!");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (_Assembly_Providers_.ContainsKey(name))
            {
                _Assembly_Providers_[name] = type;
            }
            else
            {
                _Assembly_Providers_.Add(name, type);
            }
        }

        private static Assembly ResolveAssembly(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return ResolveAssemblyCore(name);
                }
            }
            catch
            {
            }
            return null;
        }

        private static Assembly ResolveAssemblyCore(string name)
        {
            Assembly assembly;
            if (!_Resolved_Assemblies_.TryGetValue(name, out assembly))
            {
                Type assemblyProvider = GetAssemblyProvider(name);
                if (assemblyProvider != null)
                {
                    ResourceManager manager = new ResourceManager(assemblyProvider);
                    assembly = Assembly.Load((byte[]) manager.GetObject(name));
                }
                LoadAssembly(assembly);
                _Resolved_Assemblies_.Add(name, assembly);
            }
            return assembly;
        }

        private static void WriteErrorLog(string message)
        {
            using (
                FileStream stream =
                    File.Open(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "error.log"),
                        FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(message);
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        // Properties
        public static string Platform
        {
            get { return "PC"; }
        }
    }
}

