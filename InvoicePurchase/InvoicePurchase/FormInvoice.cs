using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using InvoicePurchase.Service;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace InvoicePurchase
{
    public partial class FormInvoice : Form
    {
        private readonly CustomerService _customerService;
        public FormInvoice()
        {
            _customerService = new CustomerService();
            InitializeComponent();
            LoadGirdLookUpCustomers();
        }

        private void LoadGirdLookUpCustomers()
        {
            List<Data.Customer> customers = _customerService.GetCustomers();
            gridLookUpEditCustomer.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditCustomer.Properties.DisplayMember = "CUST_NAME";
            gridLookUpEditCustomer.Properties.ValueMember = "CUST_CODE";
            gridLookUpEditCustomer.Properties.View.BestFitColumns();
            gridLookUpEditCustomer.Properties.PopupFormWidth = 400;
            gridLookUpEditCustomer.Properties.DataSource = customers;
        }

        private Data.Customer _customer;
        private void gridLookUpEditCustomer_EditValueChanged(object sender, System.EventArgs e)
        {
            string custCode = gridLookUpEditCustomer.EditValue.ToString();
            if (!string.IsNullOrEmpty(custCode))
            {
                 _customer = _customerService.GetCustomerByCustCode(custCode);

                txtCustCode.Text = _customer.CUST_CODE;
                txtCustName.Text = _customer.CUST_NAME;
                txtAddress.Text = _customer.ADDRESS;
                txtCodeTax.Text = _customer.CODE_TAX;
                txtTel.Text = _customer.TEL;
                txtFax.Text = _customer.FAX;
                txtPartName.Text = _customer.NAME_PART;
                txtCusName.Text = _customer.NAME_CUS;
                txtPayType.Text = _customer.PAY_TYPE;
                txtPayTerm.Text = _customer.PAY_TERM;
                txtCurrency.Text = _customer.CURRENCY;
                txtTaxCode.Text = _customer.TAX_CODE;
                txtDelTerm.Text = _customer.DEL_TERM;
                txtDelPlace.Text = _customer.DEL_PLACE;
                txtNamePart.Text = _customer.NAME_PART1;
                txtBuyerName.Text = _customer.BUYER;


                btnExportExel.Enabled = true;
            }

            
        }

        private void btnExportExel_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bán có chắc muốn in hóa đơn?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if ((!string.IsNullOrEmpty(txtForm.Text)) || (!string.IsNullOrEmpty(txtTo.Text)) ||
                (String.CompareOrdinal(txtForm.Text, txtTo.Text)) > 0)
                {
                    XtraMessageBox.Show("Nhập sai", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //var  app = (Microsoft.Office.Interop.Excel.Application) Marshal.GetActiveObject("Excel.Application");
                    var app = new Microsoft.Office.Interop.Excel.Application {Visible = false};

                    string path = Path.Combine(Environment.CurrentDirectory, @"Yokowo.xls");
                    object missingValue = System.Reflection.Missing.Value;

                    Workbook book = app.Workbooks.Open(path, missingValue,
                                                        false,
                                                        missingValue,
                                                        missingValue,
                                                        missingValue,
                                                        true,
                                                        missingValue,
                                                        missingValue,
                                                        true,
                                                        missingValue,
                                                        missingValue,
                                                        missingValue);



                    var sheet = (Worksheet)book.Worksheets[5];
                    
                    // day
                    Range date = sheet.Range["E8", "E8"];
                    date.Value2 = DateTime.Now.Date.Day;

                    // month
                    Range month = sheet.Range["G8", "G8"];
                    month.Value2 = DateTime.Now.Date.Month;

                    // day
                    Range year = sheet.Range["H8", "H8"];
                    year.Value2 = DateTime.Now.Date.Year;

                    Range cusName = sheet.Range["F12", "F12"];
                    cusName.Value2 = txtCusName.Text;


                    // cust name
                    Range custName = sheet.Range["D13", "D13"];
                    custName.Value2 = txtCustName.Text;

                    // address
                    Range address = sheet.Range["D14", "D14"];
                    address.Value2 = txtAddress.Text;

                    // tax code
                    Range taxCode = sheet.Range["D15", "D15"];
                    taxCode.Value2 = txtTaxCode.Text;

                    // Del Term
                    Range delTerm = sheet.Range["E16", "E16"];
                    delTerm.Value2 = txtDelTerm.Text;

                    // Del Place
                    Range delPlace = sheet.Range["D17", "D17"];
                    delPlace.Value2 = txtDelPlace.Text;

                    // name buyer
                    Range buyerName = sheet.Range["B18", "B18"];
                    buyerName.Value2 = txtBuyerName.Text;

                    // Tel
                    Range tel = sheet.Range["F18", "F18"];
                    tel.Value2 = txtTel.Text;

                    // fax
                    Range fax = sheet.Range["H18", "H18"];
                    fax.Value2 = txtFax.Text;

                    // pay type
                    Range payType = sheet.Range["G49", "G49"];
                    payType.Value2 = txtPayType.Text;

                    // pay term
                    Range payTerm = sheet.Range["G51", "G51"];
                    payTerm.Value2 = txtPayTerm.Text;

                    // currency
                    Range currency = sheet.Range["I52", "I52"];
                    currency.Value2 = _customer.CURRENCY;


                    //book.RefreshAll();
                    app.Calculate();
                    book.Save();
                    book.Close(true, null, null);
                    app.Quit();

                    System.Diagnostics.Process.Start(path);
                }
            }
            else
            {
                DialogResult = DialogResult.No;
            }           
        }

        private void gridLookUpEditCustomer_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index >= 1)
            {
                var customer = new FormCustomer();
                customer.Show();
                LoadGirdLookUpCustomers();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customer = new FormCustomer();
            customer.Show();
            LoadGirdLookUpCustomers();
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            gridLookUpEditCustomer.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.E:
                    {
                        btnExportExel.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.N:
                    {
                        btnAddCustomer.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
