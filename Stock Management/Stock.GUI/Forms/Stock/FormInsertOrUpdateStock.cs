using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.GUI.Helper;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormInsertOrUpdateStock : XtraForm
    {
        private readonly StockService _stockService;
        private readonly LogService _logService;
        private readonly UserService _userService;
        private Data.Stock _stock;

        private string _stockId;
        public FormInsertOrUpdateStock(string stockId)
        {
            InitializeComponent();

            _stockService = new StockService();
            _logService = new LogService();
            _stockId = stockId;
        }




        private void FormInsertOrUpdateStock_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(txtStockID.Text))
            {
                Ultils.TextControlNotNull(txtStockID, "Mã Kho Hàng");
            }
            else if (string.IsNullOrEmpty(txtStockName.Text))
            {
                Ultils.TextControlNotNull(txtStockName, "Tên Kho Hàng");
            }
            else
            {
                if (string.IsNullOrEmpty(_stockId))
                {
                    _stock = new Data.Stock()
                    {
                        StockID = _stockService.NextId(),
                        StockName = txtStockName.Text,
                        Active = checkActive.Checked,
                        CreatedDate = DateTime.Now,
                        CreatedBy = Program.CurrentUser.Username,
                    };
                    try
                    {
                        _stockService.Add(_stock);
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
                    _stock = _stockService.GetStockById(_stockId);
                    if (_stockId != null)
                    {
                        _stock.StockName = txtStockName.Text;
                        _stock.Description = txtDescription.Text;
                        _stock.Active = checkActive.Checked;
                        _stock.ModifyDate = DateTime.Now;
                        _stock.ModifyBy = Program.CurrentUser.Username;

                        try
                        {
                            _stockService.Update(_stock);
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

        

        private void txtStockID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab|| e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                if (!_stockService.CheckStockIdExit(txtStockID.Text))
                {
                    Ultils.SetColorErrorTextControl(txtStockID, string.Format("ID {0} này đã tồn tại!", txtStockID.Text));
                }
                else
                {
                    Ultils.SetColorDefaultTextControl(txtStockID);
                }
                txtStockName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtStockID.Text = "";
            }
        }

        //private void txtStockID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Tab)
        //    {
        //        if (!_stockService.CheckStockIdExit(txtStockID.Text))
        //        {
        //            Ultils.SetColorErrorTextControl(txtStockID, string.Format("ID {0} này đã tồn tại!", txtStockID.Text));
        //        }
        //        else
        //        {
        //            Ultils.SetColorDefaultTextControl(txtStockID);
        //        }
        //    }
        //}

        private void txtStockName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtStockName.Text = string.Empty;
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
                txtStockName.SelectAll();
                txtStockName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
        }

        private void ResetControls()
        {
            _stockId = null;
            txtStockID.Enabled = true;
            txtStockID.Text = string.Empty;
            txtStockName.Text = string.Empty;
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

        private void FormInsertOrUpdateStock_Load(object sender, EventArgs e)
        {
            txtStockID.Text = _stockService.NextId();
            LoadData();
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(_stockId))
            {
                txtStockID.Enabled = false;
                
                _stock = _stockService.GetStockById(_stockId);
                txtStockID.Text = _stock.StockID;
                txtStockName.Text = _stock.StockName;
                txtDescription.Text = _stock.Description;
                checkActive.Checked = _stock.Active;
            }  
        }
    }
}