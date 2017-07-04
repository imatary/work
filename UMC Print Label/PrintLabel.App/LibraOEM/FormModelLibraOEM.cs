using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App
{
    public partial class FormModelLibraOEM : Form
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\ModelsLibraOEM.txt";

        public FormModelLibraOEM()
        {
            InitializeComponent();
            LoadModelsData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadModelsData()
        {
            List<ModelLibraOEM> models = new List<ModelLibraOEM>();
            var data = Ultils.ReadAllLines(path, Encoding.ASCII);
            foreach (var item in data)
            {
                ModelLibraOEM model = null;
                string[] array = null;
                if (item.Contains(","))
                {
                    array = item.Split(',');
                    model = new ModelLibraOEM
                    {
                        Name = array[0],
                        Code = array[1],
                        REV = array[2],
                        ASSYNo = array[3],
                    };
                }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FieldError(txtName) == false)
            {
                return;
            }
            else if (FieldError(txtCharacters) == false)
            {
                return;
            }
            else if (FieldError(txtBarcode) == false)
            {
                return;
            }
            else if (FieldError(txtASSYNo) == false)
            {
                return;
            }
            else
            {
                string content = $"{txtName.Text},{txtCharacters.Text},{txtBarcode.Text},{txtASSYNo.Text}";
                Ultils.Write(path, content);

                LoadModelsData();
                MessageBox.Show("Save success!");

                txtBarcode.ResetText();
                txtCharacters.ResetText();
                txtName.ResetText();
                txtASSYNo.ResetText();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Ultils.WriteTxtFromDataGridView(dataGridView1, path);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Doing");
        }
        string content = null;
        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Ultils.RemoveLine(path, content);
                LoadModelsData();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells[0].Value.ToString();
                string value2 = row.Cells[1].Value.ToString();
                string value3 = row.Cells[2].Value.ToString();
                string value4 = row.Cells[3].Value.ToString();

                content = $"{value1},{value2},{value3},{value4}";
            }
        }
    }
}
