using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;
using Lib.Core.Helper;

namespace BarcodeMurata
{
    public partial class FormSearchPCB : Form
    {
        private readonly OQCService _oqcService;

        public FormSearchPCB()
        {
            _oqcService = new OQCService();
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPCB(txtSearchPCB.Text.Trim());
        }

        private void txtSearchPCB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPCB(txtSearchPCB.Text.Trim());
            }
            if (e.KeyCode == Keys.Tab)
            {
                SearchPCB(txtSearchPCB.Text.Trim());
            }
        }

        private void SearchPCB(string productionId)
        {
            splashScreenManager2.ShowWaitForm();
            if (string.IsNullOrEmpty(productionId))
            {
                splashScreenManager2.CloseWaitForm();
                Ultils.TextControlNotNull(txtSearchPCB, "Nhập vào từ khóa cần tìm!");
                txtSearchPCB.SelectAll();
            }
            else
            {
                if (comboBoxEditSearchByKey.EditValue.Equals("Production ID"))
                {
                    var logs = _oqcService.GetLogByProductionId(productionId);
                    var list = new List<tbl_test_log>();
                    if (logs != null)
                    {
                        list.Add(logs);
                        gridControlData.DataSource = list;
                        splashScreenManager2.CloseWaitForm();
                    }
                    else
                    {
                        splashScreenManager2.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào với Production ID [{productionId}]");
                        txtSearchPCB.SelectAll();
                        txtSearchPCB.Focus();
                    }
                }
                else if (comboBoxEditSearchByKey.EditValue.Equals("Box ID"))
                {
                    string strLength = txtSearchPCB.Text;
                    if (strLength.Length >= 3)
                    {
                        if (strLength.Substring(0, 3).ToUpper() != "F00")
                        {
                            splashScreenManager2.CloseWaitForm();
                            Ultils.EditTextErrorMessage(txtSearchPCB, "BOX ID phải bắt đầu bằng F00");
                            txtSearchPCB.SelectAll();
                        }
                        else
                        {
                            var logs = _oqcService.GetLogsByBoxId(productionId).ToList();

                            if (logs.Any())
                            {
                                gridControlData.DataSource = logs;
                                splashScreenManager2.CloseWaitForm();
                            }
                            else
                            {
                                splashScreenManager2.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào trong Box [{productionId}]");
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

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
