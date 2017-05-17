using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPUNichiconSupportWIP
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        private void BinDataToControls()
        {
            if (Ultils.GetValueRegistryKey("StatioNO") != null)
            {
                txtStationNO.Text = Ultils.GetValueRegistryKey("StatioNO").ToString();
            }
            if (Ultils.GetValueRegistryKey("FileExtension") != null)
            {
                txtFileExtension.Text = Ultils.GetValueRegistryKey("FileExtension").ToString();
            }
            if (Ultils.GetValueRegistryKey("InputLog") != null)
            {
                txtInputLog.Text = Ultils.GetValueRegistryKey("InputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey("OutputLog") != null)
            {
                txtOutputLog.Text = Ultils.GetValueRegistryKey("OutputLog").ToString();
            }

            if (Ultils.GetValueRegistryKey("CheckModel") != null)
            {
                checkBox1.Checked =  bool.Parse(Ultils.GetValueRegistryKey("CheckModel"));
            }

        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            BinDataToControls();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStationNO.Text))
            {
                MessageBox.Show("Vui lòng nhập vào tên trạm!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStationNO.Focus();
            }
            else if (string.IsNullOrEmpty(txtFileExtension.Text))
            {
                MessageBox.Show("Vui lòng nhập vào định dạng file!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFileExtension.Focus();
            }
            else if (string.IsNullOrEmpty(txtInputLog.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn file LOG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblInputLog.Focus();
            }
            else if (string.IsNullOrEmpty(txtOutputLog.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn file LOG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblOutputLog.Focus();
            }
            else
            {
                Ultils.WriteRegistry("StationNO", txtStationNO.Text);
                Ultils.WriteRegistry("FileExtension", txtFileExtension.Text);
                Ultils.WriteRegistry("InputLog", txtInputLog.Text);
                Ultils.WriteRegistry("OutputLog", txtOutputLog.Text);
                Ultils.WriteRegistry("CheckModel", checkBox1.Checked.ToString());
                MessageBox.Show("Save success!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }

        private void lblInputLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog inputLog = new FolderBrowserDialog();
            DialogResult open = inputLog.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtInputLog.Text = inputLog.SelectedPath;
                if (string.IsNullOrEmpty(txtStationNO.Text))
                {
                    btnSaveChanged.Focus();
                }
                else
                {
                    lblInputLog.Focus();
                }
            }
        }

        private void lblOutputLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputLog = new FolderBrowserDialog();
            DialogResult open = outputLog.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtOutputLog.Text = outputLog.SelectedPath;
                if (string.IsNullOrEmpty(txtStationNO.Text))
                {
                    btnSaveChanged.Focus();
                }
                else
                {
                    lblOutputLog.Focus();
                }
            }
        }

    }
}
