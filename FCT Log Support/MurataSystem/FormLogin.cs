using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MurataSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //var toolTip1 = new System.Windows.Forms.ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Title:";

            System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
            tb.Text = "Go!";
            toolTip1.SetToolTip(textBox1, "My Info!");
            


            //ToolTip tt = new ToolTip();
            //tt.IsBalloon = true;
            //tt.InitialDelay = 0;
            //tt.ShowAlways = true;
            //tt.SetToolTip(textBox1, "Enter 4 digit year.");

            //TextBox TB = (TextBox)sender;
            //int VisibleTime = 1000;  //in milliseconds
            //ToolTip tt = new ToolTip();
            //tt.Show("Test ToolTip", TB, 0, 0, VisibleTime);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds
            
            toolTip1.Show("Test ToolTip", TB, 0, 0, VisibleTime);
        }
    }
}
