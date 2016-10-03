using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lib.Services;
using System;
using Lib.Forms.Helpers;
using Lib.Forms;

namespace GARecruitmentSystem
{
    public partial class FormInputResultInterview : XtraForm
    {
        private readonly ScoreService _scoreService;
        private readonly ResultsService _resultService;
        private readonly PositionService _positionService;
        private readonly DepartmentService _departmentService;
        private readonly EducationService _educationService;
        public FormInputResultInterview()
        {
            InitializeComponent();

            _scoreService = new ScoreService();
            _resultService = new ResultsService();
            _positionService = new PositionService();
            _departmentService = new DepartmentService();
            _educationService = new EducationService();

            LoadDataGridLookUpEdit();
            LoadDataGridLookUpEditPositions();
            LoadDataGridLookUpEditDepartments();
            LoadDataGridLookUpEditEducations();
        }

        private void LoadDataGridLookUpEdit()
        {
            var items = _scoreService.GetScoresIsOk();
            var collection = new AutoCompleteStringCollection();
            foreach (var item in items)
            {
                collection.Add(item.FullName);
            }
            gridLookUpEditFullName.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            gridLookUpEditFullName.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            gridLookUpEditFullName.MaskBox.AutoCompleteCustomSource = collection;

            gridLookUpEditFullName.Properties.DisplayMember = "FullName";
            gridLookUpEditFullName.Properties.ValueMember = "Id";
            gridLookUpEditFullName.Properties.PopupFormWidth = 500;
            gridLookUpEditFullName.Properties.DataSource = items;
        }
        private void LoadDataGridLookUpEditPositions()
        {
            var items = _positionService.GetPositions();
            var collection = new AutoCompleteStringCollection();
            foreach (var item in items)
            {
                collection.Add(item.PosName);
            }
            txtPosition.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPosition.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPosition.MaskBox.AutoCompleteCustomSource = collection;

            txtPosition.Properties.DisplayMember = "PosName";
            txtPosition.Properties.ValueMember = "PosCode";
            txtPosition.Properties.PopupFormWidth = 250;
            txtPosition.Properties.DataSource = items;
        }
        private void LoadDataGridLookUpEditDepartments()
        {
            var items = _departmentService.GetDepartments();
            var collection = new AutoCompleteStringCollection();
            foreach (var item in items)
            {
                collection.Add(item.DeptName);
            }
            txtDepartment.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDepartment.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDepartment.MaskBox.AutoCompleteCustomSource = collection;

            txtDepartment.Properties.DisplayMember = "DeptName";
            txtDepartment.Properties.ValueMember = "DeptCode";
            txtDepartment.Properties.PopupFormWidth = 300;
            txtDepartment.Properties.DataSource = items;
        }
        private void LoadDataGridLookUpEditEducations()
        {
            var items = _educationService.GetEducations();
            var collection = new AutoCompleteStringCollection();
            foreach (var item in items)
            {
                collection.Add(item.EduName);
            }
            gridLookUpEditEducation.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            gridLookUpEditEducation.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            gridLookUpEditEducation.MaskBox.AutoCompleteCustomSource = collection;

            gridLookUpEditEducation.Properties.DisplayMember = "EduName";
            gridLookUpEditEducation.Properties.ValueMember = "EduCode";
            gridLookUpEditEducation.Properties.PopupFormWidth = 300;
            gridLookUpEditEducation.Properties.DataSource = items;
        }
        private void AutocompleteString()
        {
            var items = _scoreService.GetScores();
            var collection = new AutoCompleteStringCollection();
            foreach (var item in items)
            {
                collection.Add(item.FullName);
            }

            txtDepartment.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDepartment.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDepartment.MaskBox.AutoCompleteCustomSource = collection;
            //txtDepartment.MaskBox.Sty
        }

