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
                string strDate = null;
                if (gridView1.GetRowCellValue(i, "NgayThamGia") != null)
                {
                    strDate = gridView1.GetRowCellValue(i, "NgayThamGia").ToString();
                }
                string note = (string)gridView1.GetRowCellValue(i, "GhiChu");
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
                SqlParameter parmNgayThamGia = new SqlParameter
                {
                    ParameterName = "@NgayThamGia",
                    SqlDbType = SqlDbType.DateTime
                };
                if(gridView1.GetRowCellValue(i, "NgayThamGia") != null)
                {
                    parmNgayThamGia.Value = DateTime.Parse(strDate);
                    parmNgayThamGia.SqlDbType = SqlDbType.DateTime;
                }
                else
                {
                    parmNgayThamGia.Value = DBNull.Value;
                }

                SqlParameter parmNote = new SqlParameter() { ParameterName = "@GhiChu", Value = note, SqlDbType = SqlDbType.NVarChar };
                if (note == null)
                {
                    parmNote.Value = DBNull.Value;
                }
                try
                {
                    if(gridView1.GetRowCellValue(i, "NgayThamGia") != null)
                    {
                        if (DateTime.Parse(strDate) > DateTime.Now)
                        {
                            MessageHelper.ErrorMessageBox("Ngày tham gia không được lớn hơn ngày hiện tại. Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (DateTime.Parse(strDate) < DateTime.Parse(lblEntryDate.Text))
                        {
                            MessageHelper.ErrorMessageBox("Ngày tham gia không được nhỏ hơn ngày vào làm. Vui lòng kiểm tra lại!");
                            return;
                        }
                    }
                    
                    using (var dbcontext = new EducationSkillsDbContext())
                    {
                        dbcontext.Database.ExecuteSqlCommand("EXEC [dbo].[UpdateSkillMap] @StaffCode,@MaBoMon,@NgayThamGia,@GhiChu", parmstaffCode, mabomon, parmNgayThamGia, parmNote);
                    }
                    record++;
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }
                //}
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

            SqlParameter parmstaffCode = new SqlParameter() { ParameterName = "@staffCode", SqlDbType = SqlDbType.VarChar };
            if (staffCode == null)
            {
                parmstaffCode.Value = DBNull.Value;
            }
            else
            {
                parmstaffCode.Value = staffCode;
            }
            try
            {
                var employees = context.Database.SqlQuery<Employees>("EXEC [dbo].[sp_GetStaffByCode] @staffCode", parmstaffCode).SingleOrDefault();
                if (employees != null)
                {
                    lblCode.Text = employees.StaffCode;
                    lblFullName.Text = employees.FullName;
                    lblBirthDate.Text = string.Format("{0:dd-MM-yyyy}", employees.BirthDate);
                    lblSex.Text = employees.Sex;
                    lblDeptCode.Text = employees.DeptCode;
                    lblEntryDate.Text = string.Format("{0:MM/dd/yyyy}", employees.EntryDate);
                    lblPosName.Text = employees.PosName;

                    string type = "Đào tạo toàn công ty";
                    object[] paramSubjects =
                    {
                        new SqlParameter() { ParameterName = "@type", Value = type, SqlDbType = SqlDbType.NVarChar},
                        new SqlParameter() { ParameterName = "@dept", Value = DBNull.Value, SqlDbType = SqlDbType.NVarChar},
                        new SqlParameter("@Out_Parameter", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        }
                    };

                    var subjects = context.Database.SqlQuery<PR_Bomon>("EXEC [dbo].[ShowBoMon] @type, @dept", paramSubjects).ToList();

                    foreach (var sub in subjects)
                    {
                        object[] param =
                        {
                            new SqlParameter() { ParameterName = "@staffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                            new SqlParameter() { ParameterName = "@MaBoMon", Value=sub.MaBoMon, SqlDbType = SqlDbType.VarChar },
                            new SqlParameter("@Out_Parameter", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            }
                        };
                        var checkExits = context.Database.SqlQuery<SkillMap>("EXEC [dbo].[CheckStaffCodeExitsSkillMap] @staffCode,@MaBoMon", param).SingleOrDefault();
                        if (checkExits == null)
                        {
                            object[] param2 =
                            {
                                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                                new SqlParameter() { ParameterName = "@MaMon", Value=sub.MaBoMon, SqlDbType = SqlDbType.VarChar },
                                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                }
                            };
                            try
                            {
                                context.Database.ExecuteSqlCommand("EXEC [dbo].[InsertSkillMap] @StaffCode,@MaMon", param2);
                            }
                            catch (Exception ex)
                            {
                                MessageHelper.ErrorMessageBox(ex.Message);
                            }
                            
                        } 
                    }

                    object[] paramOffStaffCode =
                        {
                            new SqlParameter() { ParameterName = "@staffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                            new SqlParameter("@Out_Parameter", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            }
                        };
                    try
                    {
                        var reports = context.Database.SqlQuery<SkillMap>("EXEC [dbo].[sp_Get_Subjects_Of_StaffCode] @staffCode", paramOffStaffCode).ToList();

                        gridControl1.DataSource = reports;
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ErrorMessageBox(ex.Message);
                    }
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.CloseWaitForm();
                    MessageHelper.ErrorMessageBox($"Không tìm thấy nhân viên với code: [{staffCode}]. Vui lòng kiểm tra lại!");
                }
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                MessageHelper.ErrorMessageBox(ex.Message);
            }

            
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

        private void txtSearchKey_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                string staffCode = txtSearchKey.Text;
                if (Ultils.IsNull(staffCode))
                {
                    LoadData(staffCode);
                    
                }


            }
        }

        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string staffCode = txtSearchKey.Text;
                if (Ultils.IsNull(staffCode))
                {
                    LoadData(staffCode);
                }
            }
        }
    }
}
