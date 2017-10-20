using System;
using System.Threading;
using System.Windows.Forms;
using UMC.PVS.USERS;

namespace NichiconSystem
{
    static class Program
    {
        public static USERS CurrentUser { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CurrentUser = new USERS();

            bool ownmutex;
            // Tạo và lấy quyền sở hữu một Mutex có tên là Icon;
            using (var mutex = new Mutex(true, "NichiconSytem", out ownmutex))
            {
                // Nếu ứng dụng sở hữu Mutex, nó có thể tiếp tục thực thi;
                // nếu không, ứng dụng sẽ thoát.
                if (ownmutex)
                {
                    Application.Run(new FormLogin());
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.ExitThread();
            }
        }
    }
}
