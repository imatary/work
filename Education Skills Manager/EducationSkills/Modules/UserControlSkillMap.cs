using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Collections;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using System.Diagnostics;
using DevExpress.Utils;

namespace EducationSkills.Modules
{
    public partial class UserControlSkillMap : UserControl
    {
        private EducationSkillsDbContext context;
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
            DataTable dt = new DataTable();
            context = new EducationSkillsDbContext();

            SqlParameter parmDept = new SqlParameter() { ParameterName = "@deptCode", Value = dept, SqlDbType = SqlDbType.VarChar };
            if (dept == null)
            {
                parmDept.Value = DBNull.Value;
            }
            try
            {
                var subjects = context.Database.SqlQuery<Subject>("EXEC [dbo].[sp_GetSubjectCodes]").ToList();

                List<Staff> staffs = context.Database.SqlQuery<Staff>("EXEC [dbo].[sp_GetStaffs] @deptCode", parmDept).ToList();

                var data = (from f in staffs
                            group f by new { f.StaffCode, f.FullName, f.DeptCode }
                    into myGroup
                            where myGroup.Count() > 0
                            select new
                            {
                                myGroup.Key.StaffCode,
                                myGroup.Key.FullName,
                                myGroup.Key.DeptCode,
                                SubjectIDs = myGroup.GroupBy(f => f.MaBoMon)
                                .Select
                                (m =>
                                   new
                                   {
                                       Date = m.SingleOrDefault(c => c.StaffCode == myGroup.Key.StaffCode).NgayThamGia
                                   })
                            }).ToList();

                ArrayList objDataColumn = new ArrayList();

                if (staffs.Count() > 0)
                {
                    objDataColumn.Add("Code");
                    objDataColumn.Add("FullName");
                    objDataColumn.Add("Dept");

                    for (int i = 0; i < subjects.Count; i++)
                    {
                        objDataColumn.Add(subjects[i].MaBoMon.Replace(" ", ""));
                    }
                }
                for (int i = 0; i < objDataColumn.Count; i++)
                {
                    dt.Columns.Add(objDataColumn[i].ToString());
                }

                for (int i = 0; i < data.Count; i++)
                {
                    List<string> rowItem = new List<string>();
                    rowItem.Add(data[i].StaffCode.ToString());
                    rowItem.Add(data[i].FullName.ToString());
                    rowItem.Add(data[i].DeptCode.ToString());

                    var IDs = data[i].SubjectIDs.ToList();
                    if (IDs.Any())
                    {
                        for (int j = 0; j < IDs.Count; j++)
                        {
                            rowItem.Add(string.Format("{0:dd/MM/yyyy}", IDs[j].Date));
                        }
                    }


                    dt.Rows.Add(rowItem.ToArray<string>());
                }
                gridControl1.DataSource = dt;

                gridView1.Columns[0].Width = 70;
                gridView1.Columns[1].Width = 150;
                gridView1.Columns[2].Width = 70;

                gridView1.Columns[0].Fixed = FixedStyle.Left;
                gridView1.Columns[1].Fixed = FixedStyle.Left;
                gridView1.Columns[2].Fixed = FixedStyle.Left;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (gridControl1.DataSource != null)
            {
                btnExportToExel.Enabled = true;
            }

            // Tooltip Column Title
            foreach (var item in gridView1.Columns)
            {
                string columnName = item.ToString();
                if (columnName.StartsWith("EDU-"))
                {
                    var SubjectName = context.PR_Bomon.SingleOrDefault(m => m.MaBoMon == columnName).TenBoMon;
                    gridView1.Columns[columnName].ToolTip = SubjectName;

                    //if (gridView1.Columns[columnName] != "")
                    //{
                    //    gridView1.Columns[columnName].ColumnEdit.DisplayFormat.FormatType = FormatType.DateTime;
                    //}

                    //for (int i = 0; i < gridView1.RowCount; i++)
                    //{
                    //    string value = gridView1.GetRowCellValue(i, columnName).ToString();
                    //    if (value != null || value.Length > 1)
                    //    {
                    //        gridView1.Columns[columnName].ColumnEdit.DisplayFormat.FormatType = FormatType.DateTime;
                    //    }
                    //}
                    gridView1.Columns[columnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    gridView1.Columns[columnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
            }
            splashScreenManager1.CloseWaitForm();
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
                FileName = $"reports-skill-map-{DateTime.Now.ToString("dd-MM-yyyy")}"
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridView1.ExportToXlsx(saveFileDialog1.FileName);
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
    }
}
