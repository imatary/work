using EducationSkills.Data;
using EducationSkills.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills.Subjects
{
    public partial class UserRegisterSubjects : Form
    {
        private EducationSkillsDbContext context;
        public UserRegisterSubjects(string staffCode)
        {
            InitializeComponent();

            LoadData(staffCode);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int record = 0;
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if(gridView1.GetRowCellValue(i, "NgayThamGia") != null)
                {
                    DateTime date = (DateTime) gridView1.GetRowCellValue(i, "NgayThamGia");
                    string note = (string) gridView1.GetRowCellValue(i, "GhiChu");
                    string subjectId = (string)gridView1.GetRowCellValue(i, "MaBoMon");

                    // Mã bộ môn
                    SqlParameter mabomon = new SqlParameter() { ParameterName = "@MaBoMon", Value = subjectId, SqlDbType = SqlDbType.NChar };
                    if (subjectId == null)
                    {
                        mabomon.Value = DBNull.Value;
                    }

                    // StaffCode
                    SqlParameter parmstaffCode = new SqlParameter() { ParameterName = "@StaffCode", Value = lblCode.Text, SqlDbType = SqlDbType.NChar };
                    if (lblCode.Text == null)
                    {
                        parmstaffCode.Value = DBNull.Value;
                    }
                    // Ngày tham gia
                    SqlParameter parmNgayThamGia = new SqlParameter() { ParameterName = "@NgayThamGia", Value = date, SqlDbType = SqlDbType.DateTime };
                    if (date == null)
                    {
                        parmNgayThamGia.Value = DBNull.Value;
                    }

                    SqlParameter parmNote = new SqlParameter() { ParameterName = "@GhiChu", Value = note, SqlDbType = SqlDbType.NVarChar };
                    if (lblCode.Text == null)
                    {
                        parmNote.Value = DBNull.Value;
                    }
                    try
                    {
                        if(date > DateTime.Now)
                        {
                            MessageHelper.ErrorMessageBox("Ngày tham gia không được lớn hơn ngày hiện tại. Vui lòng kiểm tra lại!");
                            return;
                        }
                        if(date < DateTime.Parse(lblEntryDate.Text))
                        {
                            MessageHelper.ErrorMessageBox("Ngày tham gia không được nhỏ hơn ngày vào làm. Vui lòng kiểm tra lại!");
                            return;
                        }

                        context.Database.ExecuteSqlCommand("EXEC [dbo].[UpdateSkillMap] @StaffCode,@MaBoMon,@NgayThamGia,@GhiChu ", parmstaffCode, mabomon,  parmNgayThamGia, parmNote);
                        record++;
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ErrorMessageBox(ex.Message);
                    }
                }
            }

            MessageHelper.SuccessMessageBox($"Lưu thành công {record}!");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        private void LoadData(string staffCode)
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();

            SqlParameter parmstaffCode = new SqlParameter() { ParameterName = "@staffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar };
            if (staffCode == null)
            {
                parmstaffCode.Value = DBNull.Value;
            }

            try
            {
                var employees = context.Database.SqlQuery<Employees>("EXEC [dbo].[sp_GetStaffByCode] @staffCode", parmstaffCode).SingleOrDefault();
                lblCode.Text = employees.StaffCode;
                lblFullName.Text = employees.FullName;
                lblBirthDate.Text = string.Format("{0:dd-MM-yyyy}", employees.BirthDate);
                lblSex.Text = employees.Sex;
                lblDeptCode.Text = employees.DeptCode;
                lblEntryDate.Text = string.Format("{0:dd-MM-yyyy}", employees.EntryDate);
                lblPosName.Text = employees.PosName;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }

            SqlParameter subject = new SqlParameter() { ParameterName = "@staffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar };
            if (staffCode == null)
            {
                parmstaffCode.Value = DBNull.Value;
            }
            try
            {
                var reports = context.Database.SqlQuery<SkillMap>("EXEC [dbo].[sp_Get_Subjects_Of_StaffCode] @staffCode", subject).ToList();

                gridControl1.DataSource = reports;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
            {
                if (MessageBox.Show("Do you want to save the changes?", "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gridView1.IsEditing)
                        gridView1.CloseEditor();

                    if (gridView1.FocusedRowModified)
                        gridView1.UpdateCurrentRow();

                }
                else
                    e.Handled = true;
            }
        }
    }
}
