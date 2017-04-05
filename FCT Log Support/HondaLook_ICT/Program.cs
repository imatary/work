using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HondaLook_ICT
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
            using (var mutex = new Mutex(true, "HondaLook_ICT_Supports_MES", out ownmutex))
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
                        MessageBox.Show("Lỗi kết nối đến máy chủ. Vui lòng kiểm tra lại dây mạng!");
                    }
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.ExitThread();
            }
        }


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
