using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mango_CTMS
{
    public partial class FormError : Form
    {
        public FormError(string errorMessage)
        {
            InitializeComponent();
            lblMessageError.Text = errorMessage;
            backgroundWorker1.WorkerReportsProgress = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMessageError_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.CancelAsync();
            }
            this.Close();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.CancelAsync();
            }
            this.Hide();
        }
        private int _backgroundInt;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _backgroundInt = 1;
            while (backgroundWorker1.CancellationPending == false)
            {
                if (backgroundWorker1.CancellationPending)
                    break;
                System.Threading.Thread.Sleep(500);
                backgroundWorker1.ReportProgress(0, $"Form tự động đóng sau {15 - _backgroundInt}/ giây!");
                _backgroundInt++;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelControl1.Text = e.UserState as string;
            if(_backgroundInt == 15)
            {
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.WorkerSupportsCancellation = true;
                    backgroundWorker1.CancelAsync();
                }
                this.Close();
            }
        }
    }
}
