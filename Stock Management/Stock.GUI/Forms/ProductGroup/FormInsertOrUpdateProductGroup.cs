using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormInsertOrUpdateProductGroup : XtraForm
    {
        private readonly LogService _logService;
        private readonly ProductGroupService _productGroupService;
        private ProductGroup _productGroup;

        private string _productGroupId;

        public FormInsertOrUpdateProductGroup(string productGroupId)
        {
            InitializeComponent();

            _logService = new LogService();
            _productGroupService = new ProductGroupService();

            _productGroupId = productGroupId;
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(_productGroupId))
            {
                _productGroup = _productGroupService.GetProductGrouprById(_productGroupId);
                txtProductGroupID.Text = _productGroupId;
                txtProductGroupName.Text = _productGroup.ProductGroupName;
                txtDescription.Text = _productGroup.Description;
                checkActive.Checked = _productGroup.Active;
            }
            else
            {
                txtProductGroupID.Text = _productGroupService.NextId();
            }
        }

        private void FormInsertOrUpdateProductGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormInsertOrUpdateProductGroup_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtProductGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtProductGroupName.Text = string.Empty;
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
                txtProductGroupName.SelectAll();
                txtProductGroupName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductGroupID.Text))
            {
                Ultils.TextControlNotNull(txtProductGroupID, "Mã Nhóm Hàng");
            }
            else if (string.IsNullOrEmpty(txtProductGroupName.Text))
            {
                Ultils.TextControlNotNull(txtProductGroupName, "Tên Nhóm Hàng");
            }
            else
            {
                if (string.IsNullOrEmpty(_productGroupId))
                {
                    _productGroup = new ProductGroup()
                    {
                        ProductGroupID = txtProductGroupID.Text.Trim(),
                        ProductGroupName = txtProductGroupName.Text,
                        Active = checkActive.Checked,
                        CreatedDate = DateTime.Now,
                        CreatedBy = Program.CurrentUser.Username,
                    };
                    try
                    {
                        _productGroupService.Add(_productGroup);
                        _logService.InsertLog(Program.CurrentUser.Username, "Thêm", this.Text);
                        MessageBoxHelper.ShowMessageBoxSuccess("Thêm thành công!");
                        ResetControls();
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowMessageBoxError(ex.Message);
                    }

                }
                else
                {
                    _productGroup = _productGroupService.GetProductGrouprById(_productGroupId);
                    if (_productGroupId != null)
                    {
                        _productGroup.ProductGroupName = txtProductGroupName.Text;
                        _productGroup.Description = txtDescription.Text;
                        _productGroup.Active = checkActive.Checked;
                        _productGroup.ModifyDate = DateTime.Now;
                        _productGroup.ModifyBy = Program.CurrentUser.Username;

                        try
                        {
                            _productGroupService.Update(_productGroup);
                            _logService.InsertLog(Program.CurrentUser.Username, "Sửa", this.Text);
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


        private void ResetControls()
        {
            _productGroupId = null;

            txtProductGroupID.Text = _productGroupService.NextId();
            txtProductGroupName.Text = string.Empty;
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
    }
}