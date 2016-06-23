using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.GUI.Helper;
using BarcodeShipping.Services;

namespace BarcodeShipping.GUI
{
    public partial class Search : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        private List<Shipping> _shippings = new List<Shipping>(); 
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _shippings = new List<Shipping>();
            splashScreenManager1.ShowWaitForm();
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                splashScreenManager1.CloseWaitForm();
                Ultils.TextControlNotNull(txtSearch, "Nhập vào từ khóa cần tìm!");
                txtSearch.SelectAll();
            }
            else
            {
                if (comboBoxEditSearchByKey.EditValue.Equals("Production ID"))
                {
                    var shipping = _iqcService.GetShippingById(txtSearch.Text);
                    if (shipping != null)
                    {
                        _shippings.Add(shipping);
                        gridControlData.DataSource = _shippings;
                        splashScreenManager1.CloseWaitForm();
                        txtSearch.SelectAll();
                        txtSearch.Focus();
                        btnExports.Enabled = true;
                    }
                    else
                    {
                        splashScreenManager1.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào với Production ID [{txtSearch.Text}]");
                        txtSearch.SelectAll();
                        txtSearch.Focus();
                    }
                }
                else if (comboBoxEditSearchByKey.EditValue.Equals("PO NO"))
                {
                    string strLength = txtSearch.Text;
                    if (strLength.Length >= 3)
                    {
                        if (strLength.Substring(0, 3).ToUpper() != "3N3")
                        {
                            splashScreenManager1.CloseWaitForm();
                            Ultils.EditTextErrorMessage(txtSearch, "PO phải bắt đầu bằng 3N3");
                            txtSearch.SelectAll();
                        }
                        else
                        {
                            _shippings = _iqcService.GetShippingsByPo(txtSearch.Text).ToList();

                            if (_shippings.Any())
                            {
                                gridControlData.DataSource = _shippings;
                                splashScreenManager1.CloseWaitForm();
                                txtSearch.SelectAll();
                                txtSearch.Focus();
                                btnExports.Enabled = true;
                            }
                            else
                            {
                                splashScreenManager1.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào với PO NO [{txtSearch.Text}]");
                                txtSearch.SelectAll();
                                txtSearch.Focus();
                                
                            }

                        }
                    }
                }
                else if (comboBoxEditSearchByKey.EditValue.Equals("Box ID"))
                {
                    string strLength = txtSearch.Text;
                    if (strLength.Length >= 3)
                    {
                        if (strLength.Substring(0, 3).ToUpper() != "F00")
                        {
                            splashScreenManager1.CloseWaitForm();
                            Ultils.EditTextErrorMessage(txtSearch, "BOX ID phải bắt đầu bằng F00");
                            txtSearch.SelectAll();
                            
                        }
                        else
                        {
                            _shippings = _iqcService.GetShippingsByBoxId(txtSearch.Text).ToList();

                            if (_shippings.Any())
                            {
                                gridControlData.DataSource = _shippings;
                                splashScreenManager1.CloseWaitForm();
                                txtSearch.SelectAll();
                                txtSearch.Focus();
                                btnDelBox.Enabled = true;
                                btnExports.Enabled = true;
                            }
                            else
                            {
                                splashScreenManager1.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào trong Box [{txtSearch.Text}]");
                                txtSearch.SelectAll();
                                txtSearch.Focus();
                                
                            }
                        }
                    }
                }
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == @"#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExports_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Exel|*.xls",
                Title = @"Save exel file",
                OverwritePrompt = true,
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControlData.ExportToXls(saveFileDialog1.FileName);
            }
        }

        private void btnDelBox_Click(object sender, EventArgs e)
        {
            foreach (var shipping in _shippings)
            {
                _iqcService.DeletePcbById(shipping.ID);
            }
            _shippings = new List<Shipping>();
            gridControlData.Refresh();
            gridControlData.DataSource = null;
            MessageBox.Show($"Xóa thành công Box {txtSearch.Text}");
            txtSearch.SelectAll();
            txtSearch.Focus();
            btnDelBox.Enabled = false;
            btnExports.Enabled = false;

        }

        private void comboBoxEditSearchByKey_SelectedValueChanged(object sender, EventArgs e)
        {
            if (gridControlData.DataSource != null)
            {
                btnDelBox.Enabled = comboBoxEditSearchByKey.EditValue.Equals("Box ID");
            }
        }
    }
}
