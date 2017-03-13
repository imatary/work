using System;
using System.ComponentModel;
using System.Windows.Forms;
using EducationSkills.Data;

namespace EducationSkills.Subjects
{
    public partial class FormAddSubject : DevExpress.XtraEditors.XtraForm
    {
        private readonly EducationSkillsDbContext context;
        PR_Bomon _subject = null;
        public FormAddSubject(string id)
        {
            InitializeComponent();
            context = new EducationSkillsDbContext();
            if (id != "")
            {
                lblTitle.Text = "Sửa môn học";
                _subject = SubjectDataProvider.GetSubjectById(id);
                txtSubjectID.Text = _subject.MaBoMon;
                txtSubjectName.Text = _subject.TenBoMon;
                txtSubjectID.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Thêm môn học";
                btnDel.Visible = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsNullOrEmptyControl(txtSubjectID))
            {
                MessageHelper.ErrorMessageBox("Mã môn không được bỏ trống!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtSubjectName))
            {
                MessageHelper.ErrorMessageBox("Tên môn không được bỏ trống!");
            }
            else
            {
                if (_subject != null)
                {
                    SubjectDataProvider.UpdateSubject(_subject.MaBoMon, txtSubjectName.Text.Trim());
                    MessageHelper.SuccessMessageBox("Sửa thành công!");
                    this.Dispose();
                }
                else
                {
                    try
                    {
                        SubjectDataProvider.InsertSubject(txtSubjectID.Text.Trim(), txtSubjectName.Text.Trim());
                        MessageHelper.SuccessMessageBox("Thêm thành công!");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ErrorMessageBox(ex.Message);
                    }
                }
            }
        }

        private void txtSubjectID_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubjectID.Text))
            {
                ValidationHelper.SetDefaultControl(txtSubjectID);
            }
        }

        private void txtSubjectName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubjectName.Text))
            {
                ValidationHelper.SetDefaultControl(txtSubjectName);
            }
        }

        private void txtSubjectID_Validating(object sender, CancelEventArgs e)
        {
            string subjectId = txtSubjectID.Text.Trim();
            if (!string.IsNullOrEmpty(subjectId))
            {
                var subject = SubjectDataProvider.GetSubjectById(subjectId);
                if (subject != null)
                {
                    ValidationHelper.IsExitsValueMessageBox(txtSubjectID ,"Mã môn này đã được tạo rồi. Vui lòng kiểm tra lại!");
                }
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string subjectId = txtSubjectID.Text.Trim();
            dynamic mboxResult = MessageBox.Show($"Bạn có là muốn xóa bộ môn '{subjectId}' không?",
                @"THÔNG BÁO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (mboxResult == DialogResult.Yes)
            {
                try
                {
                    SubjectDataProvider.DeleteSubjectById(subjectId);
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }

            }
        }
    }
}