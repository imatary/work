using DevExpress.XtraEditors;
using HondaLook_ICT.Data;
using Lib.Form.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HondaLook_ICT
{
    public partial class FormAddModel : Form
    {
        public FormAddModel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtName))
            {
                using (var context = new SupportsMESDbContext())
                {
                    var current = context.HD_Models.SingleOrDefault(m => m.ID == txtName.Text.Trim());

                    if (current == null) {
                        var model = new HD_Models()
                        {
                            ID = txtName.Text.Trim(),
                            ModelName = txtName.Text.Trim(),
                            Active = cboActive.Checked
                        };
                        try
                        {
                            context.HD_Models.Add(model);
                            context.SaveChanges();
                            XtraMessageBox.Show("Tạo thành công!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Model này đã tạo rồi. Vui lòng kiểm tra lại!", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập vào tên Model!", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
