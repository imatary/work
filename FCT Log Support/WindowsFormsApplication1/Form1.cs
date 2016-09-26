using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> _listCom = new List<string>();
            foreach (var com in SerialPort.GetPortNames())
            {
                _listCom.Add(com);
            }

            comboBox1.DataSource = _listCom;
        }

        private SerialPort port = new SerialPort("COM2",
      9600, Parity.None, 8, StopBits.One);
        private void button1_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.Close();
            }
            port.Open();
            for (int i = 0; i < 1000; i++)
            {
                port.Write($"Send-{i}");
                Thread.Sleep(500);
                string tmp = port.ReadExisting();
                textBox1.Text = tmp;
            }



        }

        private void dulieuden(object sender, SerialDataReceivedEventArgs e)
        {
            port.DataReceived += new SerialDataReceivedEventHandler(dulieuden);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //port.Open();
            string docdulieu = port.ReadExisting().ToString();
            this.textBox1.Text = docdulieu;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                port.Open();
                this.port.DtrEnable = true;
                this.port.RtsEnable = true;

            }
            catch
            {
                //txtThongBao.Enabled = true;
                MessageBox.Show("Có sự cố khi mở cổng Com, hãy kiểm tra lại hệ thống, Chương trình chưa thực hiện được!");
            }
            if (port.IsOpen)
            {
                //btnTestPort.Enabled = false;
                //btnHexTx.Enabled = true;

                //btnClosePort.Enabled = true;

                //txtRx.Enabled = true;
                //txtHexTx.Enabled = true;
                //txtTx.Enabled = true;
                //txtThongBao.Enabled = true;
                MessageBox.Show("Cổng Com 1 đã được mở rồi, bắt đầu chiến đấu đi");

            }
            else this.Focus();


        }
    }
}
