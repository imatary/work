using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormInsertOrUpdateUnit : XtraForm
    {
        private readonly UnitService _unitService;
        private readonly LogService _logService;
        private readonly UserService _userService;
        private Unit _unit;

        private string _unitId;
        public FormInsertOrUpdateUnit(string unitId)
        {
            InitializeComponent();

            _unitService = new UnitService();
            _logService = new LogService();
            _unitId = unitId;

        }

        private void FormInsertOrUpdateUnit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show(Resources.MessageBoxColseForm,
                    Resources.MessageBoxTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (mboxResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (mboxResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitID.Text))
            {
                Ultils.TextControlNotNull(txtUnitID, "Mã Đơn Vị");
            }
            else if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                Ultils.TextControlNotNull(txtUnitName, "Tên Đơn Vị");
            }
            else
            {
                if (string.IsNullOrEmpty(_unitId))
                {
                    
                    _unit = new Unit()
                    {
                        UnitID = txtUnitID.Text.Trim(),
                        UnitName = txtUnitName.Text,
                        Active = checkActive.Checked,
                        CreatedDate = DateTime.Now,
                        CreatedBy = Program.CurrentUser.Username,
                    };
                    try
                    {
                        if (_unitService.CheckUnitIdExit(_unit.UnitID))
                        {
                            _unitService.Add(_unit);
                            _logService.InsertLog(Program.CurrentUser.Username, "Thêm", this.Text);
                            MessageBoxHelper.ShowMessageBoxSuccess("Thêm thành công!");
                            ResetControls();
                        }
                        else
                        {
                            MessageBoxHelper.ShowMessageBoxError(string.Format("Mã Đơn vị <{0}> này đã được tạo rồi!", _unit.UnitID));
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowMessageBoxError(ex.Message);
                    }

                }
                else
                {
                    _unit = _unitService.GetUnitById(_unitId);
                    if (_unitId != null)
                    { 
                        _unit.UnitName = txtUnitName.Text;
                        _unit.Description = txtDescription.Text;
                        _unit.Active = checkActive.Checked;
                        _unit.ModifyDate = DateTime.Now;
                        _unit.ModifyBy = Program.CurrentUser.Username;

                        try
                        {
                            _unitService.Update(_unit);
                            MessageBoxHelper.ShowMessageBoxSuccess("Sửa thành công!");
                            ResetControls();
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowMessageBoxError(ex.Message);
                        }
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Resources.MessageBoxColseForm, Resources.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        

        private void txtUnitID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab|| e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                if (!_unitService.CheckUnitIdExit(txtUnitID.Text))
                {
                    Ultils.SetColorErrorTextControl(txtUnitID, string.Format("ID {0} này đã tồn tại!", txtUnitID.Text));
                }
                else
                {
                    Ultils.SetColorDefaultTextControl(txtUnitID);
                }
                txtUnitName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUnitID.Text = "";
            }
        }

        private void txtUnitID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                if (!_unitService.CheckUnitIdExit(txtUnitID.Text))
                {
                    Ultils.SetColorErrorTextControl(txtUnitID, string.Format("ID {0} này đã tồn tại!", txtUnitID.Text));
                }
                else
                {
                    Ultils.SetColorDefaultTextControl(txtUnitID);
                }
            }
        }

        private void txtUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUnitName.Text = string.Empty;
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDescription.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtUnitName.SelectAll();
                txtUnitName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
        }

        private void ResetControls()
        {
            _unitId = null;
            txtUnitID.Enabled = true;
            txtUnitID.Text = string.Empty;
            txtUnitName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    {
                        btnSave.PerformClick();
                        return true;
                    }
                case Keys.Escape:
                    {
                        btnClose.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormInsertOrUpdateUnit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(_unitId))
            {
                txtUnitID.Enabled = false;
                _unit = _unitService.GetUnitById(_unitId);
                txtUnitID.Text = _unit.UnitID;
                txtUnitName.Text = _unit.UnitName;
                txtDescription.Text = _unit.Description;
                checkActive.Checked = _unit.Active;
            }  
        }
 
    }
}