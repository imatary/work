using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = GetData(100);
            gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);

        }

        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Date")
            {
                DateTime time = new DateTime(1973, 1, 1);
                if (Convert.ToDateTime(e.Value) == time)
                {
                    e.DisplayText = "";
                }
            }
        }

        DataTable GetData(int rows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Info", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < rows; i++)
            {
                DateTime time;
                if (i % 2 == 0)
                    time = DateTime.Now;
                else
                    time = new DateTime(1973, 1, 1);
                dt.Rows.Add(i, "Info" + i.ToString(), time);
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XlsxExportOptions opt = new XlsxExportOptions();
            opt.TextExportMode = TextExportMode.Text;
            gridView1.ExportToXlsx("1.xlsx", opt);
            Process.Start("1.xlsx");
        }
    }
}
