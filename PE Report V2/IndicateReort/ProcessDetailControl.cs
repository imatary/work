using System.Windows.Forms;

namespace IndicateReort
{
    public partial class ProcessDetailControl : UserControl
    {
        /// <summary>
        /// Process Name
        /// </summary>
        public string ProcessName
        {
            get { return lblProcessName.Text; } 
            set { lblProcessName.Text = value; }
        }

        /// <summary>
        /// Operator Code
        /// </summary>
        public string OperatorCode
        {
            get { return lblOperatorValue.Text; } 
            set { lblOperatorValue.Text = value; }
        }

        /// <summary>
        /// Total
        /// </summary>
        public string Total
        {
            get { return lblValueTotal.Text; }
            set { lblValueTotal.Text = value; }
        }

        /// <summary>
        /// Pass
        /// </summary>
        public string Pass
        {
            get { return lblValuePass.Text; }
            set { lblValuePass.Text = value; }
        }

        public bool IsVisiblePanelIconNext { get; set; }
        public ProcessDetailControl()
        {
            InitializeComponent();
        }

        private void ProcessDetailControl_Load(object sender, System.EventArgs e)
        {
            //if (IsVisiblePanelIconNext == false)
            //{
            //    panelControl1.Visible = IsVisiblePanelIconNext;
            //}
        }
    }
}
