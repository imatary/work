using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Data.SqlClient;
using EducationSkills.Models;
using EducationSkills.Subjects;

namespace EducationSkills.Modules
{
    public partial class UserControlEmployees : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlEmployees()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                LoadEmployees(txtDept.EditValue.ToString());
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtDept.Text = string.Empty;
            LoadEmployees(null);
            GetDepartments();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetDepartments()
        {
            context = new EducationSkillsDbContext();
            var departments = context.Database.SqlQuery<Department>("EXEC [dbo].[sp_Get_All_Departments]").ToList();
            txtDept.Properties.DataSource = departments;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void LoadEmployees(string key)
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();

            SqlParameter parmDept = new SqlParameter() { ParameterName = "@deptCode", Value = key, SqlDbType = SqlDbType.VarChar };
            if (key == null)
            {
                parmDept.Value = DBNull.Value;
            }

            try
            {
                var reports = context.Database.SqlQuery<Employees>("EXEC [dbo].[sp_Get_All_Staff] @deptCode", parmDept).ToList();

                gridControl1.DataSource = reports;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void UserControlEmployees_Load(object sender, EventArgs e)
        {
            LoadEmployees(null);
            GetDepartments();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Clicks > 1)
            {
                string subjectId = (string)gridView1.GetRowCellValue(e.RowHandle, "StaffCode");
                new UserRegisterSubjects(subjectId).ShowDialog();
            }
        }
    }
}
