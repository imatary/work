using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ReportsMaster
{
    public partial class ProcessUserControl : UserControl
    {
        int progrcess;
        public ProcessUserControl()
        {
            progrcess = 100;
            InitializeComponent();
        }

        private void ProcessUserControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(Height / 2, Width / 2);
            e.Graphics.RotateTransform(-90);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Pen obj_pen = new Pen(Color.Red);
            Rectangle rect1 = new Rectangle(0 - Width / 2 + 20, 0 - Height / 2 + 20, Width - 40, Height - 40);
            e.Graphics.DrawPie(obj_pen, rect1, 0, (int)(progrcess * 3.6)); //360/100=3
            e.Graphics.FillPie(new SolidBrush(Color.Red), rect1, 0, (int)(progrcess * 3.6));


            obj_pen = new Pen(Color.White);
            rect1 = new Rectangle(0 - Width / 2 + 30, 0 - Height / 2 + 30, Width - 60, Height - 60);
            e.Graphics.DrawPie(obj_pen, rect1, 0, 360); //360/100=3
            e.Graphics.FillPie(new SolidBrush(Color.White), rect1, 0, 360);
            e.Graphics.RotateTransform(90);

            StringFormat ft = new StringFormat();
            ft.LineAlignment = StringAlignment.Center;
            ft.Alignment = StringAlignment.Center;

            e.Graphics.DrawString($"{progrcess}%", new Font("Arial", 30, FontStyle.Bold), new SolidBrush(Color.Red), rect1, ft);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_progrcess"></param>
        public void UpdateProgrcess(int _progrcess)
        {
            progrcess = _progrcess;
        }
    }
}
