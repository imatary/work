using EducationSkills.Data;
using EducationSkills.Subjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills.Modules
{
    public partial class UserControlSubjectsDept : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlSubjectsDept()
        {
            InitializeComponent();
            GetDepartments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormAddSubject("").ShowDialog();
            LoadSubjects(null);
        }

        private void btlRefesh_Click(object sender, EventArgs e)
        {
            LoadSubjects(null);
        }

        private void UserControlSubjects_Load(object sender, EventArgs e)
        {
            LoadSubjects(null);
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

            cboDept.ComboBox.DataSource = departments;
            cboDept.ComboBox.DisplayMember = "DeptCode";
            cboDept.ComboBox.ValueMember = "DeptCode";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void LoadSubjects(string dept)
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();
            object key = null;
            if (dept != null)
            {
                key = dept;
            }
            else
            {
                key = DBNull.Value;
            }
            string type = "Đào tạo tại bộ phận";
            object[] param =
            {
                new SqlParameter() { ParameterName = "@type", Value = type, SqlDbType = SqlDbType.NVarChar},
                new SqlParameter() { ParameterName = "@dept", Value = key, SqlDbType = SqlDbType.NVarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            try
            {
                var subjects = context.Database.SqlQuery<PR_Bomon>("EXEC [dbo].[ShowBoMon] @type, @dept", param).ToList();

                gridControl1.DataSource = subjects;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }


            splashScreenManager1.CloseWaitForm();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks >= 1)
            {
                string subjectId = (string)gridView1.GetRowCellValue(e.RowHandle, "MaBoMon");
                new FormAddSubject(subjectId).ShowDialog();
                LoadSubjects(null);
            }
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dept = cboDept.ComboBox.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(dept))
            {
                LoadSubjects(dept);
            }
        }
    }
}
