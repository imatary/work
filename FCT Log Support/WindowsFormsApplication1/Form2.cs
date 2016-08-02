using System;
using System.Drawing;
using System.Security.Principal;
using Lib.Forms.Security;

namespace WindowsFormsApplication1
{
    public partial class Form2 : BaseForm
	{
		public Form2(IPrincipal userPrincipal) : base(new string[] {"UnknownRole"}, userPrincipal)
		{
			InitializeComponent();
		}

		private void Form2_UserIsDenied(object sender, EventArgs e)
		{
			this.BackColor = Color.Red;
		}

		private void Form2_UserIsAllowed(object sender, EventArgs e)
		{
			this.BackColor = Color.Green;
		}
	}
}
