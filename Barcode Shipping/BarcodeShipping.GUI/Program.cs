using System;
using System.Threading;
using System.Windows.Forms;
using BarcodeShipping.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BarcodeShipping.GUI
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
            using (var mutex = new Mutex(true, "Shipping FujiXerox", out ownmutex))
            {
                // Nếu ứng dụng sở hữu Mutex, nó có thể tiếp tục thực thi;
                // nếu không, ứng dụng sẽ thoát.
                if (ownmutex)
                {
                    if(CheckConnection())
                    {
                        Application.Run(new FormMainV2());
                    }
                    else
                    {
                        Application.Run(new FormError());
                    }
                    //giai phong Mutex;
                    mutex.ReleaseMutex();
                }
                else
                    Application.ExitThread();
            }
        }

        /// <summary>
        /// Kiểm tra kết nối đến server
        /// </summary>
        /// <returns></returns>
        private static bool CheckConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShippingFujiXeroxDbContext"].ConnectionString;

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
