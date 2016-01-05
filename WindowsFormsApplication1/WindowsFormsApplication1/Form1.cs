using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var context = new demoEntities();
            dataGridView2.DataSource = context.Tests.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new Test()
            {
                Name = textBox1.Text,
                Active = checkBox1.Checked,

            };
            try
            {
                var context = new demoEntities();
                context.Tests.AddObject(item);
                context.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
