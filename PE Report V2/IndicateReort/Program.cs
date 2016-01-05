using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndicateReort
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
            // Application.Run(new FormLineCanon());
			
			// CurrentUser=new User();
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
                    // Application.Run(new FormLogin());
					Application.Run(new FormLogin());
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.Exit();
            } 
        }
    }
}
