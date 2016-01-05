using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;

namespace Stock.GUI.Partners
{
    public partial class FormAddColor : XtraForm
    {
        public FormAddColor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtColorName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập vào Tên màu", "THÔNG BÁO", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtColorName.Focus();
            }
            else
            {
                var color = new Color()
                {
                    ColorName = txtColorName.Text,
                    Description = txtDescription.Text,
                    ColorCode = colorEditColorCode.Color.Name,
                    IsActive = checkEditIsActive.Checked,
                };
                using (var context = new StockACEntities())
                {
                    try
                    {

                        context.Colors.Add(color);
                        context.SaveChanges();
                        if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Màu Sắc nữa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            ResetControls();
                        }
                        else
                        {
                            DialogResult = DialogResult.No;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ResetControls()
        {
            txtColorName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void FormAddColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSave.PerformClick();
                        break;
                }
            }

            // Đóng form
            if ((Keys)e.KeyValue == Keys.Escape)
                btnClose.PerformClick();
        }
    }
}