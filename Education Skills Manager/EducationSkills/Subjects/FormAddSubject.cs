using System;
using System.ComponentModel;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Collections.Generic;
using System.Linq;

namespace EducationSkills.Subjects
{
    public partial class FormAddSubject : DevExpress.XtraEditors.XtraForm
    {
        private EducationSkillsDbContext context;
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
            GetDepartments();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetDepartments()
        {
            var dept = new Department { DeptCode = "Tất cả" };
            List<Department> departments = null;

            departments = context.Database.SqlQuery<Department>("EXEC [dbo].[sp_Get_All_Departments]").ToList();
            departments.Add(dept);

            txtDept.Properties.DataSource = departments;
            txtDept.Properties.DisplayMember = "DeptCode";
            txtDept.Properties.ValueMember = "DeptCode";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsNullOrEmptyControl(txtSubjectID))
            {
                dxErrorProvider1.ClearErrors();
                dxErrorProvider1.SetError(txtSubjectID, "Mã môn không được bỏ trống!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtSubjectName))
            {
                dxErrorProvider1.ClearErrors();
                dxErrorProvider1.SetError(txtSubjectName, "Tên môn không được bỏ trống!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(cboSubjectType))
            {
                dxErrorProvider1.ClearErrors();
                dxErrorProvider1.SetError(cboSubjectType, "Vui lòng chọn loại hình đào tạo!");
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
                        if (txtDept.Enabled == true)
                        {
                            SubjectDataProvider.InsertSubject(txtSubjectID.Text.Trim(), txtSubjectName.Text.Trim(), cboSubjectType.EditValue.ToString(), txtDept.EditValue.ToString());
                        }
                        else
                        {
                            SubjectDataProvider.InsertSubject(txtSubjectID.Text.Trim(), txtSubjectName.Text.Trim(), cboSubjectType.SelectedItem.ToString(), null);
                        }
                        
                        MessageHelper.SuccessMessageBox("Thêm thành công!");
                        this.Dispose();
                        lblDept.Enabled = false;
                        txtDept.Enabled = false;
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
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtSubjectName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubjectName.Text))
            {
                ValidationHelper.SetDefaultControl(txtSubjectName);
                dxErrorProvider1.ClearErrors();
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
                    lblDept.Enabled = false;
                    txtDept.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }

            }
        }

        private void cboSubjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSubjectType.EditValue.ToString()=="Đào tạo tại bộ phận")
            {
                lblDept.Enabled = true;
                txtDept.Enabled = true;
                txtDept.Focus();
            }
            if (cboSubjectType.EditValue.ToString() == "Đào tạo toàn công ty")
            {
                lblDept.Enabled = false;
                txtDept.Enabled = false;
            }
         }
    }
}