        #region Event EditValueChanged
        private void gridLookUpEditFullName_EditValueChanged(object sender, System.EventArgs e)
        {
            if(gridLookUpEditFullName.EditValue != null)
            {
                Guid id = (Guid)gridLookUpEditFullName.EditValue;
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    var score = _scoreService.GetScoreById(id);
                    if (score != null)
                    {
                        lblScoreEye.Text = $"V={ score.ScoreEye }";
                        lblResultEye.Text = $"D={ score.KetQuaEye }";

                        lblScorePicture.Text = $"{score.ScorePicture}/7";
                        lblPercentPicture.Text = $"{score.PercentPicture}%";

                        lblTotalPear.Text = score.TotalPear.ToString();
                        lblTotalEven.Text = score.TotalEven.ToString();
                        lblDifference.Text = score.Difference.ToString();
                        lblPercent.Text = $"{score.Percent}%";

                        txtBirthday.Text = score.Birthday;
                        txtBirthday.Focus();
                        if (score.KetQua == "OK")
                        {
                            CheckTextBoxNullValue.SetBackColorSuccessMessage(lblResult, score.KetQua);
                        }
                        else if (score.KetQua == "NG")
                        {
                            CheckTextBoxNullValue.SetBackColorErrorMessage(lblResult, score.KetQua);
                        }
                    }

                }
            }

            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, gridLookUpEditFullName);
            
        }
        private void txtBirthday_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtBirthday))
            {
                string age = _resultService.GetAge(txtBirthday.Text);
                txtTuoi.Text = age;
            }
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, radioGroup1);
        }
        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtSDT);
        }

        private void txtNS_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtNS);
        }

        private void txtHKTT_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtHKTT);
        }

        private void txtDanToc_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtDanToc);
        }

        private void txtHight_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtHight);
        }

        private void txtCMT_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtCMT);
        }

        private void txtNgayCap_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtNgayCap);
        }

        private void txtNoiCap_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtNoiCap);
        }

        private void txtID_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtID);
        }

        private void txtStaffCode_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtStaffCode);
        }

        private void txtDepartment_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtDepartment);
        }

        private void txtPosition_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtPosition);
        }

        private void txtNgayPV_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtNgayPV);
        }

        private void txtNguoiPV_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtNguoiPV);
        }

        private void txtNgayDiLam_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtNgayDiLam);
        }
        private void gridLookUpEditEducation_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, gridLookUpEditEducation);
        }
        #endregion

        #region Event Validating Controls
        private void gridLookUpEditFullName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(gridLookUpEditFullName))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, gridLookUpEditFullName, toolTipController1, "Vui lòng chọn một ứng viên!");
            }
        }

        private void txtBirthday_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBirthday))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBirthday, toolTipController1, "Vui lòng nhập 'Ngày sinh' cho ứng viên!");
            }
            else
            {
                string age = _resultService.GetAge(txtBirthday.Text);
                if (int.Parse(age) < 18)
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBirthday, toolTipController1, $"Ứng viên '{gridLookUpEditFullName.Text}' chưa đủ độ tuổi lao động. Vui lòng kiểm tra lại!");
                }
            }
        }
        private void radioGroup1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (radioGroup1.EditValue == null)
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, radioGroup1, toolTipController1, "Vui lòng chọn 'Giới tính' cho ứng viên!");
            }
        }
 
        private void txtSDT_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtSDT))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtSDT, toolTipController1, "Vui lòng nhập vào 'Số điện thoại' của ứng viên!");
            }
        }
        private void txtNS_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNS))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNS, toolTipController1, "Vui lòng nhập vào 'Nơi sinh' của ứng viên!");
            }
        }

        private void txtHKTT_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtHKTT))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtHKTT, toolTipController1, "Vui lòng nhập vào 'Hộ khẩu thường chú' của ứng viên!");
            }
        }

        private void txtDanToc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtDanToc))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtDanToc, toolTipController1, "Vui lòng nhập vào 'Dân tộc' của ứng viên!");
            }
        }

        private void txtHight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtHight))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtHight, toolTipController1, "Vui lòng nhập vào 'Chiều cao' của ứng viên!");
            }
        }

        private void txtCMT_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtCMT))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtCMT, toolTipController1, "Vui lòng nhập vào 'Số chứng minh thư' của ứng viên!");
            }
            else
            {
                string value = txtCMT.Text;
                if(value.Length < 9 || value.Length > 10)
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtCMT, toolTipController1, "'Số chứng minh thư' không đúng định dạng. Vui lòng nhập lại!");
                }

                var result = _resultService.GetResultByCMT(value);
                if (result != null)
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtCMT, toolTipController1, $"'Số chứng minh thư' đã tồn tại '{result.FullName}-{result.CMT}'. Vui lòng kiểm tra lại!");
                }
            }
        }

        private void txtNgayCap_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNgayCap))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNgayCap, toolTipController1, "Vui lòng nhập vào 'Ngày cấp' chứng minh thư!");
            }
        }

        private void txtNoiCap_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNoiCap))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNoiCap, toolTipController1, "Vui lòng nhập vào 'Nơi cấp' chứng minh thư!");
            }
        }

        private void txtID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtID))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtID, toolTipController1, "Vui lòng nhập vào 'ID' cho ứng viên!");
            }
        }

        private void txtStaffCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtStaffCode))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtStaffCode, toolTipController1, "Vui lòng nhập vào 'Code' cho ứng viên!");
            }
        }

        private void txtDepartment_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtDepartment))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtDepartment, toolTipController1, "Vui lòng nhập vào 'Bộ phận' cho ứng viên!");
            }
        }

        private void txtPosition_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPosition))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtPosition, toolTipController1, "Vui lòng nhập vào 'Vị trí' cho ứng viên!");
            }
        }

        private void txtNgayPV_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNgayPV))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNgayPV, toolTipController1, "Vui lòng nhập vào 'Ngày phỏng vấn' ứng viên!");
            }
        }

        private void txtNguoiPV_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNguoiPV))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNguoiPV, toolTipController1, "Vui lòng nhập vào 'Người phỏng vấn' ứng viên!");
            }
        }

        private void txtNgayDiLam_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNgayDiLam))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNgayDiLam, toolTipController1, "Vui lòng nhập vào 'Ngày đi làm' cho ứng viên!");
            }
        }

        private void gridLookUpEditEducation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(gridLookUpEditEducation))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, gridLookUpEditEducation, toolTipController1, "Vui lòng chọn 'Tên trường' cho ứng viên!");
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(gridLookUpEditFullName))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, gridLookUpEditFullName, toolTipController1, "Vui lòng chọn một ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBirthday))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtBirthday, toolTipController1, "Vui lòng nhập vào 'Ngày sinh' cho ứng viên!");
            }
            else if (string.IsNullOrEmpty((string)radioGroup1.EditValue))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, radioGroup1, toolTipController1, "Vui lòng chọn 'Giới tính' cho ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtSDT))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtSDT, toolTipController1, "Vui lòng nhập vào 'Số điện thoại' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNS))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNS, toolTipController1, "Vui lòng nhập vào 'Nơi sinh' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtHKTT))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtHKTT, toolTipController1, "Vui lòng nhập vào 'Hộ khẩu thường chú' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtDanToc))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtDanToc, toolTipController1, "Vui lòng nhập vào 'Dân tộc' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtHight))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtHight, toolTipController1, "Vui lòng nhập vào 'Chiều cao' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtCMT))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtCMT, toolTipController1, "Vui lòng nhập vào 'Số chứng minh thư' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNgayCap))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNgayCap, toolTipController1, "Vui lòng nhập vào 'Ngày cấp' chứng minh thư!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNoiCap))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNoiCap, toolTipController1, "Vui lòng nhập vào 'Nơi cấp' chứng minh thư!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtID))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtID, toolTipController1, "Vui lòng nhập vào 'ID' cho ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtStaffCode))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtStaffCode, toolTipController1, "Vui lòng nhập vào 'Code' cho ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtDepartment))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtDepartment, toolTipController1, "Vui lòng nhập vào 'Bộ phận' cho ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPosition))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtPosition, toolTipController1, "Vui lòng nhập vào 'Vị trí' cho ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNgayPV))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNgayPV, toolTipController1, "Vui lòng nhập vào 'Ngày phỏng vấn' ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNguoiPV))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNguoiPV, toolTipController1, "Vui lòng nhập vào 'Người phỏng vấn' ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtNgayDiLam))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtNgayDiLam, toolTipController1, "Vui lòng nhập vào 'Ngày đi làm' của ứng viên!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(gridLookUpEditEducation))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, gridLookUpEditEducation, toolTipController1, "Vui lòng chọn 'Tên trường' cho ứng viên!");
            }
            else
            {
                try
                {
                    string id = gridLookUpEditFullName.EditValue.ToString();
                    _resultService.InsertResult(
                        id,
                        gridLookUpEditFullName.Text,
                        Ultils.ConvertStringToDateTime(txtBirthday),
                        radioGroup1.EditValue.ToString(),
                        txtSDT.Text,
                        txtNS.Text,
                        txtHKTT.Text,
                        txtDanToc.Text,
                        txtHight.Text,
                        txtCMT.Text,
                        Ultils.ConvertStringToDateTime(txtNgayCap),
                        txtNoiCap.Text,
                        txtExperiene.Text,
                        txtID.Text,
                        txtStaffCode.Text,
                        txtDepartment.EditValue.ToString(),
                        txtPosition.EditValue.ToString(),
                        Ultils.ConvertStringToDateTime(txtNgayPV),
                        txtNguoiPV.Text,
                        Ultils.ConvertStringToDateTime(txtNgayDiLam),
                        Program.CurentUser.UserName
                        );
                    _scoreService.Update(Guid.Parse(id), true);
                    btnReset.PerformClick();
                    dynamic mboxResult = XtraMessageBox.Show("Thêm thành công. Bạn có muốn thêm nữa không?",
                    "THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                    if (mboxResult == DialogResult.No)
                    {
                        Close();
                    }
                    else if (mboxResult == DialogResult.Yes)
                    {
                        LoadDataGridLookUpEdit();
                        gridLookUpEditFullName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gridLookUpEditFullName.EditValue = null;
            txtBirthday.ResetText();
            txtTuoi.ResetText();
            radioGroup1.SelectedIndex = -1;
            txtSDT.ResetText();
            txtNS.ResetText();
            txtHKTT.ResetText();
            txtDanToc.ResetText();
            txtHight.ResetText();
            txtCMT.ResetText();
            txtNgayCap.ResetText();
            txtNoiCap.ResetText();
            txtExperiene.ResetText();
            txtID.ResetText();
            txtStaffCode.ResetText();
            txtDepartment.EditValue = null;
            txtPosition.EditValue = null;
            txtNgayPV.ResetText();
            txtNguoiPV.ResetText();
            txtNgayDiLam.ResetText();

            lblDifference.Text = "0";
            lblPercent.Text = "0%";
            lblResult.ResetText();
            lblResultEye.Text = "D=0";
            lblScoreEye.Text = "V=0";
            lblTotalEven.Text = "0";
            lblTotalPear.Text = "0";
            lblScorePicture.Text = "0/7";
            lblPercentPicture.Text = "0%";
        }

        private void FormInputResultInterview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}