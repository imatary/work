using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GARecruitmentSystem
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }
        
        private void FormTest_Load(object sender, EventArgs e)
        {

        }
        delegate void SetCallBack(string tex);
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(LapVoTan));

            t.Start();
        }
        int x = 0;
        private void LapVoTan()
        {
            while (true)
            {
                SetText("X : " + x);
                Thread.Sleep(500);
                x++;
            }

        }
        private void SetText(string t)
        {
            if (textBox1.InvokeRequired)
            {
                SetCallBack d = SetText;
                this.Invoke(d, new object[] { t });
            }
            else
            {
                textBox1.Text = t;
            }
        }
    }
}
