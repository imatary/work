using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App
{
    public partial class FormLogin : Form
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Users.txt";
        public FormLogin()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (FieldError(txtUsername) == false)
            {
                return;
            }
            else if (FieldError(txtPassword) == false)
            {
                return;
            }
            else
            {
                string username = txtUsername.Text.ToLower();
                string password = txtPassword.Text.ToLower();
                string check = $"{username}|{password}";
                var data = Ultils.ReadAllLines(path, Encoding.ASCII).SingleOrDefault(c => c.Contains(check));
                string[] array = null;
                if (data != null)
                {
                    array = data.Split('|');
                    var currentUser = new User
                    {
                        UserName = array[0],
                        Password = array[1],
                    };
                    Program.CurrentUser = currentUser;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("User not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
