using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public class ControlDataSQL
    {
        // Fields
        private static SqlCommand v_SqlCommand;
        private static SqlConnection v_SqlConnection;
        private static SqlDataAdapter v_SqlDataAdapter;

        // Methods
        public static int F_ExecuteSQL(string i_ConnectionString, string i_SQLComm)
        {
            int num = 0;
            v_SqlConnection = new SqlConnection(i_ConnectionString);
            v_SqlCommand = new SqlCommand(i_SQLComm, v_SqlConnection);
            v_SqlConnection.Open();
            num = v_SqlCommand.ExecuteNonQuery();
            v_SqlConnection.Close();
            return num;
        }

        public static DataTable F_ExecuteSQLToDataTable(string i_ConnectionString, string i_SQLComm)
        {
            DataTable dataTable = new DataTable();
            v_SqlConnection = new SqlConnection(i_ConnectionString);
            v_SqlCommand = new SqlCommand(i_SQLComm, v_SqlConnection);
            v_SqlConnection.Open();
            v_SqlDataAdapter = new SqlDataAdapter(i_SQLComm, i_ConnectionString);
            v_SqlDataAdapter.Fill(dataTable);
            v_SqlConnection.Close();
            return dataTable;
        }
    }



}
