using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using IndicateReort.Service;

namespace IndicateReort
{
    public partial class FormMain : Form
    {
        private readonly LineService _lineService;

        public event EventHandler UpdateFinished;
        public FormMain()
        {
            InitializeComponent();
            _lineService = new LineService();

        }
        private void LoadUserControlLine()
        {
            
            var linePanels = new List<LineControl>();
            for (int i = 0; i < _lineService.GetLines().Count; i++)
            {
                var mp = new LineControl();
                linePanels.Add(mp);
                var line = _lineService.GetLines().ElementAtOrDefault(i);
                if (line != null)
                {
                    mp.LineName = line.Name_line;
                    mp.Name = "Panel" + line.Id_customer + i;
                }
                mp.Location = new Point(10, 160 * i);
                mp.Dock = DockStyle.Top;

                linePanels.Add(mp);
            }
            foreach (var p in linePanels)
            {
                this.SuspendLayout();
                this.Controls.Add(p);
                this.ResumeLayout();
            }
        } 

        //private void AddControl(Control ctl)
        //{
        //    tableLayoutPanel1.RowCount += 0;
        //    tableLayoutPanel1.RowStyles.Add(
        //        new RowStyle(SizeType.Percent, 100F / tableLayoutPanel1.RowCount));
        //    ctl.Dock = DockStyle.Fill;
        //    tableLayoutPanel1.Controls.Add(ctl, 0, tableLayoutPanel1.RowCount - 1);
        //    foreach (RowStyle rs in tableLayoutPanel1.RowStyles)
        //    {
        //        rs.Height = 100F / tableLayoutPanel1.RowCount;
        //    }
        //}

        //Thread t = null;
        private void FormMain_Load(object sender, System.EventArgs e)
        {
            LoadUserControlLine();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //FormMain_Load(sender, e);

        }
    }
}
