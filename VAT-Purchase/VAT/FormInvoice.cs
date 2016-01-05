using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using VAT.Services;

namespace VAT
{
    public partial class FormInvoice : Form
    {
        private readonly CustomerService _customerService;

        public FormInvoice()
        {
            InitializeComponent();

            _customerService = new CustomerService();

            LoadData();
        }

        private void LoadData()
        {
            cboCustomers.DataSource = _customerService.GetCustomers(); 
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Bán có chắc muốn in hóa đơn?", @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //if ((!string.IsNullOrEmpty(txtFrom.Text)) || (!string.IsNullOrEmpty(txtTo.Text)) ||
                //(String.CompareOrdinal(txtFrom.Text, txtTo.Text)) > 0)
                //{
                //    MessageBox.Show("Nhập sai", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                const string sDataFile = "Yokowo.xls";
                    string sFilePath = Path.GetFullPath(sDataFile);
                const string sheetName = "Main Invoice";
                if (File.Exists(sFilePath))
                {

                    FnOpenExcel(sFilePath, sheetName);

                    try
                    {
                        WriteExcel("E8", "E8", DateTime.Now.Date.Day.ToString());
                        WriteExcel("G8", "G8", DateTime.Now.Date.Month.ToString());
                        WriteExcel("H8", "H8", DateTime.Now.Date.Year.ToString());
                        WriteExcel("F12", "F12", txtCusName.Text);
                        WriteExcel("D13", "D13", txtCustName.Text);
                        WriteExcel("D14", "D14", txtAddress.Text);
                        WriteExcel("D14", "D14", txtAddress.Text);
                        WriteExcel("D14", "D14", txtAddress.Text);
                        WriteExcel("D15", "D15", txtTaxCode.Text);
                        WriteExcel("E16", "E16", txtDelTerm.Text);
                        WriteExcel("D17", "D17", txtDelPlace.Text);
                        WriteExcel("B18", "B18", txtBuyer.Text);
                        WriteExcel("F18", "F18", txtTel.Text);
                        WriteExcel("H18", "H18", txtFax.Text);
                        WriteExcel("G49", "G49", txtPayType.Text);
                        WriteExcel("G51", "G51", txtPayTerm.Text);
                        WriteExcel("I52", "I52", txtCurrency.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    FnCloseExcel();

                    System.Diagnostics.Process.Start(sFilePath);
                }
            }
            else
            {
                DialogResult = DialogResult.No;
            }           
        }
        private Data.Customer _customer;
        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string custCode = cboCustomers.SelectedValue.ToString();
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
                txtBuyer.Text = _customer.BUYER;


                btnExport.Enabled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.E:
                    {
                        btnExport.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.N:
                    {
                        btnCustomers.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var formCustomer = new FormCustomers();
            formCustomer.ShowDialog();
            LoadData();
        }


        Microsoft.Office.Interop.Excel.Application _application;
        Workbook _workbook;
        Worksheet _worksheet;
        readonly object _missingValue = System.Reflection.Missing.Value;
        //Open Excel file
        /// <summary>
        /// Open Excel file
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="iSheet"></param>
        /// <returns></returns>
        public int FnOpenExcel(string sPath, string iSheet)
        {

            int functionReturnValue;
            try
            {
                //Microsoft.Office.Interop.Excel.Application();
                _application = new Microsoft.Office.Interop.Excel.Application
                {
                    Visible = true,
                    DisplayAlerts = false,
                }; 
                
                _workbook = _application.Workbooks.Open(sPath, _missingValue, false, _missingValue, _missingValue, _missingValue, _missingValue, _missingValue, _missingValue, _missingValue, _missingValue, _missingValue, _missingValue);
                // get all sheets in workbook
                //worksheet = (Worksheet) workbook.Worksheets;

                // get some sheet
                _worksheet = (Worksheet)_workbook.Worksheets["" + iSheet + ""];
                // Get the active sheet
                _worksheet = (Worksheet)_workbook.ActiveSheet;
                functionReturnValue = 0;
            }
            catch (Exception ex)
            {
                functionReturnValue = -1;
                MessageBox.Show(ex.Message, "Open File!");
            }
            return functionReturnValue;
        }

        // Close the excel file and release objects.
        public int FnCloseExcel()
        {
            try
            {
                _application.ActiveWorkbook.Save();
                _application.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_application);

                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Close File!");
            }
            return 0;
        }

        /// <summary>
        /// Write Data
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public void WriteExcel(string row, string col, string value)
        {
            Range exlRange = _worksheet.Range["" + row + "", "" + col + ""];
            exlRange.Value2 = value;

        }
    }
}
