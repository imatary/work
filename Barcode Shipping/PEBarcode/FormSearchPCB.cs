using System;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Services;
using PEBarcode.Helper;

namespace PEBarcode
{
    public partial class FormSearchPCB : Form
    {
        private readonly OQCService _iqcService;

        public FormSearchPCB()
        {
            _iqcService = new OQCService();
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPCB(txtSearchPCB.Text);
        }

        private void txtSearchPCB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                    var logs = _iqcService.GetLogsById(productionId);
                    if (logs != null)
                    {
                        gridControlData.DataSource = _iqcService.GetLogsById(productionId);
                        splashScreenManager2.CloseWaitForm();

                        //if (EnableUpdateOrDelete(true))
                        //{
                        //    EnableSearch(false);
                        //    txtBoxID.Focus();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("False");
                        //}

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
                            var logs = _iqcService.GetLogs().Where(p => p.BoxID == productionId).ToList();

                            if (logs.Any())
                            {
                                gridControlData.DataSource = logs;
                                splashScreenManager2.CloseWaitForm();
                                //if (EnableUpdateOrDelete(true))
                                //{
                                //    EnableSearch(false);
                                //    txtBoxID.Focus();
                                //}
                                //else
                                //{
                                //    MessageBox.Show("False");
                                //}
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

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtBoxID.Text))
        //    {
        //        Ultils.TextControlNotNull(txtBoxID, "Bạn chưa nhập vào Box Id mới!");
        //        txtBoxID.SelectAll();
        //    }
        //    else
        //    {
        //        string strBoxId = txtBoxID.Text;
        //        if (strBoxId.Length >= 3)
        //        {
        //            if (strBoxId.Substring(0, 3).ToUpper() != "F00")
        //            {
        //                Ultils.EditTextErrorMessage(txtBoxID, "BOX ID phải bắt đầu bằng F00");
        //                txtBoxID.SelectAll();
        //            }
        //            else
        //            {
        //                dynamic mboxResult = MessageBox.Show(@"Bạn có chắc muốn sửa hay không?",
        //                    @"THÔNG BÁO",
        //                    MessageBoxButtons.YesNo,
        //                    MessageBoxIcon.Warning);
        //                if (mboxResult == DialogResult.Yes)
        //                {
        //                    _iqcService.UpdateBoxIdByProductionId(txtBoxID.Text, txtSearchPCB.Text);
        //                    EnableSearch(true);
        //                    EnableUpdateOrDelete(false);
        //                    gridControlData.DataSource = null;
        //                    txtBoxID.ResetText();
        //                }
        //                else
        //                {
                            
        //                }
        //            }
        //        }
        //    }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (comboBoxEditSearchByKey.EditValue.Equals("Production ID"))
        //    {
        //        dynamic mboxResult = MessageBox.Show(@"Bạn có thực sự muốn xóa hay không?",
        //            @"THÔNG BÁO",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Warning);
        //        if (mboxResult == DialogResult.Yes)
        //        {
        //            //_iqcService.DeleteLogByProductionId(txtSearchPCB.Text);
        //            MessageBox.Show("Test");
        //            EnableSearch(true);
        //            EnableUpdateOrDelete(false);
        //        } 
        //    }
        //    else if (comboBoxEditSearchByKey.EditValue.Equals("Box ID"))
        //    {
                
        //    }
        //}

        //private bool EnableUpdateOrDelete(bool enable)
        //{
        //    txtBoxID.Enabled = enable;
        //    btnSave.Enabled = enable;
        //    btnDelete.Enabled = enable;
        //    btnRefesh.Enabled = enable;

        //    return enable;
        //}

        private void EnableSearch(bool enable)
        {
            comboBoxEditSearchByKey.Enabled = enable;
            txtSearchPCB.Enabled = enable;
            btnSearch.Enabled = enable;
        }

        //private void btnRefesh_Click(object sender, EventArgs e)
        //{
        //    EnableSearch(true);
        //    EnableUpdateOrDelete(false);
        //}
    }
}
