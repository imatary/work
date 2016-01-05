using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using InvoicePurchase.Service;

namespace InvoicePurchase
{
    public partial class FormCustomer : Form
    {
        private readonly CustomerService _customerService;
        public FormCustomer()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            LoadData();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            gridControl1.DataSource = _customerService.GetCustomers();
        }

        


        private Data.Customer _customer;
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks >= 1)
            {
                var custCode = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "CUST_CODE");
                _customer = _customerService.GetCustomerByCustCode(custCode);

                txtCustCode.Text = _customer.CUST_CODE;
                txtCustName.Text = _customer.CUST_NAME;
                txtAddress.Text = _customer.ADDRESS;
                txtTaxCode.Text = _customer.TAX_CODE;
                txtTel.Text = _customer.TEL;
                txtFax.Text = _customer.FAX;
                txtPartName.Text = _customer.NAME_PART;
                txtBuyerName.Text = _customer.BUYER;
                txtCusName.Text = _customer.NAME_CUS;
                txtPayType.Text = _customer.PAY_TYPE;
                txtPayTerm.Text = _customer.PAY_TERM; 
                txtCodeTax.Text = _customer.CODE_TAX;
                txtCurrency.Text = _customer.CURRENCY;
                txtDelTerm.Text = _customer.DEL_TERM;
                txtDelPlace.Text = _customer.DEL_PLACE;
                txtNamePart.Text = _customer.NAME_PART1;

                txtCustCode.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                    txtBuyerName.Text,
                    txtCusName.Text,
                    txtPayType.Text,
                    txtPayTerm.Text,
                    txtCurrency.Text,
                    txtTaxCode.Text,
                    txtDelTerm.Text,
                    txtDelPlace.Text,
                    txtNamePart.Text
                    );

                XtraMessageBox.Show("Thành công");
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtCustCode.Enabled = true;

            txtCustCode.ResetText();
            txtCustName.ResetText();
            txtAddress.ResetText(); 
            txtTaxCode.ResetText();
            txtTel.ResetText();
            txtFax.ResetText();
            txtPartName.ResetText();
            txtBuyerName.ResetText();
            txtCusName.ResetText();
            txtPayType.ResetText();
            txtPayTerm.ResetText();
            txtCodeTax.ResetText();
            txtCurrency.ResetText();
            txtDelTerm.ResetText();
            txtDelPlace.ResetText();
            txtNamePart.ResetText();
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    const string sheetName = "Sheet1";
        //    string pathToExcelFile = Path.Combine(Environment.CurrentDirectory, @"VAT.xlsx");
        //    var excelFile = new ExcelQueryFactory(pathToExcelFile);
        //    excelFile.AddMapping<Data.Customer>(x => x.CUST_CODE, "CUST_CODE");
        //    excelFile.AddMapping<Data.Customer>(x => x.CUST_NAME, "CUST_NAME");
        //    excelFile.AddMapping<Data.Customer>(x => x.ADDRESS, "ADDRESS");
        //    excelFile.AddMapping<Data.Customer>(x => x.CODE_TAX, "CODE_TAX");
        //    excelFile.AddMapping<Data.Customer>(x => x.TEL, "TEL");
        //    excelFile.AddMapping<Data.Customer>(x => x.FAX, "FAX");
        //    excelFile.AddMapping<Data.Customer>(x => x.NAME_PART, "NAME_PART");
        //    excelFile.AddMapping<Data.Customer>(x => x.NAME_CUS, "NAME_CUS");
        //    excelFile.AddMapping<Data.Customer>(x => x.PAY_TYPE, "PAY_TYPE");
        //    excelFile.AddMapping<Data.Customer>(x => x.PAY_TERM, "PAY_TERM");
        //    excelFile.AddMapping<Data.Customer>(x => x.CURRENCY, "CURRENCY");
        //    excelFile.AddMapping<Data.Customer>(x => x.TAX_CODE, "TAX_CODE");
        //    excelFile.AddMapping<Data.Customer>(x => x.DEL_TERM, "DEL_TERM");
        //    excelFile.AddMapping<Data.Customer>(x => x.DEL_PLACE, "DEL_PLACE");
        //    excelFile.AddMapping<Data.Customer>(x => x.BUYER, "BUYER");
        //    excelFile.AddMapping<Data.Customer>(x => x.NAME_PART1, "NAME_PART1");


        //    excelFile.TrimSpaces = TrimSpacesType.Both;
        //    excelFile.ReadOnly = true;

        //    IQueryable<Data.Customer> customers = (from a in excelFile.Worksheet<Data.Customer>(sheetName) select a);

        //    try
        //    {
        //        foreach (Data.Customer cus in customers)
        //        {

        //            //MessageBox.Show(cus.CUST_CODE);
        //            // Nếu tên tồn tại
        //            if (_customerService.CheckCustCodeExit(cus.CUST_CODE))
        //            {
        //                try
        //                {
        //                    _customerService.InsertOrUpdate(
        //                        cus.CUST_CODE,
        //                        cus.CUST_NAME,
        //                        cus.ADDRESS,
        //                        cus.CODE_TAX,
        //                        cus.TEL,
        //                        cus.FAX,
        //                        cus.NAME_PART,
        //                        cus.NAME_CUS,
        //                        cus.PAY_TYPE,
        //                        cus.PAY_TERM,
        //                        cus.CURRENCY,
        //                        cus.TAX_CODE,
        //                        cus.DEL_TERM,
        //                        cus.DEL_PLACE,
        //                        cus.BUYER,
        //                        cus.NAME_PART1
        //                        );
        //                }
        //                catch (Exception ex)
        //                {
        //                    XtraMessageBox.Show(string.Format("Lỗi \n{0}", ex.Message));
        //                }
        //            }
        //        }

        //        XtraMessageBox.Show("Thành công");
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        var sb = new StringBuilder();
        //        foreach (var eve in ex.EntityValidationErrors)
        //        {
        //            sb.AppendLine(String.Format("Entity of type '{0}' in state '{1}' has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                sb.AppendLine(String.Format("- Property: '{0}', Error: '{1}'", ve.PropertyName, ve.ErrorMessage));
        //            }
        //        }
        //        throw new Exception(sb.ToString(), ex);
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    {
                        btnSave.PerformClick();
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
