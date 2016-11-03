using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Lib.Core;

namespace Mango_CTMS
{
    public partial class TakeScreenShoot : Form
    {
        private readonly string _nameProcess;
        public TakeScreenShoot(string name)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            _nameProcess = name;

            backgroundWorker1.RunWorkerAsync();
        }

        public string Ok { get; set; }
        public string Fail { get; set; }

        private void TakeScreenShoot_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //int iHandle = NativeWin32.FindWindow(null, "Form1");

                //pictureBox1.Image = PrintWindowWin32.PrintWindow(iHandle);

                Bitmap b = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(b, pictureBox1.ClientRectangle);

                string ok = "Color [A=255, R=0, G=255, B=0]";
                string fail = "Color [A=255, R=255, G=0, B=0";
                int width = 354;
                int height = 78;

                Color colour = b.GetPixel(width, height);
                string name = colour.ToString();

                if (name == ok)
                {
                    Ok = ok;
                }
                else if (name == fail)
                {
                    Fail = fail;
                }
                else
                {
                    return;
                }
                b.Dispose();
            }
        }


        private void TakeScreenShoot_Load(object sender, EventArgs e)
        {
            int iHandle = NativeWin32.FindWindow(null, _nameProcess);
            pictureBox1.Image = PrintWindowWin32.PrintWindow(iHandle);

            Bitmap b = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(b, pictureBox1.ClientRectangle);

            string ok = "Color [A=255, R=0, G=255, B=0]";
            string fail = "Color [A=255, R=255, G=0, B=0";
            int width = 354;
            int height = 78;

            Color colour = b.GetPixel(width, height);
            string name = colour.ToString();
            if (name == ok)
            {
                Ok = "OK";
            }
            else if (name == fail)
            {
                Fail = "FAIL";
            }
            b.Dispose(); 
        }
        private int _backgroundInt;

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _backgroundInt = 1;
            while (backgroundWorker1.CancellationPending == false)
            {
                if (backgroundWorker1.CancellationPending)
                    break; Thread.Sleep(500);
                backgroundWorker1.ReportProgress(0, $"Form tự động đóng sau 8/giây ({_backgroundInt}) ");
                _backgroundInt++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (_backgroundInt == 8)
            {
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.WorkerSupportsCancellation = true;
                    backgroundWorker1.CancelAsync();
                }
                Close();
            }
        }
    }
}
