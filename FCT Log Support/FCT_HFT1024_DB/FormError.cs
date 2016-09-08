using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FCT_HFT1024_DB
{
    public partial class FormError : Form
    {
        public FormError(string errorMessage)
        {
            InitializeComponent();
            lblMessageError.Text = errorMessage;

            StartTimer();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(lblMessageError.BackColor == Color.White)
            {
                lblMessageError.BackColor = Color.DarkRed;
                lblMessageError.ForeColor = Color.White;
            }
            else
            {
                lblMessageError.BackColor = Color.White;
                lblMessageError.ForeColor = Color.DarkRed;
            }
        }

        private void StartTimer()
        {
            timer1.Start();
            //timer1.Tick += new EventHandler(timer1_Tick);
        }
    }
}
