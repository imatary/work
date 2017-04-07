﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Collections;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using System.Diagnostics;

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
            string selectDate = null, selectDept = null;
            if (FormDate.Text != "")
            {
                selectDate = FormDate.DateTime.ToString();
            }
            if (txtDept.Text != "")
            {
                selectDept = txtDept.EditValue.ToString();
            }

            GetReportSkillsMap(selectDate, selectDept);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dept"></param>
        private void GetReportSkillsMap(string date, string dept)
        {
            splashScreenManager1.ShowWaitForm();
            DataTable dt = new DataTable();
            context = new EducationSkillsDbContext();

            SqlParameter parmDept = new SqlParameter() { ParameterName = "@deptCode", Value = dept, SqlDbType = SqlDbType.VarChar };
            if (dept == null)
            {
                parmDept.Value = DBNull.Value;
            }
            SqlParameter parmDate = new SqlParameter() { ParameterName = "@date", Value = date, SqlDbType = SqlDbType.DateTime };
            if (date == null)
            {
                parmDate.Value = DBNull.Value;
            }
            try
            {
                var subjects = context.Database.SqlQuery<Subject>("EXEC [dbo].[sp_GetSubjectCodes]").ToList();

                List<Staff> staffs = context.Database.SqlQuery<Staff>("EXEC [dbo].[sp_GetStaffs] @deptCode, @date", parmDept, parmDate).ToList();

                var data = (from f in staffs
                         group f by new { f.StaffCode, f.FullName, f.DeptCode, f.TenBoMon }
                    into myGroup
                         where myGroup.Count() > 0
                         select new
                         {
                             myGroup.Key.StaffCode,
                             myGroup.Key.FullName,
                             myGroup.Key.DeptCode,
                             myGroup.Key.TenBoMon,
                             Subs = myGroup.GroupBy(f => f.MaBoMon)
                             .Select
                             (m =>
                                new
                                {
                                    Date = m.SingleOrDefault(c => c.StaffCode == myGroup.Key.StaffCode).NgayThamGia
                                })
                         }).ToList();


                //Creating array for adding dynamic columns
                ArrayList objDataColumn = new ArrayList();

                if (staffs.Count() > 0)
                {
                    objDataColumn.Add("Code");
                    objDataColumn.Add("FullName");
                    objDataColumn.Add("Dept");

                    //Add Subject Name as column in Datatable
                    for (int i = 0; i < subjects.Count; i++)
                    {
                        objDataColumn.Add(subjects[i].MaBoMon);
                    }
                }
                //Add dynamic columns name to datatable dt
                for (int i = 0; i < objDataColumn.Count; i++)
                {
                    dt.Columns.Add(objDataColumn[i].ToString());
                }

                //Add data into datatable with respect to dynamic columns and dynamic data
                for (int i = 0; i < data.Count; i++)
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(data[i].StaffCode.ToString());
                    tempList.Add(data[i].FullName.ToString());
                    tempList.Add(data[i].DeptCode.ToString());

                    var res = data[i].Subs.ToList();
                    for (int j = 0; j < res.Count; j++)
                    {
                        tempList.Add(string.Format("{0:dd/MM/yyyy}", res[j].Date));
                    }
                    
                    dt.Rows.Add(tempList.ToArray<string>());
                }
                gridControl1.DataSource = dt;

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
                    if (columnName.StartsWith("EDU"))
                    {
                        var SubjectName = context.PR_Bomon.SingleOrDefault(m => m.MaBoMon == columnName).TenBoMon;
                        gridView1.Columns[columnName].ToolTip = SubjectName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
        private void GetDepartments()
        {
            //context = new EducationSkillsDbContext();
            //var departments = context.Database.SqlQuery<Department>("EXEC [dbo].[sp_Get_All_Departments]").ToList();
            //txtDept.Properties.DataSource = departments;

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
            }

            Process.Start(saveFileDialog1.FileName);
        }

        private void txtDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                if (txtDept.Text == "Tất cả")
                {
                    GetReportSkillsMap(null, null);
                }
                else
                {
                    GetReportSkillsMap(null, txtDept.EditValue.ToString());
                }
            }
        }
    }
}
