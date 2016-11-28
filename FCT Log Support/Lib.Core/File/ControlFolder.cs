using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public class ControlFolder
    {
        // Methods
        public static void F_CreateFile(string i_TargetPath)
        {
            if (!Directory.Exists(i_TargetPath))
            {
                Directory.CreateDirectory(i_TargetPath);
            }
        }

        public static void F_DeleteFolder(string i_Fullpath)
        {
            new DirectoryInfo(i_Fullpath).Delete(true);
        }
    }



}
