using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App.Controls
{
    public partial class usAssyMainA3 : UserControl
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\AssyMainA3.txt";
        private string pathLog = @"C:\Logs\AssyMainA3";
        List<ViewAssyMainA3> lists = new List<ViewAssyMainA3>();
        private ModelAssyMainA3 _model = new ModelAssyMainA3(); 
        public usAssyMainA3()
        {
            InitializeComponent();
            LoadModelsData();
            PathLog();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadModelsData()
        {
            List<ModelAssyMainA3> models = new List<ModelAssyMainA3>();
            var test = new ModelAssyMainA3
            {
                Model = "",
            };
            models.Add(test);
            var data = Ultils.ReadAllLines(path, Encoding.ASCII);
            foreach (var item in data)
            {
                ModelAssyMainA3 model = null;
                string[] array = null;
                if (item.Contains(","))
                {
                    array = item.Split(',');
                    model = new ModelAssyMainA3
                    {
                        Model = array[0],
                        AssyNo = array[1],
                    };
                }
                models.Add(model);
            }
            cboModels.DataSource = models;
            cboModels.DisplayMember = "Model";
            cboModels.ValueMember = "Model";
        }

        /// <summary>
        /// 
        /// </summary>
        private void PathLog()
        {
            var path = Ultils.GetValueRegistryKey("Assy Main A3", "PathLog");
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
            if (FieldError(cboModels) == false)
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
                string model = _model.Model;
                string assyNo = $"ASSY No. {_model.AssyNo}";
                string barcode = _model.AssyNo.Substring(0, 10);

                string quantity = txtQuantity.Text;
                double qty = double.Parse(quantity);

                try
                {
                    lists = new List<ViewAssyMainA3>();
                    dataGridView1.DataSource = null;
                    for (int i = 0; i < qty; i++)
                    {
                        var item = new ViewAssyMainA3
                        {
                            Model = model,
                            AssyNo = assyNo,
                            Barcode = barcode,
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

            string folderModel = $@"{pathLog}\{_model.Model}";
            if (!Directory.Exists(folderModel))
            {
                Directory.CreateDirectory(folderModel);
            }
            string fileName = $@"{folderModel}.csv";
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
                _model = new ModelAssyMainA3()
                {
                    Model = array[0],
                    AssyNo = array[1],
                };
                txtASSYNo.Text = _model.AssyNo;

                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                txtQuantity.ResetText();

                txtQuantity.Focus();
            }

        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cboModels.SelectedIndex > 0)
            {
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
            new FormAssyMainA3().ShowDialog();
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
                Ultils.WriteRegistry("Assy Main A3", "PathLog", outputLog.SelectedPath);
                PathLog();
            }
        }

        
    }
}
