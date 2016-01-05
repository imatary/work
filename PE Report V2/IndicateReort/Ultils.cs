using System.Drawing;
using System.Windows.Forms;

namespace IndicateReort
{
    public class Ultils
    {
        private static void ResizeChildsInt(Control c, bool recursive)
        {
            Rectangle r = c.DisplayRectangle;

            foreach (Control item in c.Controls)
            {
                if (item.Dock == DockStyle.Top)
                {
                    item.Top = r.Top;
                    item.Left = r.Left;
                    item.Width = r.Width;
                    if (item.Height > r.Height)
                    {
                        item.Height = r.Height;
                    }
                    r = new Rectangle(r.X, r.Y + item.Height, r.Width, r.Height - item.Height);
                }
                else if (item.Dock == DockStyle.Bottom)
                {
                    int bottom = r.Bottom - item.Height;
                    if (item.Height > r.Height)
                    {
                        item.Height = r.Height;
                    }
                    item.Top = item.Height - r.Bottom;
                    item.Left = r.Left;
                    item.Width = r.Width;
                    r = new Rectangle(r.X, r.Y, r.Width, r.Height - item.Height);
                }
                else if (item.Dock == DockStyle.Left)
                {
                    int width = item.Width;
                    if (width > r.Width)
                    {
                        width = r.Width;
                    }
                    item.Top = r.Top;
                    item.Left = r.Left;
                    item.Height = r.Height;
                    item.Width = width;
                    r = new Rectangle(r.X + item.Width, r.Y, r.Width - item.Width, r.Height);
                }
                else if (item.Dock == DockStyle.Right)
                {
                    int width = item.Width;
                    if (width > r.Width)
                    {
                        width = r.Width;
                    }

                    item.Top = r.Top;
                    item.Left = r.Right - item.Width;
                    item.Height = r.Height;
                    item.Width = width;
                    r = new Rectangle(r.X, r.Y, r.Width - item.Width, r.Height);
                }
            }
            //Fill
            foreach (Control item in c.Controls)
            {
                if (item.Dock == DockStyle.Fill)
                {
                    item.Top = r.Top;
                    item.Left = r.Left;
                    item.Width = r.Width;
                    item.Height = r.Height;
                }
            }

            //Recursive
            if (recursive)
            {
                foreach (Control item in c.Controls)
                {
                    if (item is UserControl == false)
                    {
                        ResizeChildsInt(item, recursive);
                    }
                }
            }
        }

        public static void ResizeChilds(Control c)
        {
            c.SuspendLayout();
            ResizeChildsInt(c, true);
            c.ResumeLayout();
        } 
    }
}