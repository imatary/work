using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Mango_CTMS
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
            using (var mutex = new Mutex(true, "Mango CTMS - Log for MES System", out ownmutex))
            {
                // Nếu ứng dụng sở hữu Mutex, nó có thể tiếp tục thực thi;
                // nếu không, ứng dụng sẽ thoát.
                if (ownmutex)
                {
                    if (CheckConnection())
                    {
                        Application.Run(new FormMain());
                    }
                    else
                    {
                        string message = "Mất kết nối đến máy chủ. Vui lòng kiểm tra lại dây mạng, hoặc bạn có thể liên hệ cho phòng IT để được trợ giúp!";
                        Application.Run(new FormError(message));
                    }
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.ExitThread();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool CheckConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MESSystemDbContext"].ConnectionString; ;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
