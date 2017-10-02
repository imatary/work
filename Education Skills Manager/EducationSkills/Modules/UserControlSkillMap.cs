using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.Data;
using EducationSkills.Models;

namespace EducationSkills.Modules
{
    public partial class UserControlSkillMap : UserControl
    {
        private EducationSkillsDbContext context;
        private DataTable dataTable;
        public UserControlSkillMap()
        {
            InitializeComponent();
        }

        private void UserControlSkillMap_Load(object sender, EventArgs e)
        {
            GetDepartments();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string selectDept = null;
            if (txtDept.Text != "")
            {
                selectDept = txtDept.EditValue.ToString();
            }

            GetReportSkillsMap(selectDept);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dept"></param>
        private void GetReportSkillsMap(string dept)
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();

            SqlParameter parmDept = new SqlParameter() { ParameterName = "@deptCode", Value = dept, SqlDbType = SqlDbType.VarChar };
            if (dept == null)
            {
                parmDept.Value = DBNull.Value;
            }
            try
            {
                List<Staff> staffs = context.Database.SqlQuery<Staff>("EXEC [dbo].[sp_GetStaffs] @deptCode", parmDept).ToList();

                List<PivotSkillMap> queryResults =
                  (from iso in staffs
                   orderby iso.StaffCode ascending, iso.MaBoMon ascending
                   group iso by iso.StaffCode into isoGroup
                   select new PivotSkillMap()
                   {
                       StaffCode = isoGroup.Key,
                       FullName = isoGroup.Select(d => d.FullName).FirstOrDefault(),
                       DeptCode=isoGroup.Select(d=>d.DeptCode).FirstOrDefault(),
                       MaBoMon = isoGroup.Select(y => y.MaBoMon),
                       NgayThamGia = isoGroup.Select(v => v.NgayThamGia)
                   }).ToList();

                PopulateGrid(queryResults);

                gridView1.Columns[0].Width = 70;
                gridView1.Columns[1].Width = 150;
                gridView1.Columns[2].Width = 70;

                gridView1.Columns[0].Fixed = FixedStyle.Left;
                gridView1.Columns[1].Fixed = FixedStyle.Left;
                gridView1.Columns[2].Fixed = FixedStyle.Left;

                // Tooltip Column Title
                foreach (var item in gridView1.Columns)
                {
                    string columnName = item.ToString();
                    if (columnName.StartsWith("EDU-"))
                    {
                        var SubjectName = context.PR_Bomon.SingleOrDefault(m => m.MaBoMon == columnName).TenBoMon;
                        gridView1.Columns[columnName].ToolTip = SubjectName;
                        //gridView1.Columns[columnName].Summary.Add(DevExpress.Data.SummaryItemType.Count, columnName, "{0}");
                        gridView1.Columns[columnName].SummaryItem.SetSummary(SummaryItemType.Count, "{0}");
                        //gridView1.Columns[columnName].SummaryItem.SummaryType = SummaryItemType.Count;

                        gridView1.Columns[columnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridView1.Columns[columnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    }
                    if (columnName.StartsWith("TOTAL"))
                    {
                        gridView1.Columns[columnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridView1.Columns[columnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (gridControl1.DataSource != null)
            {
                btnExportToExel.Enabled = true;
            }
            splashScreenManager1.CloseWaitForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pivots"></param>
        private void PopulateGrid(List<PivotSkillMap> pivots)
        {
            // Create a DataTable as a DataSource for the grid
            dataTable = new DataTable();
            // Create the DataColumns for the data table
            DataColumn dc = new DataColumn("Code", typeof(string));
            dataTable.Columns.Add(dc);
            dc = new DataColumn("FullName", typeof(string));
            dataTable.Columns.Add(dc);
            dc = new DataColumn("Dept", typeof(string));
            dataTable.Columns.Add(dc);

            // Get a list of Distinct years
            var subjectTitles = (from subjects in pivots.Select(item => item.MaBoMon)
                                 from sub in subjects
                                 select sub.ToString()).Distinct().ToList();

            // Create the DataColumns for the table
            subjectTitles.ForEach(delegate (string title)
            {
                dc = new DataColumn(title, typeof(DateTime));
                dataTable.Columns.Add(dc);
            });

            // col total
            dc = new DataColumn("TOTAL", typeof(int));
            dataTable.Columns.Add(dc);

            // Populate the rowa of the DataTable
            foreach (var rec in pivots)
            {
                // The first two columns of the row always has a ISO Code and Description
                DataRow dr = dataTable.NewRow();
                dr[0] = rec.StaffCode;
                dr[1] = rec.FullName;
                dr[2] = rec.DeptCode.ToUpper();

                // For each record
                var subs = rec.MaBoMon.ToList();
                var values = rec.NgayThamGia.ToList();
                int count = 0;
                // Because each row may have different years I am indexing
                // the with the string name
                for (int i = 0; i < values.Count; i++)
                {
                    string value = values[i].ToString();
                    if (value != "")
                    {
                        //value = value.Replace(" 00:00:00 AM", "");
                        //value = value.Replace(" 12:00:00 AM", "");

                        DateTime date = DateTime.Parse(value); 

                        dr[subs[i].ToString()] = date;
                        count = count + 1;
                    }
                    else
                    {
                        dr[subs[i].ToString()] = DBNull.Value;
                    }
                }

                if (count > 0)
                {
                    dr["TOTAL"] = count.ToString();
                }

                // Add the DataRow to the DataTable
                dataTable.Rows.Add(dr);
            }

            // Bind the DataTable to the DataGridView
            gridControl1.DataSource = dataTable;

        }

        /// <summary>
        /// 
        /// </summary>
        private void GetDepartments()
        {
            context = new EducationSkillsDbContext();
            var dept = new Department { DeptCode = "Tất cả" };
            List<Department> departments = null;

            departments = context.Database.SqlQuery<Department>("EXEC [dbo].[sp_Get_All_Departments]").ToList();
            departments.Add(dept);

            txtDept.Properties.DataSource = departments;
            txtDept.Properties.DisplayMember = "DeptCode";
            txtDept.Properties.ValueMember = "DeptCode";

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            FormDate.Text = string.Empty;
            txtDept.Text = string.Empty;
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            btnFind.Focus();
            btnExportToExel.Enabled = false;
            GetReportSkillsMap(null);
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = @"Save exel file",
                OverwritePrompt = true,
                FileName = $"Reports-KillsMap{DateTime.Now.ToString("dd-MM-yyyy")}"
            };
            var show = saveFileDialog1.ShowDialog();
            if (show == DialogResult.Cancel)
            {
                saveFileDialog1.Dispose();
            }
            if (show == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    XlsxExportOptions opt = new XlsxExportOptions()
                    {
                        TextExportMode = TextExportMode.Text,
                    };
                    gridControl1.ExportToXlsx(saveFileDialog1.FileName, opt);
                }
                Process.Start(saveFileDialog1.FileName);
            } 
        }

        private void txtDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                if (txtDept.Text == "Tất cả")
                {
                    GetReportSkillsMap(null);
                }
                else
                {
                    GetReportSkillsMap(txtDept.EditValue.ToString());
                }
            }
        }
        //private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        //{
        //    if (e.Column.FieldName.StartsWith("EDU-"))
        //    {
        //        RepositoryItemDateEdit edit = new RepositoryItemDateEdit();
        //        edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
        //        edit.Mask.UseMaskAsDisplayFormat = true;
        //        e.RepositoryItem = edit;
        //    }
        //}

        //private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        //{
        //    if (e.Column.FieldName.StartsWith("EDU-"))
        //    {
        //        DateTime time = DateTime.MinValue;
        //        if (e.Value != DBNull.Value)
        //        {
        //            if (Convert.ToDateTime(e.Value) == time)
        //            {
        //                e.DisplayText = "";
        //            }
        //        }
        //    }
        //}
    }
}
