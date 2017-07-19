using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App.Controls
{
    public partial class usMebiusPanel : UserControl
    {
        List<string> years = new List<string>();
        List<string> months = new List<string>();
        List<string> days = new List<string>();
        List<MebiusPanel> lists = new List<MebiusPanel>();
        private ModelMebiusPanel _model = new ModelMebiusPanel();
        private string pathLog = @"C:\Logs\Mebius Panel";
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Models.txt";
        private string pathRoot = AppDomain.CurrentDomain.BaseDirectory;
        private string serial = null;
        public usMebiusPanel()
        {
            InitializeComponent();
            GetYears();
            GetMonths();
            GetDays();
            LoadData();
            PathLog();
        }

        private void LoadData()
        {
            List<ModelMebiusPanel> models = new List<ModelMebiusPanel>();
            var test = new ModelMebiusPanel
            {
                Name = "",
            };
            models.Add(test);
            var data = Ultils.ReadAllLines(path, Encoding.ASCII);
            foreach (var item in data)
            {
                ModelMebiusPanel model = null;
                string[] array = null;
                if (item.Contains(","))
                {
                    array = item.Split(',');
                    model = new ModelMebiusPanel
                    {
                        Name = array[0],
                        Code = array[1],
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
        private void GetYears()
        {
            int beginYear = DateTime.Now.AddYears(-10).Year;
            int endYear = DateTime.Now.Year;
            for (int i = beginYear; i <= endYear; i++)
            {
                years.Add(i.ToString());
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
        private void GetDays()
        {
            for (int i = 1; i <= 31; i++)
            {
                if(i <= 9)
                {
                    days.Add($"0{i}");
                }
                else
                {
                    days.Add(i.ToString());
                }
            }
            cboDay.DataSource = days;
            cboDay.SelectedItem = DateTime.Now.Day.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        private void PathLog()
        {
            var path = Ultils.GetValueRegistryKey("Mebius Panel", "PathLog");
            if (path != null)
            {
                txtPathLog.Text = path;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        bool FieldError(Control control)
        {
            if(control.Text == "" || control.Text == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(control, "Required field!");
                control.Focus();
                return false;
            }
            return true;
        }

        private void btnGenerateSerial_Click(object sender, EventArgs e)
        {
            if(FieldError(cboModels)==false)
            {
                return;
            }
            else if(FieldError(txtQuantity)==false)
            {
                return;
            }
            else if (FieldError(cboMonth)==false)
            {
                return;
            }
            else if (FieldError(cboYear)==false)
            {
                return;
            }
            else if (FieldError(cboDay)==false)
            {
                return;
            }
            else
            {
                string model = cboModels.Text;
                string quantity = txtQuantity.Text;
                string year = cboYear.Text;
                string month = cboMonth.Text;
                string day = cboDay.Text;
                double qty = double.Parse(quantity);
                string code = txtCode.Text;

                try
                {
                    lists = new List<MebiusPanel>();
                    dataGridView1.DataSource = null;
                    year = year.Substring(3);

                    serial = (code + year + month + day).ToUpper();
                    for (int i = 1; i <= qty; i++)
                    {
                        var item = new MebiusPanel
                        {
                            Model = model,
                            Code = code,
                            Serial = serial,
                        };
                        lists.Add(item);
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

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            bool exists = Directory.Exists(pathLog);
            if (!exists)
            {
                Directory.CreateDirectory(pathLog);
            }

            // Log system
            // Log Print system
            string logPrint = txtPathLog.Text;
            if (!Directory.Exists(logPrint))
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

                
                txtQuantity.ResetText();
                txtCode.ResetText();
                cboModels.ResetText();
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckChangeDate_CheckedChanged(object sender, EventArgs e)
        {
            var check = ckChangeDate.Checked;
            if (check == true)
            {
                cboYear.Enabled = true;
                cboMonth.Enabled = true;
                cboDay.Enabled = true;
            }
            else
            {
                cboYear.Enabled = false;
                cboMonth.Enabled = false;
                cboDay.Enabled = false;
            }
            
        }

        private void lblAddModel_Click(object sender, EventArgs e)
        {
            new FormModelLibiraOEM().ShowDialog();
            LoadData();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}

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

        private void txtQuantity_TextChanged(object sender, EventArgs e)
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
                _model = new ModelMebiusPanel()
                {
                    Name = array[0],
                    Code=array[1]
                };
                txtCode.Text = _model.Code;
                txtQuantity.Focus();
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
                if(lblAddModel.Enabled == true)
                    lblAddModel.Enabled = false;
                if (lblPathLog.Enabled == true)
                    lblPathLog.Enabled = false;
            }
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
                Ultils.WriteRegistry("Mebius Panel", "PathLog", outputLog.SelectedPath);
                PathLog();
            }
        }
    }
}
