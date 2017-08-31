using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCT_HFT1024_V2
{
    public enum ContAlignment
    {
        Left = ContentAlignment.TopLeft,
        Right = ContentAlignment.TopRight
    }

    public class XtendedTextBox : TextBox
    {


        private Rectangle textBorder;
        private string watremark;
        private Size waterMarkTextSize;
        private Point waterMarkPosition;
        public string WaterMarkText
        {
            get { return watremark; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    watremark = "Search";
                }
                else
                    watremark = value;
                waterMarkTextSize = TextRenderer.MeasureText(watremark, Font);
                this.Invalidate();
            }

        }
        private Color waterMarkColor;
        public Color WaterMarkColor
        {
            get { return waterMarkColor; }
            set
            {
                waterMarkColor = value;
                Invalidate();
            }
        }

        private Image waterMarkIcon;

        public Image WaterMarkIcon
        {
            get { return waterMarkIcon; }
            set
            {
                waterMarkIcon = value;
                Invalidate();
            }
        }
        private ContAlignment iconAlignment;

        public ContAlignment WaterMarkImageAlign
        {
            get { return iconAlignment; }
            set
            {
                iconAlignment = value;
                if (iconAlignment == ContAlignment.Left)
                {
                    waterMarkPosition.X = waterMarkTextSize.Height;
                    waterMarkPosition.Y = 0;
                }
                if (iconAlignment == ContAlignment.Right)
                {
                    waterMarkPosition.X = waterMarkTextSize.Width + 2;
                    waterMarkPosition.Y = 0;
                }
                Invalidate();
            }
        }


        public XtendedTextBox()
        {

            WaterMarkText = "Search";
            waterMarkColor = Color.DarkGray;
            //WaterMarkIcon = Properties.Resources.search;
            WaterMarkImageAlign = ContAlignment.Right;
            FontChanged += XtndedTextBox_FontChanged;
        }

        private void XtndedTextBox_FontChanged(object sender, EventArgs e)
        {
            waterMarkTextSize = TextRenderer.MeasureText(watremark, Font);
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (Text.Length > 0)
                base.SetStyle(ControlStyles.UserPaint, false);
            else
            {
                base.SetStyle(ControlStyles.UserPaint, true);

            }
            this.UpdateStyles();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            textBorder = this.DisplayRectangle;
            base.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Text.Length == 0)
            {
                if (waterMarkIcon != null)
                {
                    switch (iconAlignment)
                    {
                        case ContAlignment.Right:
                            {
                                e.Graphics.DrawImage(waterMarkIcon, waterMarkPosition.X, waterMarkPosition.Y, waterMarkTextSize.Height, waterMarkTextSize.Height);
                                TextRenderer.DrawText(e.Graphics, watremark, Font, textBorder, waterMarkColor, TextFormatFlags.Left);
                                break;
                            }
                        case ContAlignment.Left:
                            {
                                e.Graphics.DrawImage(waterMarkIcon, waterMarkPosition.X - waterMarkTextSize.Height, 0, waterMarkTextSize.Height, waterMarkTextSize.Height);
                                TextRenderer.DrawText(e.Graphics, watremark, Font, waterMarkPosition, waterMarkColor, TextFormatFlags.Left);
                                break;
                            }
                    }
                }

            }
        }
    }
}
