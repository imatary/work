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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace EducationSkills.Modules
{
    public partial class UserControlReportsSolder : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlReportsSolder()
        {
            InitializeComponent();
            InitializeMenuItems();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                LoadReportsSolder(txtDept.EditValue.ToString());
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtDept.Text = string.Empty;
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            btnFind.Focus();
            btnExportToExel.Enabled = false;
            LoadReportsSolder(null);
            GetCertificates();
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = @"Save exel file",
                OverwritePrompt = true,
                FileName = $"bao-cao-han-{DateTime.Now.ToString("dd-MM-yyyy")}",
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                bandedGridView1.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void UserControlReportsSolder_Load(object sender, EventArgs e)
        {
            LoadReportsSolder(null);
            GetDepartments();
            GetCertificates();
        }

        DXMenuItem[] menuItems;
        void InitializeMenuItems()
        {
            //DXMenuItem itemEdit = new DXMenuItem("Sửa", ItemEdit_Click);
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
                    EducationSkillDataProviders.DeleteSolder(staffCode);
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
        private void LoadReportsSolder(string key)
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
                var reports = context.Database.SqlQuery<ReportsSolder>("EXEC [dbo].[sp_Get_All_Check Solders] @deptCode", parmDept).ToList();

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
                if (txtDept.Text == "Tất cả")
                {
                    LoadReportsSolder(null);
                }
                else
                {
                    LoadReportsSolder(txtDept.EditValue.ToString());
                }
            }
        }

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
                    view.SetRowCellValue(e.RowHandle, view.Columns[8], str);
                } 
            }
            if (e.Column == gridLevelDateII)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[8], str);
                }
            }
            if (e.Column == gridDateLevelIII)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[8], str);
                }
            }

            if (e.Column == gridTestDateActual)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    DateTime changeValue = DateTime.Parse(cellValue).AddDays(365);
                    string str = changeValue.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[8], str);
                }
            }

            if (e.Column == gridCapDo)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[7], cellValue);
                }
            }
            if (e.Column == gridLevelII)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[7], cellValue);
                }

            }
            if (e.Column == gridLevelIII)
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    view.SetRowCellValue(e.RowHandle, view.Columns[7], cellValue);
                }
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string staffCode = "", levelI = "", levelII = "", levelIII = "";
            string dateLevelI = "", dateLevelII = "", dateLevelIII = "", dateConfirm = "", dateTestActual = "";
            for (int i = 0; i < bandedGridView1.DataRowCount; i++)
            {
                if (bandedGridView1.GetRowCellValue(i, "StaffCode") != null)
                {
                    staffCode = bandedGridView1.GetRowCellValue(i, "StaffCode").ToString();
                }

                if (bandedGridView1.GetRowCellValue(i, "CapDoHan") != null)
                {
                    levelI = bandedGridView1.GetRowCellValue(i, "CapDoHan").ToString();
                }

                if (bandedGridView1.GetRowCellValue(i, "NgayCap") != null)
                {
                    dateLevelI = bandedGridView1.GetRowCellValue(i, "NgayCap").ToString();
                }

                if (bandedGridView1.GetRowCellValue(i, "NangCapDo") != null)
                {
                    levelII = bandedGridView1.GetRowCellValue(i, "NangCapDo").ToString();
                }


                if (bandedGridView1.GetRowCellValue(i, "NgayNangCap") != null)
                {
                    dateLevelII = bandedGridView1.GetRowCellValue(i, "NgayNangCap").ToString();
                }


                if (bandedGridView1.GetRowCellValue(i, "CNNguoiDaoTao") != null)
                {
                    levelIII = bandedGridView1.GetRowCellValue(i, "CNNguoiDaoTao").ToString();
                }


                if (bandedGridView1.GetRowCellValue(i, "NgayCNNguoiDaoTao") != null)
                {
                    dateLevelIII = bandedGridView1.GetRowCellValue(i, "NgayCNNguoiDaoTao").ToString();
                }



                if (bandedGridView1.GetRowCellValue(i, "NgayThiXacNhan") != null)
                {
                    dateConfirm = bandedGridView1.GetRowCellValue(i, "NgayThiXacNhan").ToString();
                }


                if (bandedGridView1.GetRowCellValue(i, "NgayThiThucTe") != null)
                {
                    dateTestActual = bandedGridView1.GetRowCellValue(i, "NgayThiThucTe").ToString();
                }

                try
                {
                    EducationSkillDataProviders.UpdateSolder(staffCode, levelI, dateLevelI, levelII, dateLevelII, levelIII, dateLevelIII, dateConfirm, dateTestActual);
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
