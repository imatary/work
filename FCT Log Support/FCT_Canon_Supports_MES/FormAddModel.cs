using System;
using System.Windows.Forms;

namespace FCT_Canon_Supports_MES
{
    public partial class FormAddModel : Form
    {
        public FormAddModel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtModelName.Text.ToUpper();
            if (!string.IsNullOrEmpty(name))
            {
                Ultils.WriteRegistryArray("Models", name);
                MessageBox.Show("Insert Success!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào tên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
