using System;
using System.Threading;
using System.Windows.Forms;

namespace IndicateReport
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

            // Giá trị luận lý cho biết ứng dụng này
            // có quyền sở hữu Mutex hay không.
            bool ownmutex;

            // Tạo và lấy quyền sở hữu một Mutex có tên là Icon;
            using (var mutex = new Mutex(true, "Icon", out ownmutex))
            {
                // Nếu ứng dụng sở hữu Mutex, nó có thể tiếp tục thực thi;
                // nếu không, ứng dụng sẽ thoát.
                if (ownmutex)
                {
                    Application.Run(new Form1());
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.Exit();
            }
        }
    }
}
