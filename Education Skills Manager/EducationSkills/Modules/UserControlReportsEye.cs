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
using DevExpress.Utils.Menu;
using System.Diagnostics;

namespace EducationSkills.Modules
{
    public partial class UserControlReportsEye : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlReportsEye()
        {
            InitializeComponent();
            context = new EducationSkillsDbContext();
            InitializeMenuItems();
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
            var show = saveFileDialog1.ShowDialog();
            if (show == DialogResult.Cancel)
            {
                saveFileDialog1.Dispose();
            }
            if (show == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    bandedGridView1.ExportToXlsx(saveFileDialog1.FileName);

                }

                Process.Start(saveFileDialog1.FileName);
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

        DXMenuItem[] menuItems;
        void InitializeMenuItems()
        {
            //DXMenuItem itemEdit = new DXMenuItem ("Sửa", ItemEdit_Click);
            DXMenuItem itemDelete = new DXMenuItem("Xóa", ItemDelete_Click);
            menuItems = new DXMenuItem[] { itemDelete };
        }

        private void ItemEdit_Click(object sender, System.EventArgs e)
        {
            dynamic mboxResult = MessageBox.Show("Bạn có chắc muốn sửa lại giá trị hay không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (mboxResult == DialogResult.Yes)
            {
                for (int i = 0; i < bandedGridView1.Columns.Count; i++)
                {
                    if (i >= 3)
                    {
                        bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, bandedGridView1.Columns[i], null);
                    }
                }
            }

        }
        private void ItemDelete_Click(object sender, System.EventArgs e)
        {
            string staffCode = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "StaffCode").ToString();
            try
            {
                dynamic mboxResult = MessageBox.Show("Bạn có chắc muốn xóa hay không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (mboxResult == DialogResult.Yes)
                {
                    EducationSkillDataProviders.DeleteEye(staffCode);
                    bandedGridView1.DeleteRow(bandedGridView1.FocusedRowHandle);
                } 
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }
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
        private void GetCertificates()
        {
            var certificates = context.EDU_Certificates.OrderBy(c => c.DisplayMember).ToList();
            repositoryItemGridLookUpEdit1.DisplayMember = "DisplayMember";
            repositoryItemGridLookUpEdit1.ValueMember = "DisplayMember";
            repositoryItemGridLookUpEdit1.DataSource = certificates;
        }

        private void txtDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                if(txtDept.Text=="Tất cả")
                {
                    LoadReportsEye(null, null);
                }
                else
                {
                    LoadReportsEye(txtDept.EditValue.ToString(), null);
                }
                
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
                if(e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[10], str);
                }
            }
            if (e.Column == gridLevelDateII)
            {
                if(e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[10], str);
                }
                
            }
            if (e.Column == gridLevelDateIII)
            {
                if (e.Value != null)
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
            }
            if (e.Column == gridTestDateActual)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[10], str);
                }
            }

            if (e.Column == gridLevelI)
            {
                if(e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[9], cellValue);
                }
                
            }
            if (e.Column == gridLevelII)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[9], cellValue);
                }

            }
            if (e.Column == gridLevelIII)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[9], cellValue);
                }
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
            string dateLevelI = "", dateLevelII = "", dateLevelIII = "", dateConfirm = "", dateTestActual = "";
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
                if(bandedGridView1.GetRowCellValue(i, "NgayThi") != null)
                {
                    dateConfirm = bandedGridView1.GetRowCellValue(i, "NgayThi").ToString();
                }
                if (bandedGridView1.GetRowCellValue(i, "NgayThiThucTe") != null)
                {
                    dateTestActual = bandedGridView1.GetRowCellValue(i, "NgayThiThucTe").ToString();
                }
                try
                {
                    EducationSkillDataProviders.UpdateEye(staffCode, levelI, dateLevelI, levelII, dateLevelII, levelIII, dateLevelIII, dateConfirm, dateTestActual);
                    MessageHelper.SuccessMessageBox("Cập nhật thành công!");
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }
            }
            btnSaveChanged.Visible = false;
        }

        private void bandedGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;

                foreach (DXMenuItem item in menuItems)
                    e.Menu.Items.Add(item);

            }
        }
    }
}
