using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App
{
    public partial class FormModelLibiraOEM : Form
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Models.txt";
        public FormModelLibiraOEM()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            List<ModelMebiusPanel> models = new List<ModelMebiusPanel>();
            var data = Ultils.ReadAllLines(path, Encoding.ASCII);
            foreach (var item in data)
            {
                ModelMebiusPanel model = null;
                string[] array = array = item.Split(',');
                    model = new ModelMebiusPanel
                    {
                        Name = array[0],
                        Code = array[1]
                    };
                models.Add(model);
            }


            dataGridView1.DataSource = models;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        bool FieldError(Control control)
        {
            if (control.Text == "" || control.Text == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(control, "Required field!");
                control.Focus();
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(FieldError(txtModel)==false)
            {
                return;
            } 
            else if (FieldError(txtCode) == false)
            {
                return;
            }
            else
            {
                string modelName = $"{txtModel.Text},{txtCode.Text}";
                var data = Ultils.ReadAllLines(path, Encoding.ASCII).SingleOrDefault(l=>l.Contains(modelName));
                if (data == null)
                {
                    Ultils.Write(path, modelName);
                    LoadData();
                    MessageBox.Show("Save success!");

                    txtModel.ResetText();
                    txtCode.ResetText();
                }
                else
                {
                    errorProvider1.SetError(txtModel, "Model already exists!");
                    txtModel.Focus();
                    return;
                }
            }
        }
        string content = null;
        private void btnSave_Click(object sender, EventArgs e)
        {
            Ultils.WriteTxtFromDataGridView(dataGridView1, path);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells[0].Value.ToString();
                string value2 = row.Cells[1].Value.ToString();

                content = $"{value1},{value2}";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Ultils.RemoveLine(path, content);
                LoadData();
            }
        }
    }
}
