using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace OQC
{
    public partial class WatcherApplication : Form
    {
        private int changeCount = 0;

        private const string tableName = "tbl_test_log";
        private const string statusMessage = "{0} changes have occurred.";

        // The following objects are reused
        // for the lifetime of the application.
        private DataSet dataToWatch = null;
        private SqlConnection connection = null;
        private SqlCommand command = null;

        public WatcherApplication()
        {
            InitializeComponent();
        }


        private bool CanRequestNotifications()
        {
            // In order to use the callback feature of the
            // SqlDependency, the application must have
            // the SqlClientPermission permission.
            try
            {
                SqlClientPermission perm =
                    new SqlClientPermission(
                    PermissionState.Unrestricted);

                perm.Demand();

                return true;
            }
            catch
            {
                return false;
            }
        }


        private void WatcherApplication_Load(object sender, EventArgs e)
        {
            button1.Enabled = CanRequestNotifications();
        }

        private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrive it from a configuration file.
            return @"data source=172.28.10.25\QA;initial catalog=barcode_db;user id=sa;password=$umcevn123";
        }

        private string GetSQL()
        {
            return "SELECT COUNT(*)  FROM[barcode_db].[dbo].[tbl_test_log]";
        }

        private void dependency_OnChange(
   object sender, SqlNotificationEventArgs e)
        {
            // This event will occur on a thread pool thread.
            // Updating the UI from a worker thread is not permitted.
            // The following code checks to see if it is safe to
            // update the UI.
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;

            // If InvokeRequired returns True, the code
            // is executing on a worker thread.
            if (i.InvokeRequired)
            {
                // Create a delegate to perform the thread switch.
                OnChangeEventHandler tempDelegate =
                    new OnChangeEventHandler(dependency_OnChange);

                object[] args = { sender, e };

                // Marshal the data from the worker thread
                // to the UI thread.
                i.BeginInvoke(tempDelegate, args);

                return;
            }

            // Remove the handler, since it is only good
            // for a single notification.
            SqlDependency dependency =
                (SqlDependency)sender;

            dependency.OnChange -= dependency_OnChange;

            // At this point, the code is executing on the
            // UI thread, so it is safe to update the UI.
            ++changeCount;
            label1.Text = String.Format(statusMessage, changeCount);

            // Add information from the event arguments to the list box
            // for debugging purposes only.
            listBox1.Items.Clear();
            listBox1.Items.Add("Info:   " + e.Info.ToString());
            listBox1.Items.Add("Source: " + e.Source.ToString());
            listBox1.Items.Add("Type:   " + e.Type.ToString());

            // Reload the dataset that is bound to the grid.
            GetData();
        }

        private void GetData()
        {
            // Empty the dataset so that there is only
            // one batch of data displayed.
            dataToWatch.Clear();

            // Make sure the command object does not already have
            // a notification object associated with it.
            command.Notification = null;

            // Create and bind the SqlDependency object
            // to the command object.
            SqlDependency dependency =
                new SqlDependency(command);
            dependency.OnChange += new
                OnChangeEventHandler(dependency_OnChange);

            using (SqlDataAdapter adapter =
                new SqlDataAdapter(command))
            {
                adapter.Fill(dataToWatch, tableName);

                dataGridView1.DataSource = dataToWatch;
                dataGridView1.DataMember = tableName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeCount = 0;
            label1.Text = String.Format(statusMessage, changeCount);

            // Remove any existing dependency connection, then create a new one.
            SqlDependency.Stop(GetConnectionString());
            SqlDependency.Start(GetConnectionString());

            if (connection == null)
            {
                connection = new SqlConnection(GetConnectionString());
            }

            if (command == null)
            {
                // GetSQL is a local procedure that returns
                // a paramaterized SQL string. You might want
                // to use a stored procedure in your application.
                command = new SqlCommand(GetSQL(), connection);

                //SqlParameter prm =
                //    new SqlParameter("@Quantity", SqlDbType.Int);
                //prm.Direction = ParameterDirection.Input;
                //prm.DbType = DbType.Int32;
                //prm.Value = 100;
                //command.Parameters.Add(prm);
            }
            if (dataToWatch == null)
            {
                dataToWatch = new DataSet();
            }

            GetData();
        }

        private void WatcherApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlDependency.Stop(GetConnectionString());
            if (connection != null)
            {
                connection.Close();
            }

        }
    }
}
