using System.Windows.Forms;

namespace IndicateReort
{
    public partial class ProcessControl : UserControl
    {

        public string ProcessName
        {
            get { return lblProcessName.Text; } 
            set { lblProcessName.Text = value; }
        }

        public ProcessControl()
        {
            InitializeComponent();
        }
    }
}
