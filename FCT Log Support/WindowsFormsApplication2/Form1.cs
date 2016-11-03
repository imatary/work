using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.CancelAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private int _backgroundInt;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _backgroundInt = 1;
            while (backgroundWorker1.CancellationPending == false)
            {
                if (backgroundWorker1.CancellationPending)
                    break;System.Threading.Thread.Sleep(500);
                backgroundWorker1.ReportProgress(0,
                    String.Format("I found file # {0}!", _backgroundInt));
                _backgroundInt++;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = e.UserState as string;
        }
    }
}
