using System.Windows.Forms;

namespace IndicateReport
{
    public partial class UserControlProcess : UserControl
    {

        public string CodeOperator
        {
            get { return lblOperator.Text; }
            set { lblOperator.Text = value; }
        }

        public string Process
        {
            get { return lblProcess.Text; }
            set { lblProcess.Text = value; }
        }

        public string Total
        {
            get { return lblTotal.Text; }
            set { lblTotal.Text = value; }
        }

        public string Pass
        {
            get { return lblPass.Text; }
            set { lblPass.Text = value; }
        }

        public string NotGood
        {
            get { return lblNotGood.Text; }
            set { lblNotGood.Text = value; }
        }

        public UserControlProcess()
        {
            InitializeComponent();
        }
    }
}
