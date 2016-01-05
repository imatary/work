using System;
using System.Windows.Forms;
using VAT.Services;

namespace VAT
{
    public partial class FormCustomers : Form
    {
        private readonly CustomerService _customerService;
        public FormCustomers()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = _customerService.GetCustomers();
        }

        private void btnResetText_Click(object sender, System.EventArgs e)
        {
            txtCustCode.Enabled = true;

            txtCustCode.ResetText();
            txtCustName.ResetText();
            txtAddress.ResetText();
            txtTaxCode.ResetText();
            txtTel.ResetText();
            txtFax.ResetText();
            txtPartName.ResetText();
            txtBuyer.ResetText();
            txtCusName.ResetText();
            txtPayType.ResetText();
            txtPayTerm.ResetText();
            txtCodeTax.ResetText();
            txtCurrency.ResetText();
            txtDelTerm.ResetText();
            txtDelPlace.ResetText();
            txtNamePart.ResetText();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                _customerService.InsertOrUpdate(
                    txtCustCode.Text,
                    txtCustName.Text,
                    txtAddress.Text,
                    txtCodeTax.Text,
                    txtTel.Text,
                    txtFax.Text,
                    txtPartName.Text,
                    txtBuyer.Text,
                    txtCusName.Text,
                    txtPayType.Text,
                    txtPayTerm.Text,
                    txtCurrency.Text,
                    txtTaxCode.Text,
                    txtDelTerm.Text,
                    txtDelPlace.Text,
                    txtNamePart.Text
                    );

                MessageBox.Show("Thành công");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Data.Customer _customer;
        private void btnDel_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Bán có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    _customerService.Delete(_customer.CUST_CODE);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                DialogResult = DialogResult.No;
            } 
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var custCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            _customer = _customerService.GetCustomerByCustCode(custCode);

            txtCustCode.Text = _customer.CUST_CODE;
            txtCustName.Text = _customer.CUST_NAME;
            txtAddress.Text = _customer.ADDRESS;
            txtTaxCode.Text = _customer.TAX_CODE;
            txtTel.Text = _customer.TEL;
            txtFax.Text = _customer.FAX;
            txtPartName.Text = _customer.NAME_PART;
            txtBuyer.Text = _customer.BUYER;
            txtCusName.Text = _customer.NAME_CUS;
            txtPayType.Text = _customer.PAY_TYPE;
            txtPayTerm.Text = _customer.PAY_TERM;
            txtCodeTax.Text = _customer.CODE_TAX;
            txtCurrency.Text = _customer.CURRENCY;
            txtDelTerm.Text = _customer.DEL_TERM;
            txtDelPlace.Text = _customer.DEL_PLACE;
            txtNamePart.Text = _customer.NAME_PART1;

            txtCustCode.Enabled = false;
            btnDel.Enabled = true;
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
                case Keys.Control | Keys.N:
                    {
                        btnResetText.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.D:
                    {
                        btnDel.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
