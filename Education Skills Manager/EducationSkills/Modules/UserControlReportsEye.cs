using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Data;
using EducationSkills.Models;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace EducationSkills.Modules
{
    public partial class UserControlReportsEye : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlReportsEye()
        {
            InitializeComponent();
            context = new EducationSkillsDbContext();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                LoadReportsEye(txtDept.EditValue.ToString(), null);
            }
            if (!string.IsNullOrEmpty(txtKey.Text))
            {
                LoadReportsEye(null, txtKey.Text);
            }
            if(!string.IsNullOrEmpty(txtDept.Text) && !string.IsNullOrEmpty(txtKey.Text))
            {
                LoadReportsEye(txtDept.EditValue.ToString(), txtKey.Text);
            }
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = @"Save exel file",
                OverwritePrompt = true,
                FileName = $"bao-cao-kiem-tra-mat-{DateTime.Now.ToString("dd-MM-yyyy")}",
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                bandedGridView1.ExportToXlsx(saveFileDialog1.FileName);
            }
            //ExportToExcel(bandedGridView1);

        }

        private void ExportToExcel(GridView view)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < view.DataRowCount; i++)
                {
                    for (int j = 0; j < view.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = view.Columns[j].Caption;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = view.GetRowCellValue(i, view.Columns[j]).ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtDept.Text = string.Empty;
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            btnFind.Focus();
            btnExportToExel.Enabled = false;
            LoadReportsEye(null, null);
            GetCertificates();
        }

        private void UserControlReportsEye_Load(object sender, EventArgs e)
        {
            LoadReportsEye(null, null);
            GetDepartments();
            GetCertificates();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void LoadReportsEye(string dept, string staffCode)
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();

            SqlParameter parmDept = new SqlParameter() { ParameterName = "@deptCode", Value = dept, SqlDbType = SqlDbType.VarChar };
            if (dept == null)
            {
                parmDept.Value = DBNull.Value;
            }
            SqlParameter parmStaff = new SqlParameter() { ParameterName = "@staffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar };
            if (staffCode == null)
            {
                parmStaff.Value = DBNull.Value;
            }
            try
            {
                var reports = context.Database.SqlQuery<ReportsEye>("EXEC [dbo].[sp_Get_All_CheckEye] @deptCode,@staffCode", parmDept, parmStaff).ToList();

                gridControl1.DataSource = reports;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
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
            context = new EducationSkillsDbContext();
            //var dept = new Department { DeptCode = "All" };
            List<Department> departments = null;
            
            //departments.Add(dept);
            departments = context.Database.SqlQuery<Department>("EXEC [dbo].[sp_Get_All_Departments]").ToList();

            txtDept.Properties.DataSource = departments;

        }

        /// <summary>
        /// 
        /// </summary>
        private void GetCertificates()
        {
            var certificates = context.EDU_Certificates.ToList();
            repositoryItemGridLookUpEdit1.DisplayMember = "DisplayMember";
            repositoryItemGridLookUpEdit1.ValueMember = "DisplayMember";
            repositoryItemGridLookUpEdit1.DataSource = certificates;
        }

        private void txtDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                LoadReportsEye(txtDept.EditValue.ToString(), null);
            }
        }

        private void txtKey_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKey.Text))
            {
                LoadReportsEye(null, txtKey.Text);
                txtKey.Properties.Buttons[0].Visible = true;
            }
        }

        private void bandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            BandedGridView view = sender as BandedGridView;
            if (view == null)
                return;
            btnSaveChanged.Visible = true;
            string staffCode = view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString();

            if (e.Column == gridLevelDateI)
            {
                string cellValue = e.Value.ToString();
                DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                string str = changeValue.ToString();
                view.SetRowCellValue(e.RowHandle, view.Columns[10], str);
            }
            if (e.Column == gridLevelDateII)
            {
                string cellValue = e.Value.ToString();
                DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                string str = changeValue.ToString();
                view.SetRowCellValue(e.RowHandle, view.Columns[10], str);
            }
            if (e.Column == gridLevelDateIII)
            {
                string cellValue = null;
                if (Ultils.IsNull(e.Value.ToString()))
                {
                    cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[10], str);
                }
            }

            if(e.Column == gridLevelI)
            {
                string cellValue = e.Value.ToString();
                view.SetRowCellValue(e.RowHandle, view.Columns[9], cellValue);
            }
            if (e.Column == gridLevelII)
            {
                string cellValue = e.Value.ToString();
                view.SetRowCellValue(e.RowHandle, view.Columns[9], cellValue);

            }
            if (e.Column == gridLevelIII)
            {
                string cellValue = e.Value.ToString();
                view.SetRowCellValue(e.RowHandle, view.Columns[9], cellValue);
            }

            
        }

        private void txtKey_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtKey.ResetText();
                txtKey.Properties.Buttons[0].Visible = false;
                LoadReportsEye(null, null);
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string staffCode="", levelI="", levelII="", levelIII="";
            string dateLevelI = "", dateLevelII = "", dateLevelIII = "", dateConfirm = "";
            for (int i = 0; i < bandedGridView1.DataRowCount; i++)
            {
                if(bandedGridView1.GetRowCellValue(i, "StaffCode") != null)
                {
                    staffCode = bandedGridView1.GetRowCellValue(i, "StaffCode").ToString();
                }
                if(bandedGridView1.GetRowCellValue(i, "CapDo") != null)
                {
                    levelI = bandedGridView1.GetRowCellValue(i, "CapDo").ToString();
                }
                if(bandedGridView1.GetRowCellValue(i, "NgayCap") != null)
                {
                    dateLevelI = bandedGridView1.GetRowCellValue(i, "NgayCap").ToString();
                }
                if(bandedGridView1.GetRowCellValue(i, "NangCap") != null)
                {
                    levelII = bandedGridView1.GetRowCellValue(i, "NangCap").ToString();
                }
                if(bandedGridView1.GetRowCellValue(i, "NgayNangCap") != null)
                {
                    dateLevelII = bandedGridView1.GetRowCellValue(i, "NgayNangCap").ToString();
                }
                if (bandedGridView1.GetRowCellValue(i, "CNNguoiDaoTao") != null)
                {
                    levelIII = bandedGridView1.GetRowCellValue(i, "CNNguoiDaoTao").ToString();
                }

                if(bandedGridView1.GetRowCellValue(i, "NgayCNNguoiDaoTao") != null)
                {
                    dateLevelIII = bandedGridView1.GetRowCellValue(i, "NgayCNNguoiDaoTao").ToString();
                }
                if(bandedGridView1.GetRowCellValue(i, "NgayThiThucTe") != null)
                {
                    dateConfirm = bandedGridView1.GetRowCellValue(i, "NgayThiThucTe").ToString();
                }
                
                try
                {
                    EducationSkillDataProviders.UpdateEye(staffCode, levelI, dateLevelI, levelII, dateLevelII, levelIII, dateLevelIII, dateConfirm);
                    MessageHelper.SuccessMessageBox("Cập nhật thành công!");
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }
            }
            btnSaveChanged.Visible = false;
        }
    }
}
