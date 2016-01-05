using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.GUI.Helper;
using BarcodeShipping.Services;

namespace BarcodeShipping.GUI
{
    public partial class FormSearchPCB : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        private List<tbl_test_log> _logs = new List<tbl_test_log>();
        public FormSearchPCB()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPCB(txtSearchPCB.Text);
        }

        private void txtSearchPCB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPCB.Text))
            {
                Ultils.TextControlNotNull(txtSearchPCB, "Search Key");
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchPCB(txtSearchPCB.Text);
                }
                if (e.KeyCode == Keys.Tab)
                {
                    SearchPCB(txtSearchPCB.Text);
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        private void SearchPCB(string productionId)
        {
            splashScreenManager1.ShowWaitForm();
            if (string.IsNullOrEmpty(txtSearchPCB.Text))
            {
                splashScreenManager1.CloseWaitForm();
                Ultils.TextControlNotNull(txtSearchPCB, "Nhập vào từ khóa cần tìm!");
                txtSearchPCB.SelectAll();
            }
            else
            {
                if (comboBoxEditSearchByKey.EditValue.Equals("Production ID"))
                {
                    var log = _iqcService.GetPcbById(productionId);
                    if (log != null)
                    {
                        _logs.Add(log);
                        gridControlData.DataSource = _logs;
                        splashScreenManager1.CloseWaitForm();
                        txtSearchPCB.SelectAll();
                        txtSearchPCB.Focus();
                    }
                    else
                    {
                        splashScreenManager1.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxWaring(string.Format("Không tìm thấy PCB nào với Production ID [{0}]", productionId));
                        txtSearchPCB.SelectAll();
                        txtSearchPCB.Focus();
                    }
                }
                else if (comboBoxEditSearchByKey.EditValue.Equals("Box ID"))
                {
                    string strLength = productionId;
                    if (strLength.Length >= 3)
                    {
                        if (strLength.Substring(0, 3).ToUpper() != "F00")
                        {
                            splashScreenManager1.CloseWaitForm();
                            Ultils.EditTextErrorMessage(txtSearchPCB, "BOX ID phải bắt đầu bằng F00");
                            txtSearchPCB.SelectAll();

                        }
                        else
                        {
                            _logs = _iqcService.GetLogs(strLength).ToList();

                            if (_logs.Any())
                            {
                                gridControlData.DataSource = _logs;
                                splashScreenManager1.CloseWaitForm();
                                txtSearchPCB.SelectAll();
                                txtSearchPCB.Focus();
                            }
                            else
                            {
                                splashScreenManager1.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring(string.Format("Không tìm thấy PCB nào trong Box [{0}]", strLength));
                                txtSearchPCB.SelectAll();
                                txtSearchPCB.Focus();

                            }
                        }
                    }
                }
            }
        }

        private void FormSearchPCB_Load(object sender, EventArgs e)
        {
            txtSearchPCB.Focus();
        }
    }
}
