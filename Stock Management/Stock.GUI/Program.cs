using System;
using System.Windows.Forms;
using Stock.Data;
using Stock.GUI.Forms;

namespace Stock.GUI
{
    static class Program
    {
        public static User CurrentUser { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CurrentUser = new User();
            Application.Run(new FormLogin());
        }
    }
}
