using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FCT_HFT1024_V2
{
    public partial class FormError : Form
    {
        public FormError(string message)
        {
            InitializeComponent();
            lblMessageError.Text = message;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblMessageError.BackColor == Color.White)
            {
                lblMessageError.BackColor = Color.DarkRed;
                lblMessageError.ForeColor = Color.White;
            }
            else
            {
                lblMessageError.BackColor = Color.White;
                lblMessageError.ForeColor = Color.DarkRed;
            }
            Thread.Sleep(1000);
        }
    }
}
