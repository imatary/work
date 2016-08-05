using Lib.Data;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GARecruitmentSystem
{
    static class Program
    {
        public static User CurentUser { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CurentUser = new User();

            bool ownmutex;

            // Tạo và lấy quyền sở hữu một Mutex có tên là Icon;
            using (var mutex = new Mutex(true, "GA Recruitment", out ownmutex))
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
