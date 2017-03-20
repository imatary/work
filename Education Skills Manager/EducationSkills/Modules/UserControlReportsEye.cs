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
using EducationSkills.Models;
using System.Data.SqlClient;

namespace EducationSkills.Modules
{
    public partial class UserControlReportsEye : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlReportsEye()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                LoadReportsEye(txtDept.EditValue.ToString());
            }
            if (gridControl1.DataSource != null)
            {
                btnExportToExel.Enabled = true;
            }
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Exel|*.xls",
                Title = @"Save exel file",
                OverwritePrompt = true,
                FileName = $"bao-cao-kiem-tra-mat-{DateTime.Now.ToString("dd-MM -yyyy")}",
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl1.ExportToXls(saveFileDialog1.FileName);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtDept.Text = string.Empty;
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            btnFind.Focus();
            btnExportToExel.Enabled = false;
            LoadReportsEye(null);
        }

        private void UserControlReportsEye_Load(object sender, EventArgs e)
        {

            LoadReportsEye(null);
            GetDepartments();
            if (gridControl1.DataSource != null)
            {
                btnExportToExel.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void LoadReportsEye(string key)
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
                var reports = context.Database.SqlQuery<ReportsEye>("EXEC [dbo].[sp_Get_All_CheckEye] @deptCode", parmDept).ToList();

                gridControl1.DataSource = reports;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }
            

            splashScreenManager1.CloseWaitForm();
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
    }
}
