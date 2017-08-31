using Lib.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UMC.Entities;
using UMC.Services;

namespace VI_FujiXerox
{
    public partial class FormMain : Form
    {
        private TestLogService testLogService;
        private ModelsService modelsService;
        private TestResultService testResultService;

        private string boxId = "", boardNo = "";
        private int quantity = 0, count = 0;
        private DateTime DateTimeServer;
        private Models _model;

        Stopwatch sw = new Stopwatch();

        public FormMain()
        {
            InitializeComponent();
            lblOperatorName.Text = Program.CurrentUser.OperatorName;
            lblLineID.Text = $"LINE #{Program.CurrentUser.LineID}";

            testLogService = new TestLogService();
            modelsService = new ModelsService();
            testResultService = new TestResultService();

            dataGridViewX1.AutoGenerateColumns = false;
            txtBarcode.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str_status"></param>
        /// <param name="str_message"></param>
        private void SuccessMessage(string str_status, string str_message)
        {
            lblStatus.Text = str_status;
            lblStatus.BackColor = Color.DarkGreen;

            lblMessage.Text = str_message;
            lblMessage.BackColor = Color.DarkGreen;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str_status"></param>
        /// <param name="str_message"></param>
        private void ErrorMessage(string str_status, string str_message)
        {
            lblStatus.Text = str_status;
            lblStatus.BackColor = Color.DarkRed;

            lblMessage.Text = str_message;
            lblMessage.BackColor = Color.DarkRed;
        }
        /// <summary>
        /// 
        /// </summary>
        private void DefaultMessage()
        {
            lblStatus.Text = @"[N\A]";
            lblStatus.BackColor = Color.FromArgb(255, 128, 0);

            lblMessage.Text = "no results";
            lblMessage.BackColor = Color.FromArgb(255, 128, 0);
        }
        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                boxId = txtBoxID.Text.Trim();
                DateTimeServer = testLogService.GetDatabaseTime();
                if (boxId != string.Empty)
                {

                    if (boxId.Length > 10 || boxId.Length <= 5)
                    {
                        ErrorMessage("NG", $"Box ID [{boxId}] không đúng định dạng!");
                        txtBoxID.SelectAll();
                        txtBoxID.Focus();
                    }
                    else
                    {
                        if (boxId.Substring(0, 3).ToUpper() != "F00")
                        {
                            ErrorMessage("NG", "BOX ID phải bắt đầu bằng F00!");
                            txtBoxID.SelectAll();
                            txtBoxID.Focus();
                        }
                        else
                        {
                            DefaultMessage();
                            txtBoxID.Enabled = false;
                            txtBarcode.Focus();
                        }
                    }
                }
                else
                {
                    ErrorMessage("NG", "BoxID không được để trống. Vui lòng nhập vào Box ID!");
                    txtBoxID.Focus();
                }
            }
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                boardNo = txtBarcode.Text;
                var models = modelsService.Get("FujiXerox");

                // test time performent
                sw.Start();

                if (boardNo != string.Empty && boardNo.Length >= 10)
                {
                    DefaultMessage();

                    foreach (var item in models)
                    {
                        if (boardNo.Contains(item.ModelName))
                        {
                            quantity = item.Quantity;
                            lblCount.Text = $"{count}/{quantity}";
                            _model = item;
                            break;
                        }
                    }
                    
                    var checkExists = testLogService.GetSingle(boardNo);
                    
                    if (Program.CurrentUser.OperationID == 1)
                    {
                        if (checkExists != null)
                        {
                            ErrorMessage("NG",
                                    $"PCB [{boardNo}] đã có trong hệ thống. Vui lòng kiểm tra lại\n" +
                                    $"Box ID: {checkExists.BoxID}");
                            txtBarcode.SelectAll();
                            txtBarcode.Focus();
                        }
                        else
                        {
                            DefaultMessage();
                            InsertLog(boxId, boardNo);
                        }
                    }
                    if(Program.CurrentUser.OperationID == 2)
                    {

                    }
                }
                else
                {
                    ErrorMessage("NG", "Barcode không đúng. Vui lòng nhập lại Barcode!");
                    txtBarcode.SelectAll();
                    txtBarcode.Focus();
                }
            }
        }

        /// <summary>
        /// Insert Log
        /// </summary>
        /// <param name="boxId"></param>
        private void InsertLog(string boxId, string boardNo)
        {
            int lineId = Program.CurrentUser.LineID;
            int operationId = Program.CurrentUser.OperationID;
            string operatorId = Program.CurrentUser.OperatorCode;

            string status = null;
            bool judge = false;
            if (checkOK.Checked == true)
            {
                status = "P";
                judge = true;

            }
            if (checkNG.Checked == true)
            {
                status = "F";
                judge = false;
            }
            var logs = testLogService.Get(boxId);

            if (operationId == 1)
            {
                try
                {
                    var testLog = new tbl_test_log()
                    {
                        ProductionID = boardNo,
                        LineID = lineId,
                        MacAddress = txtMacAddress.Text.Trim(),
                        BoxID = boxId,
                        DateCheck = DateTimeServer.Date,
                        TimeCheck = DateTimeServer.TimeOfDay,
                        OperatorCode = operatorId,
                        Target = 1,
                        Actual = 1,
                        FullBox = false,
                        QA_Check = false,
                        CheckBy = operatorId,
                        ModelID = _model.ModelID,
                    };

                    if (testLogService.Insert(testLog) == true)
                    {
                        var checkExists = testResultService.GetSingle(boardNo, operationId);

                        if (checkExists == null)
                        {
                            var result = new tbl_test_result()
                            {
                                ProductionID = boardNo,
                                OperationID = operationId,
                                OperationDate = DateTimeServer,
                                OperatorID = operatorId,
                                JudgeResult = judge,
                            };
                            testResultService.Insert(result);
                        }
                        else
                        {
                            checkExists.JudgeResult = judge;
                            checkExists.OperatorID = operatorId;
                            checkExists.OperationDate = DateTimeServer;

                            testResultService.Update(checkExists);
                        }
                    }

                    logs = testLogService.Get(boxId);
                    dataGridViewX1.DataSource = logs;

                    SuccessMessage("OK", string.Format("Thêm thành công!\nPCB [{0}]", boardNo));
                }
                catch (Exception ex)
                {
                    ErrorMessage("NG", "Error Insert! \n" + ex.Message);
                }

                // Create log
                Ultils.CreateFileLog(_model.ModelName, boardNo, status, Program.CurrentUser.ProcessID, DateTimeServer);

                txtBarcode.ResetText();
                txtBarcode.Focus();

                sw.Stop();
                MessageBox.Show(sw.Elapsed.ToString());
            }
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.CurrentUser = null;
            new FormLogin().ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }
        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxID_TextChanged(object sender, EventArgs e)
        {
            DefaultMessage();
        }
    }
}
