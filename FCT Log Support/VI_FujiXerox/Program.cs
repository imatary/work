using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UMC.Entities;

namespace VI_FujiXerox
{
    static class Program
    {
        public static Login CurrentUser { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
