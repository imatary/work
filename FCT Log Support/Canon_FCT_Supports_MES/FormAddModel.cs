using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Canon_FCT_Supports_MES
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
