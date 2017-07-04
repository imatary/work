using PrintLabel.App.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrintLabel.App
{
    public partial class FormMain : Form
    {
        const int LEADING_SPACE = 12;
        const int CLOSE_SPACE = 15;
        const int CLOSE_AREA = 15;
        private Timer t = null;
        public FormMain()
        {
            InitializeComponent();
            TabPage();
            StartTimer();
            lblVersion.Text = "Version: " + Ultils.GetRunningVersion();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - CLOSE_AREA, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + LEADING_SPACE, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 
        /// </summary>
        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 100;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }
        void t_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();

            if (Program.CurrentUser.UserName != null)
            {
                lblUserName.Text = "Hello, "+ Program.CurrentUser.UserName;
            }
            else
            {
                lblUserName.Text = "Login";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private  void TabPage()
        {
            // get the inital length
            int tabLength = tabControl1.ItemSize.Width;

            // measure the text in each tab and make adjustment to the size
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                TabPage currentPage = tabControl1.TabPages[i];

                int currentTabLength = TextRenderer.MeasureText(currentPage.Text, tabControl1.Font).Width;
                // adjust the length for what text is written
                currentTabLength += LEADING_SPACE + CLOSE_SPACE + CLOSE_AREA;

                if (currentTabLength > tabLength)
                {
                    tabLength = currentTabLength;
                }
            }

            // create the new size
            Size newTabSize = new Size(tabLength, tabControl1.ItemSize.Height);
            tabControl1.ItemSize = newTabSize;
        }

        public void AddTabPage(object userControl, string text)
        {
            try
            {
                var formShow = ((UserControl)userControl);
                TabPage tabPage = new TabPage();
                tabPage.Text = text;
                tabPage.Name = formShow.Name;

                formShow.Dock = DockStyle.Fill;
                tabPage.Controls.Add(formShow);

                var pages = tabControl1.TabPages;
                TabPage tabPageCheck = new TabPage();
                foreach (TabPage item in pages)
                {
                    if(item.Name == formShow.Name)
                    {
                        tabPageCheck = item;
                        break;
                    }
                }
                if (tabPageCheck.Name == null || tabPageCheck.Name=="")
                {
                    tabControl1.TabPages.Add(tabPage);
                    //tabControl1.TabPages.Add(tabPage);
                    tabControl1.SelectedTab = tabPage;
                    tabControl1.SelectedTab.AutoScroll = true;
                }
                else
                {
                    tabControl1.SelectedTab = tabPageCheck;
                    return;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTabPage(new usLibraOEM(), "Libra OEM");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTabPage(new usMebiusPanel(), "Mebius Panel");
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {
            if(Program.CurrentUser.UserName == null)
            {
                new FormLogin().ShowDialog();
            }
            else
            {
                Program.CurrentUser = new User();
            }
            
        }
    }
}
