using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public class ControlFile
    {
        // Methods
        public static void F_CreateAndWriteFile(string i_Fullpath, string i_Content)
        {
            if (!File.Exists(i_Fullpath))
            {
                using (File.Create(i_Fullpath))
                {
                }
                using (StreamWriter writer = new StreamWriter(i_Fullpath))
                {
                    writer.Write(i_Content);
                }
            }
        }

        public static void F_CreateFile(string i_Fullpath)
        {
            if (!File.Exists(i_Fullpath))
            {
                using (File.Create(i_Fullpath))
                {
                }
            }
        }

        public static void F_DeleteFile(string i_Fullpath)
        {
            if (File.Exists(i_Fullpath))
            {
                File.Delete(i_Fullpath);
            }
        }

        public static string F_ReadFile(string i_Fullpath)
        {
            string str = string.Empty;
            if (!File.Exists(i_Fullpath))
            {
                return str;
            }
            using (TextReader reader = new StreamReader(i_Fullpath))
            {
                return (str + reader.ReadLine());
            }
        }

        public static void F_WriteFile(string i_Fullpath, string i_Content)
        {
            if (File.Exists(i_Fullpath))
            {
                using (StreamWriter writer = new StreamWriter(i_Fullpath))
                {
                    writer.Write(i_Content);
                }
            }
        }
    }
}
