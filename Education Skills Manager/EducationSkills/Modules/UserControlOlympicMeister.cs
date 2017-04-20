using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Data.SqlClient;
using EducationSkills.Models;
using System.Globalization;
using System.Diagnostics;

namespace EducationSkills.Modules
{
    public partial class UserControlOlympicMeister : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlOlympicMeister()
        {
            InitializeComponent();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void GetOlympics(string key)
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
                var reports = context.Database.SqlQuery<Olympic>("EXEC [dbo].[sp_Get_Olympics] @deptCode", parmDept).ToList();

                gridControl1.DataSource = reports;

            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormAddOlympic().ShowDialog();
            GetOlympics(null);
        }

        private void UserControlOlympicMeister_Load(object sender, EventArgs e)
        {
            GetDepartments();
            GetOlympics(null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                GetOlympics(txtDept.EditValue.ToString());
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtDept.Text = string.Empty;
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            btnFind.Focus();
            btnExportToExel.Enabled = false;
            GetOlympics(null);
            GetDepartments();
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = @"Save exel file",
                OverwritePrompt = true,
                FileName = $"Reports-Olympics-{DateTime.Now.ToString("dd-MM-yyyy")}",
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
                    gridView1.ExportToXlsx(saveFileDialog1.FileName);

                }

                Process.Start(saveFileDialog1.FileName);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void txtDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                if (txtDept.Text == "Tất cả")
                {
                    GetOlympics(null);
                }
                else
                {
                    GetOlympics(txtDept.EditValue.ToString());
                }

            }
        }
    }
}
