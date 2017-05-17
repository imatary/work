using System;
using System.Threading;
using System.Windows.Forms;

namespace FCT_Canon_Supports_MES
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool ownmutex;

            // Tạo và lấy quyền sở hữu một Mutex có tên là Icon;
            using (var mutex = new Mutex(true, "FCT-Canon-Supports-MES", out ownmutex))
            {
                // Nếu ứng dụng sở hữu Mutex, nó có thể tiếp tục thực thi;
                // nếu không, ứng dụng sẽ thoát.
                if (ownmutex)
                {
                    Application.Run(new FormMain());
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.ExitThread();
            }
        }
    }
}
