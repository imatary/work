using Lib.Forms.Security;
using System;
using System.Security.Principal;

namespace WindowsFormsApplication1
{
    public partial class Form1 : BaseForm
	{
		private IPrincipal _nextFormPrincipal;

		public Form1(IPrincipal userPrincipal) : base(new string[] {"UserRole1","UserRole3"}, userPrincipal)
		{
			_nextFormPrincipal = userPrincipal;
			InitializeComponent();
		}

		private void Form1_UserIsAllowed(object sender, EventArgs e)
		{
			button1.Enabled = this.ValidatedUserRoles.Contains("UserRole1");
			button2.Enabled = this.ValidatedUserRoles.Contains("UserRole3");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form2 nextForm = new Form2(_nextFormPrincipal);
			nextForm.Show();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidatedUserRoles.Contains("UserRole1"))
            {
                System.Windows.Forms.MessageBox.Show("Test");
            }
        }
    }
}
