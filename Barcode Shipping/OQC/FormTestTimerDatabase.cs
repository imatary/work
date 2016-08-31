using BarcodeShipping.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OQC
{
    public partial class FormTestTimerDatabase : Form
    {
        private OQCService _oqcService; 
        delegate void SetCallBack(string tex);
        public FormTestTimerDatabase()
        {
            InitializeComponent();

            _oqcService = new OQCService();
        }

        private void FormTestTimerDatabase_Load(object sender, EventArgs e)
        {
            
            //this.Text = _oqcService.GetLogs().Count().ToString();
        }

        private void SetText(string t)
        {
            if (textBox1.InvokeRequired)
            {
                SetCallBack d = SetText;
                Invoke(d, new object[] { t });
            }
            else
            {
                textBox1.Text = t;
            }
        }

        private void LapVoTan()
        {
            while (true)
            {
                SetText(_oqcService.CountRecords().ToString());
                Thread.Sleep(5000);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(LapVoTan));

            t.Start();
        }
    }
}
