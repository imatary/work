using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppWidthLocalDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DatabaseEntities context = new DatabaseEntities();
        private void LoadData()
        {
            dataGridView1.DataSource = context.Items.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new Item()
            {
                ID = textBox1.Text,
                Name = textBox2.Text,
            };
            try
            {
                context.Items.AddObject(item);
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
