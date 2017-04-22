using System;
using System.Windows.Forms;

namespace CPUNichiconSupportWIP
{
    public partial class FormAddModel : Form
    {
        public FormAddModel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string modelName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(modelName))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Requird field!");
                textBox1.Focus();
            }
            else
            {
                string[] models = Ultils.GetValueRegistryKey("Models").Split(';');
                bool checkExits = false;
                foreach (var item in models)
                {
                    if (item == modelName)
                    {
                        checkExits = true;
                        break;
                    }
                }
                if (checkExits == true)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(textBox1, $"Model name {modelName} exist!");
                    textBox1.Focus();
                }
                else
                {
                    Ultils.WriteRegistry("Models", modelName);
                    MessageBox.Show("Insert success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
