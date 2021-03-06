﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;
using Lib.Core.Helper;

namespace OQC
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
        private void SearchPCB(string searchKey)
        {
            splashScreenManager2.ShowWaitForm();
            if (string.IsNullOrEmpty(searchKey))
            {
                splashScreenManager2.CloseWaitForm();
                Ultils.TextControlNotNull(txtSearchPCB, "Nhập vào từ khóa cần tìm!");
                txtSearchPCB.SelectAll();
            }
            else
            {
                if (comboBoxEditSearchByKey.EditValue.Equals("Production ID"))
                {
                    var logs = _oqcService.GetLogsById(searchKey);
                    var list = new List<tbl_test_log>();
                    if (logs != null)
                    {
                        list.Add(logs);
                        gridControlData.DataSource = list;
                        btnDelete.Enabled = true;
                        splashScreenManager2.CloseWaitForm();
                    }
                    else
                    {
                        splashScreenManager2.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxWaring($"No results width ID:[{searchKey}]");
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
                            var logs = _oqcService.GetLogsByBoxId(searchKey).ToList();

                            if (logs.Any())
                            {
                                gridControlData.DataSource = logs;
                                btnDelete.Enabled = true;
                                splashScreenManager2.CloseWaitForm();
                            }
                            else
                            {
                                splashScreenManager2.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào trong Box [{searchKey}]");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtSearchPCB.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                Ultils.TextControlNotNull(txtSearchPCB, "Vui lòng nhập thông tin cần tìm");
            }
            else
            {
                dynamic mboxResult = MessageBox.Show($"Bạn có muốn xóa [{id}] hay không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (mboxResult == DialogResult.Yes)
                {
                    if (comboBoxEditSearchByKey.EditValue.ToString() == "Production ID")
                    {


                        try
                        {
                            _oqcService.DeleteLogByProductionId(id);
                            MessageBox.Show($"Delete Label [{id}] success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControlData.DataSource = null;
                            gridControlData.Refresh();
                            btnDelete.Enabled = false;
                            txtSearchPCB.ResetText();
                            txtSearchPCB.Focus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (comboBoxEditSearchByKey.EditValue.ToString() == "Box ID")
                    {
                        try
                        {
                            _oqcService.DeleteLogByBoxId(id);
                            MessageBox.Show($"Delete BoxID [{id}] success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControlData.DataSource = null;
                            gridControlData.Refresh();
                            txtSearchPCB.ResetText();
                            txtSearchPCB.Focus();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

            }
        }
    }
}
