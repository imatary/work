using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NichiconSystem
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
            Display();
        }

        void Display()
        {
            GetTaskWindows();

            var process = Ultils.GetValueRegistryKey("Process");
            if (process != null)
                comboBox1.Text = process.ToString();

            var writeLog = Ultils.GetValueRegistryKey("WriteLog");
            if (writeLog != null)
                checkBox1.Checked = bool.Parse(writeLog.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetTaskWindows()
        {
            List<string> data = new List<string>();
            // Get the desktopwindow handle
            int nDeshWndHandle = NativeWin32.GetDesktopWindow();
            // Get the first child window
            int nChildHandle = NativeWin32.GetWindow(nDeshWndHandle, NativeWin32.GW_CHILD);
            while (nChildHandle != 0)
            {
                //If the child window is this (SendKeys) application then ignore it.
                if (nChildHandle == this.Handle.ToInt32())
                {
                    nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
                }

                // Get only visible windows
                if (NativeWin32.IsWindowVisible(nChildHandle) != 0)
                {
                    StringBuilder sbTitle = new StringBuilder(1024);
                    // Read the Title bar text on the windows to put in combobox
                    NativeWin32.GetWindowText(nChildHandle, sbTitle, sbTitle.Capacity);
                    string sWinTitle = sbTitle.ToString();
                    {
                        if (sWinTitle.Length > 0)
                        {
                            data.Add(sWinTitle);
                        }
                    }
                }
                // Look for the next child.
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
            }

            comboBox1.DataSource = data;
        }

        private void lblRefresh_Click(object sender, EventArgs e)
        {
            GetTaskWindows();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Ultils.WriteRegistry("Process", comboBox1.SelectedValue.ToString());
                Ultils.WriteRegistry("WriteLog", checkBox1.Checked.ToString());
                MessageBox.Show("Update success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi!\n{ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
