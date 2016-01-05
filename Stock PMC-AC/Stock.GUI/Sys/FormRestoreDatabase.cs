using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stock.GUI.Sys
{
    public partial class FormRestoreDatabase : DevExpress.XtraEditors.XtraForm
    {
        public FormRestoreDatabase()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textEditPath_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var opdlg = new OpenFileDialog
            {
                Title = "Chọn cơ sở dữ liệu cần phục hồi",
                Multiselect = false,
                Filter = "Database (bak) | *.bak"
            };
            if (opdlg.ShowDialog() == DialogResult.OK)
            {
                textEditPath.Text = opdlg.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                XtraMessageBox.Show("Tên của tập tin không được bỏ trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(textEditPath.Text))
            {
                XtraMessageBox.Show("Đường dẫn lưu tập tin không được bỏ trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditPath.Focus();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chờ \n Chúng tôi đang phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}