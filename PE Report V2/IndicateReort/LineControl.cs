using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Indicate.Data;
using IndicateReort.Service;

namespace IndicateReort
{
    public partial class LineControl : UserControl
    {

        private readonly ProcessService _processService;
        private readonly LineService _lineService;
        public string LineName
        {
            get { return lblLineName.Text; }
            set { lblLineName.Text = value; }
        }
        public LineControl()
        {

            _processService = new ProcessService();
            _lineService = new LineService();
            InitializeComponent();
        }

        private void LoadUserControlProcesss()
        {
            int lineId = 0;
            if (!string.IsNullOrEmpty(LineName))
            {
                lineId = _lineService.GetLineByName(LineName).Id_line;
            }
            var processPanels = new List<ProcessControl>();
            var getProcessByLineId = _processService.GetAllProcesseses(lineId);
            for (int i = 0; i < getProcessByLineId.Count; i++)
            {
                var processes = getProcessByLineId.ElementAtOrDefault(i);
                var processFirst = getProcessByLineId.ElementAtOrDefault(i - 1);
                var mp = new ProcessControl();
                string processName = null;
                int x = 209;
                int y = 32;
                 
                if (processes != null)
                {
                    processName = processes.Id_process;
                    processPanels.Add(mp);
                    mp.ProcessName = processName;
                    mp.Name = "Panel" + processName + i;
                    mp.Location = new Point(x*i, y);
                }

                if (processFirst != null)
                {
                    ////mp.Location = new Point(209 * (i - 1), 32);
                    //mp.Location = new Point(x * i, y);
                    if (processName == processFirst.Id_process)
                    {
                        //this.Size = new Size(900, 170*i);
                        mp.Location = new Point(x * (i - 1), y);
                        //mp.Location = new Point(x * i, y);
                        //mp.Location = new Point(x * (i-2), y);
                    }
                    else
                    {
                        mp.Location = new Point(x * (i - 1), y);
                        //mp.Location = new Point(x * i, y);
                    }
                }

                processPanels.Add(mp);
            }

            foreach (var p in processPanels)
            {
                panelControl1.SuspendLayout();
                panelControl1.Controls.Add(p);
                panelControl1.ResumeLayout();
            }
        }

        private void LineControl_Load(object sender, EventArgs e)
        {
            LoadUserControlProcesss();
        }

        private void lblLineName_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(lblLineName.Text);
            var lineDetails=new FormLineDetails(lblLineName.Text);
            lineDetails.ShowDialog();
        }

        private void lblLineName_MouseHover(object sender, EventArgs e)
        {
            lblLineName.ForeColor = System.Drawing.Color.Red;
        }

        private void lblLineName_MouseLeave(object sender, EventArgs e)
        {
            lblLineName.ForeColor = System.Drawing.Color.Black;
        }

        //private void AddControl(Control ctl)
        //{
        //    tableLayoutPanel2.ColumnCount += 0;
        //    tableLayoutPanel2.ColumnStyles.Add(
        //        new ColumnStyle(SizeType.Percent, 10F / tableLayoutPanel2.ColumnCount));
        //    //ctl.Dock = DockStyle.Fill;
            
        //    tableLayoutPanel2.Controls.Add(ctl, 0, tableLayoutPanel2.ColumnCount - 1);
        //    foreach (ColumnStyle rs in tableLayoutPanel2.ColumnStyles)
        //    {
        //        rs.Width = 10F / tableLayoutPanel2.ColumnCount;
        //    }
        //}
    }
}
