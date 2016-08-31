using System;
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
            //MessageBox.Show(Ultils.ConvertToTitleCase("pHạM văN cươNg"));
        }
        delegate void SetCallBack(string tex);
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(LapVoTan));

            t.Start();

            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = "Button Tooltip";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;

            buttonToolTip.ShowAlways = true;

            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 500;

            buttonToolTip.SetToolTip(button1, "Click me to execute.");
        }
        int x = 0;
        private void LapVoTan()
        {
            while (true)
            {
                SetText("X : " + x);
                ShowMessage();
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

        private void ShowMessage()
        {
            MessageBox.Show("Test"+x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
