using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stock.GUI.Sys
{
    public partial class FormBackupDatabase : DevExpress.XtraEditors.XtraForm
    {
        public FormBackupDatabase()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                XtraMessageBox.Show("Tên của tập tin không được bỏ trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            } 
            else if (string.IsNullOrEmpty(txtPath.Text))
            {
                XtraMessageBox.Show("Đường dẫn lưu tập tin không được bỏ trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPath.Focus();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chờ \n Chúng tôi đang phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPath_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                var fdgl = new FolderBrowserDialog();
                if (fdgl.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fdgl.SelectedPath;
                }
            }
        }
    }
}