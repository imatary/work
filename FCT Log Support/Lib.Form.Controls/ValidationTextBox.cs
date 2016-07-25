using System.Drawing;
using System.Windows.Forms;

namespace Lib.Form.Controls
{
    public static class ValidationTextBox
    {
        public static void CheckNullValue(TextBox textBox)
        {
            //textBox.ForeColor = Color.Red;
            //textBox.CharacterCasing = CharacterCasing.Normal;
            //textBox.Text = message;
            textBox.Focus();

        }


    }
}
