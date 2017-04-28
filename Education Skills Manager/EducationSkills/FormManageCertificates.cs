using EducationSkills.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace EducationSkills
{
    public partial class FormManageCertificates : Form
    {
        private EducationSkillsDbContext context;
        public FormManageCertificates()
        {
            InitializeComponent();
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

                    //var olympic = context.EDU_Olympics.SingleOrDefault(m => m.StaffCode == staffCode);
                    //if (olympic != null)
                    //{
                    //    txtTestContent.EditValue = olympic.TestContent;
                    //    txtTestNumber.Text = olympic.TestNumber.ToString();
                    //    txtTestDate.DateTime = olympic.TestDate;
                    //    txtTestResults.EditValue = olympic.TestResults;
                    //}
                    //else
                    //{
                        //txtTestContent.EditValue = null;
                        //txtTestContent.ResetText();
                        //txtTestNumber.ResetText();
                        //txtTestDate.ResetText();
                        //txtTestResults.EditValue = null;
                        //txtTestResults.ResetText();
                    //}

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
        /// <summary>
        /// 
        /// </summary>
        private void ResetTextControls()
        {
            lblCode.Text = "[N/A]";
            lblFullName.Text = "[N/A]";
            lblBirthDate.Text = "[N/A]";
            lblSex.Text = "[N/A]";
            lblDeptCode.Text = "[N/A]";
            lblEntryDate.Text = "[N/A]";
            lblPosName.Text = "[N/A]";

            txtTrainingContent.EditValue = null;
            txtTrainingContent.ResetText();

            txtTrainingType.ResetText();
            txtTrainingStartDate.ResetText();
            txtTrainingEndDate.ResetText();
            txtCertificate.ResetText();
            txtDeadline.ResetText();
            txtNote.ResetText();

            txtSearchKey.ResetText();
            txtSearchKey.Focus();
        }
        private void FormAddOlympic_Load(object sender, EventArgs e)
        {
            //txtTrainingStartDate.DateTime = DateTime.Now;
            txtSearchKey.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(lblCode.Text == @"[N/A]")
            {
                MessageHelper.ErrorMessageBox("Vui lòng chọn một nhân viên!");
                txtSearchKey.SelectAll();
                txtSearchKey.Focus();
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtTrainingContent))
            {
                ValidationControls(txtTrainingContent);
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtTrainingType))
            {
                ValidationControls(txtTrainingType);
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtTrainingStartDate))
            {
                ValidationControls(txtTrainingStartDate);
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtTrainingEndDate))
            {
                ValidationControls(txtTrainingEndDate);
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtCertificate))
            {
                ValidationControls(txtCertificate);
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtDeadline))
            {
                ValidationControls(txtDeadline);
            }
            else
            {
                //var olympic = context.EDU_Olympics.SingleOrDefault(m => m.StaffCode == lblCode.Text);
                //if(olympic == null)
                //{
                var certificate = new EDU_ManageCertificates()
                {
                    StaffCode = lblCode.Text,
                    TrainingContent = txtTrainingContent.Text,
                    TrainingType = txtTrainingType.EditValue.ToString(),
                    TrainingStartDate = txtTrainingStartDate.DateTime,
                    TraingEndDate = txtTrainingEndDate.DateTime,
                    Certificate = txtCertificate.Text,
                    DeadlineCertificate = int.Parse(txtDeadline.Text),
                    Note = txtNote.Text
                };

                try
                {
                    context.EDU_ManageCertificates.Add(certificate);
                    context.SaveChanges();
                    MessageHelper.SuccessMessageBox("Lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }
                //}
                //else
                //{
                //    olympic.TestContent = txtTestContent.Text;
                //    olympic.TestNumber = int.Parse(txtTestNumber.Text);
                //    olympic.TestDate = txtTestDate.DateTime;
                //    olympic.TestResults = txtTestResults.Text;

                //    try
                //    {
                //        using (var context = new EducationSkillsDbContext())
                //        {
                //            context.EDU_Olympics.Attach(olympic);
                //            context.Entry(olympic).State = EntityState.Modified;
                //            context.SaveChanges();
                //        }
                //        MessageHelper.SuccessMessageBox("Lưu thành công!");
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageHelper.ErrorMessageBox(ex.Message);
                //    }

                //}
                ResetTextControls();
            }
            
        }

        private void txtSearchKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string staffCode = txtSearchKey.Text;
                if (Ultils.IsNull(staffCode))
                {
                    LoadData(staffCode);
                    txtTrainingContent.Focus();
                }
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
                    txtTrainingContent.Focus();
                }
            }
        }

        private void txtTrainingStartDate_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrainingStartDate.EditValue.ToString()))
            {
                txtTrainingEndDate.DateTime = txtTrainingStartDate.DateTime.AddDays(365);
                ValidationHelper.SetDefaultControl(txtTrainingStartDate);
                dxErrorProvider1.ClearErrors();
            }
        }

        private void ValidationControls(BaseEdit controls)
        {
            dxErrorProvider1.ClearErrors();
            dxErrorProvider1.SetError(controls, "Please enter value!");
        }

        private void txtTrainingContent_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrainingContent.Text))
            {
                ValidationHelper.SetDefaultControl(txtTrainingContent);
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtTrainingType_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrainingType.Text))
            {
                ValidationHelper.SetDefaultControl(txtTrainingType);
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtTrainingEndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrainingEndDate.Text))
            {
                ValidationHelper.SetDefaultControl(txtTrainingEndDate);
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtCertificate_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCertificate.Text))
            {
                ValidationHelper.SetDefaultControl(txtCertificate);
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtDeadline_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDeadline.Text))
            {
                ValidationHelper.SetDefaultControl(txtDeadline);
                dxErrorProvider1.ClearErrors();
            }
        }
    }
}
