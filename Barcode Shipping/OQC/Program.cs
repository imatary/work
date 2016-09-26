using System;
using System.Threading;
using System.Windows.Forms;
using BarcodeShipping.Data;

namespace OQC
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
            bool ownmutex;

            // Tạo và lấy quyền sở hữu một Mutex có tên là Icon;
            using (var mutex = new Mutex(true, "Schneider", out ownmutex))
            {
                // Nếu ứng dụng sở hữu Mutex, nó có thể tiếp tục thực thi;
                // nếu không, ứng dụng sẽ thoát.
                if (ownmutex)
                {
                    Application.Run(new FormQALogin());
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.ExitThread();
            }
        }
    }
}
