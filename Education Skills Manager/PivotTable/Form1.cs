using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PivotTable
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("EmployeeID", Type.GetType("System.String"));
            dt.Columns.Add("OrderID", Type.GetType("System.Int32"));
            dt.Columns.Add("Amount", Type.GetType("System.Decimal"));
            dt.Columns.Add("Cost", Type.GetType("System.Decimal"));
            dt.Columns.Add("Date", Type.GetType("System.String"));
            dt.Rows.Add(new object[] { "Sam", 1, 25.00, 13.00, "01/10/2007" });
            dt.Rows.Add(new object[] { "Sam", 2, 512.00, 1.00, "02/10/2007" });
            dt.Rows.Add(new object[] { "Sam", 3, 512.00, 1.00, "03/10/2007" });
            dt.Rows.Add(new object[] { "Tom", 4, 50.00, 1.00, "04/10/2007" });
            dt.Rows.Add(new object[] { "Tom", 5, 3.00, 7.00, "03/10/2007" });
            dt.Rows.Add(new object[] { "Tom", 6, 78.75, 12.00, "02/10/2007" });
            dt.Rows.Add(new object[] { "Sue", 7, 11.00, 7.00, "01/10/2007" });
            dt.Rows.Add(new object[] { "Sue", 8, 2.50, 66.20, "02/10/2007" });
            dt.Rows.Add(new object[] { "Sue", 9, 2.50, 22.00, "03/10/2007" });
            dt.Rows.Add(new object[] { "Jack", 10, 6.00, 23.00, "02/10/2007" });
            dt.Rows.Add(new object[] { "Jack", 11, 117.00, 199.00, "04/10/2007" });
            dt.Rows.Add(new object[] { "Jack", 12, 13.00, 2.60, "01/10/2007" });
            dt.Rows.Add(new object[] { "Jack", 13, 11.40, 99.80, "03/10/2007" });
            dt.Rows.Add(new object[] { "Phill", 14, 37.00, 2.10, "02/10/2007" });
            dt.Rows.Add(new object[] { "Phill", 15, 65.20, 99.30, "04/10/2007" });
            dt.Rows.Add(new object[] { "Phill", 16, 34.10, 27.00, "02/10/2007" });
            dt.Rows.Add(new object[] { "Phill", 17, 17.00, 959.00, "04/10/2007" });

            dataGridView1.DataSource = dt;

            foreach (DataColumn dc in dt.Columns)
                cboX.Items.Add(dc.ColumnName);
            foreach (DataColumn dc in dt.Columns)
                cboY.Items.Add(dc.ColumnName);
            foreach (DataColumn dc in dt.Columns)
                cboZ.Items.Add(dc.ColumnName);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string x = "";
                string y = "";
                string z = "";

                if (cboX.SelectedItem != null)
                    x = cboX.SelectedItem.ToString();
                if (cboY.SelectedItem != null)
                    y = cboY.SelectedItem.ToString();
                if (cboZ.SelectedItem != null)
                    z = cboZ.SelectedItem.ToString();

                DataTable newDt = new DataTable();
                if (y != "" && z != "")
                    newDt = PivotTable.GetInversedDataTable(dt, x, y, z, txttNullValue.Text, chkSumValues.Checked);
                else
                    newDt = PivotTable.GetInversedDataTable(dt, x, y);

                dataGridView2.DataSource = newDt;

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }

        }

    }
}
