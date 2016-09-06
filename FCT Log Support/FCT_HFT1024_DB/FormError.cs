using System;
using System.Windows.Forms;

namespace FCT_HFT1024_DB
{
    public partial class FormError : Form
    {
        public FormError(string errorMessage)
        {
            InitializeComponent();
            lblMessageError.Text = errorMessage;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMessageError_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
