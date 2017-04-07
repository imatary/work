using EducationSkills.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class FormImports : Form
    {
        private EducationSkillsDbContext context;
        List<string> items = new List<string>();
        public FormImports(List<string> staffCodes)
        {
            InitializeComponent();
           
            items = staffCodes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            context = new EducationSkillsDbContext();
            if (!ValidationHelper.IsNullOrEmptyControl(cboLevel))
            {
                MessageHelper.ErrorMessageBox("Vui lòng chọn cấp độ!");
            }
            else if(checkEditEye.Checked==false && checkEditSolder.Checked == false)
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập đầy đủ thông tin!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtCertificate))
            {
                MessageHelper.ErrorMessageBox("Vui lòng chọn một chứng chỉ!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(dateEditTestDate))
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập vào Ngày cấp!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(dateEditDateConfirmed))
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập vào Ngày xác thực!");
            }
            else
            {
                foreach (var item in items)
                {
                    // Hàn = check
                    // Mắt = no check
                    if (checkEditSolder.CheckState == CheckState.Checked && checkEditEye.CheckState == CheckState.Unchecked)
                    {
                        EducationSkillDataProviders.InsertSolder(cboLevel.SelectedIndex, item, txtCertificate.Text, (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);
                    }
                    // Hàn = no check
                    // Mắt = check
                    else if (checkEditSolder.CheckState == CheckState.Unchecked && checkEditEye.CheckState == CheckState.Checked)
                    {
                        EducationSkillDataProviders.InsertEye(cboLevel.SelectedIndex, item, txtCertificate.Text, (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);
                    }
                    // Cả hai cùng Check
                    else if (checkEditSolder.CheckState == CheckState.Checked && checkEditEye.CheckState == CheckState.Checked)
                    {
                        // Hàn
                        EducationSkillDataProviders.InsertSolder(cboLevel.SelectedIndex, item, txtCertificate.Text, (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);

                        // Mắt
                        EducationSkillDataProviders.InsertEye(cboLevel.SelectedIndex, item, txtCertificate.Text, (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);

                    }
                }

                MessageHelper.SuccessMessageBox("Lưu thành công!");
                this.Close();
            }
        }

        

        private void FormImports_Load(object sender, EventArgs e)
        {
            dateEditDateConfirmed.DateTime = DateTime.Now;
            dateEditTestDate.DateTime = DateTime.Now;
            GetCertificates();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetCertificates()
        {
            context = new EducationSkillsDbContext();
            List<EDU_Certificates> certificates = new List<EDU_Certificates>();
            if (checkEditEye.Checked == false && checkEditSolder.Checked==false)
            {
                certificates = context.EDU_Certificates.OrderBy(c => c.DisplayMember).ToList();
            }
            if (checkEditEye.Checked == true && checkEditSolder.Checked == false)
            {
                certificates = context.EDU_Certificates.Where(m => m.Type == "Eye").OrderBy(c => c.DisplayMember).ToList();
            }
            if (checkEditEye.Checked == false && checkEditSolder.Checked == true)
            {
                certificates = context.EDU_Certificates.Where(m => m.Type == "Solder").OrderBy(c => c.DisplayMember).ToList();
            }
            if (checkEditEye.Checked == true && checkEditSolder.Checked == true)
            {
                certificates = context.EDU_Certificates.OrderBy(c => c.DisplayMember).ToList();
            }

            txtCertificate.Properties.DisplayMember = "DisplayMember";
            txtCertificate.Properties.ValueMember = "ValueMember";
            txtCertificate.Properties.DataSource = certificates;
        }

        private void txtCertificate_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                new Certificates().ShowDialog();
                GetCertificates();
            }
        }

        private void dateEditTestDate_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dateEditTestDate.EditValue.ToString()))
            {
                dateEditDateConfirmed.DateTime = dateEditTestDate.DateTime.AddDays(365);
            }
        }

        private void cboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Ultils.IsNull(cboLevel.EditValue.ToString()))
            //{
            //    MessageBox.Show(cboLevel.SelectedIndex.ToString());
            //}
        }

        private void checkEditSolder_CheckedChanged(object sender, EventArgs e)
        {
            GetCertificates();
        }

        private void checkEditEye_CheckedChanged(object sender, EventArgs e)
        {
            GetCertificates();
        }
    }
}
