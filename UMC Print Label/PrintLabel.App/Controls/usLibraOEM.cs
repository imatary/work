using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App.Controls
{
    public partial class usLibraOEM : UserControl
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\ModelsLibraOEM.txt";
        private string pathLog = @"C:\Logs\LibraOEM";
        List<LibraOEM> lists = new List<LibraOEM>();
        private ModelLibraOEM _model = new ModelLibraOEM(); 
        public usLibraOEM()
        {
            InitializeComponent();
            GetYears();
            GetMonths();
            LoadModelsData();
            PathLog();
        }

        List<string> years = new List<string>();
        List<string> months = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        private void GetYears()
        {
            int beginYear = DateTime.Now.AddYears(-10).Year;
            int endYear = DateTime.Now.Year;
            for (int i = beginYear; i <= endYear; i++)
            {
                years.Add(i.ToString());
            }
            string[] array = { "X", "Y", "Z" };
            foreach (var item in array)
            {
                years.Add(item);
            }
            cboYear.DataSource = years;
            cboYear.SelectedItem = endYear.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetMonths()
        {
            for (int i = 1; i <= 9; i++)
            {
                months.Add(i.ToString());
            }
            string[] array = { "X", "Y", "Z" };
            foreach (var item in array)
            {
                months.Add(item);
            }
            cboMonth.DataSource = months;
            cboMonth.SelectedItem = DateTime.Now.Month.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadModelsData()
        {
            List<ModelLibraOEM> models = new List<ModelLibraOEM>();
            var test = new ModelLibraOEM
            {
                Name = "",
            };
            models.Add(test);
            var data = Ultils.ReadAllLines(path, Encoding.ASCII);
            foreach (var item in data)
            {
                ModelLibraOEM model = null;
                string[] array = null;
                if (item.Contains(","))
                {
                    array = item.Split(',');
                    model = new ModelLibraOEM
                    {
                        Name = array[0],
                        Code = array[1],
                        REV = array[2],
                        ASSYNo = array[3],
                    };
                }
                models.Add(model);
            }
            cboModels.DataSource = models;
            cboModels.DisplayMember = "Name";
            cboModels.ValueMember = "Name";
        }

        /// <summary>
        /// 
        /// </summary>
        private void PathLog()
        {
            var path = Ultils.GetValueRegistryKey("Libra OEM", "PathLog");
            if (path != null)
            {
                txtPathLog.Text = path;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        bool FieldError(Control control)
        {
            if (control.Text == "" || control.Text == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(control, "Required field!");
                control.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateSerial_Click(object sender, EventArgs e)
        {
            if (FieldError(cboYear) == false)
            {
                return;
            }
            else if (FieldError(cboMonth) == false)
            {
                return;
            }
            else if (FieldError(cboModels) == false)
            {
                return;
            }
            else if (FieldError(txtQuantity) == false)
            {
                return;
            }
            else if (FieldError(txtASSYNo) == false)
            {
                return;
            }
            else
            {
                string model = _model.Name;
                string code = _model.Code;
                string rev = _model.REV;
                string barcode = _model.REV;
                string quantity = txtQuantity.Text;
                string year = cboYear.Text.Substring(3);
                string month = cboMonth.Text;
                string assyNo = txtASSYNo.Text;
                double qty = double.Parse(quantity);
                string startTo = txtSerialBegin.Text;
                try
                {
                    lists = new List<LibraOEM>();
                    dataGridView1.DataSource = null;
                    if(startTo.Length > 5)
                    {
                        for (int i = 1; i <= qty; i++)
                        {
                            var item = new LibraOEM
                            {
                                Model = model,
                                ASSY_No = "ASSY No. " + assyNo,
                                REV = rev,
                                Barcode = code + year + month + (Convert.ToInt32(startTo.Substring(startTo.Length - 5, 5)) + i).ToString("00000"),
                            };
                            lists.Add(item);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < qty; i++)
                        {
                            var item = new LibraOEM
                            {
                                Model = model,
                                ASSY_No = "ASSY No. " + assyNo,
                                REV = rev,
                                Barcode = code + year + month + (Convert.ToInt32(startTo.Substring(startTo.Length - 5, 5)) + i).ToString("00000"),
                            };
                            lists.Add(item);
                        }
                    }

                    btnExportToCSV.Enabled = true;
                    dataGridView1.DataSource = lists;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error genrate serial!\n {ex.Message}");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            bool exists = Directory.Exists(pathLog);
            if (!exists)
            {
                Directory.CreateDirectory(pathLog);
            }

            // Log Print system
            string logPrint = txtPathLog.Text;
            bool logPrintExists = Directory.Exists(logPrint);
            if (!exists)
            {
                Directory.CreateDirectory(logPrint);
            }

            string folderModel = $@"{pathLog}\{_model.Name}";
            if (!Directory.Exists(folderModel))
            {
                Directory.CreateDirectory(folderModel);
            }
            string year = cboYear.Text;
            string month = cboMonth.Text;
            string fileName = $@"{folderModel}\{year + month}.csv";
            //string fileName = $@"{pathLog}\{_model.Name + year + month}.csv";
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();
            }

            // Logs
            string newLog = logPrint + @"\Log.csv";
            if (!File.Exists(newLog))
            {
                File.Create(newLog).Dispose();
            }

            try
            {
                Ultils.WriteCSV(dataGridView1, fileName);
                Ultils.WriteAppendCSV(dataGridView1, true, newLog);
                MessageBox.Show("Export success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSerialBegin.ResetText();
                txtQuantity.ResetText();
                cboModels.ResetText();
                txtASSYNo.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckChangeDate_CheckedChanged(object sender, EventArgs e)
        {
            var check = ckChangeDate.Checked;
            if (check == true)
            {
                cboYear.Enabled = true;
                cboMonth.Enabled = true;
            }
            else
            {
                cboYear.Enabled = false;
                cboMonth.Enabled = false;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtASSYNo_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string selectModel = null;
            if (cboModels.SelectedIndex > 0)
            {
                selectModel = cboModels.SelectedValue.ToString();

                var data = Ultils.ReadAllLines(path, Encoding.ASCII).SingleOrDefault(c => c.Contains(selectModel));
                string[] array = data.Split(',');
                _model = new ModelLibraOEM()
                {
                    Name = array[0],
                    Code = array[1],
                    REV = array[2],
                    ASSYNo=array[3],
                };
                txtASSYNo.Text = _model.ASSYNo;
                string year = cboYear.Text;
                string month = cboMonth.Text;
                string pathFile = $@"{pathLog}\{selectModel}\{ year + month}.csv";
                if (!File.Exists(pathFile))
                {
                    if (selectModel.Substring(5, 1) == "8")
                    {
                        this.txtSerialBegin.Text = "90001";
                    }
                    else
                    {
                        this.txtSerialBegin.Text = "00001";
                    }
                }
                else
                {
                    string strContent = Ultils.ReadLastLine(pathFile, Encoding.ASCII, "\n");
                    string[] value = strContent.Split(',');
                    txtSerialBegin.Text = value[3];
                    
                }
                txtQuantity.Focus();
            }

        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cboModels.SelectedIndex > 0)
            {
                txtSerialBegin.ResetText();
                txtQuantity.ResetText();
                txtASSYNo.ResetText();
                cboModels.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                if (FieldError(txtQuantity) == true)
                {
                    double qty = double.Parse(txtQuantity.Text);
                    if (qty > 999999)
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(txtQuantity, "Value maximum!");
                        return;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btnExportToCSV.Enabled == true)
            {
                if (dataGridView1.DataSource == null)
                {
                    btnExportToCSV.Enabled = false;
                }
            }
            if (Program.CurrentUser.UserName != null)
            {
                lblAddModel.Enabled = true;
                lblPathLog.Enabled = true;
            }
            else
            {
                if (lblAddModel.Enabled == true)
                    lblAddModel.Enabled = false;
                if (lblPathLog.Enabled == true)
                    lblPathLog.Enabled = false;
            }
        }

        private void lblAddModel_Click(object sender, EventArgs e)
        {
            new FormModelLibraOEM().ShowDialog();
            LoadModelsData();
        }

        private void txtQuantity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGenerateSerial.PerformClick();
            }
        }

        private void lblPathLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputLog = new FolderBrowserDialog();
            DialogResult open = outputLog.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtPathLog.Text = outputLog.SelectedPath;
                Ultils.WriteRegistry("Libra OEM", "PathLog", outputLog.SelectedPath);
                PathLog();
            }
        }

        
    }
}
