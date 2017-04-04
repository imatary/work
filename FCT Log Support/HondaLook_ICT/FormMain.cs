using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HondaLook_ICT
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void lblConfigs_Click(object sender, EventArgs e)
        {
            var config = new FormConfigs();
            config.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
