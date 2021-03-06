﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AGPF_DADF_IBG
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
            using (var mutex = new Mutex(true, "AGPF_DADF_IBG", out ownmutex))
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
                        string errorMessage = "Không thể kết nối đến máy chủ. Vui lòng kiểm tra lại đường truyền mạng LAN, hoặc bạn có thể liên hệ với phòng IT để được trợ giúp !";
                        Application.Run(new FormError(errorMessage));
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
