using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Lib.Core
{
    public class MultiColumnComboBox : ComboBox
    {
        // Fields
        private bool _AutoComplete;
        private bool _AutoDropdown;
        private Color _BackColorEven = Color.White;
        private Color _BackColorOdd = Color.White;
        private Collection<string> _ColumnNames = new Collection<string>();
        private string _ColumnNameString = "";
        private int _ColumnWidthDefault = 0x4b;
        private Collection<int> _ColumnWidths = new Collection<int>();
        private string _ColumnWidthString = "";
        private int _LinkedColumnIndex;
        private TextBox _LinkedTextBox;
        private int _TotalWidth = 0;
        private int _ValueMemberColumnIndex = 0;

        // Events
        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event EventHandler OpenSearchForm;

        // Methods
        public MultiColumnComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.ContextMenu = new ContextMenu();
        }

        private void InitializeColumns()
        {
            if (!Convert.ToBoolean(this._ColumnNameString.Length))
            {
                PropertyDescriptorCollection itemProperties = base.DataManager.GetItemProperties();
                this._TotalWidth = 0;
                this._ColumnNames.Clear();
                for (int i = 0; i < itemProperties.Count; i++)
                {
                    this._ColumnNames.Add(itemProperties[i].Name);
                    if (i >= this._ColumnWidths.Count)
                    {
                        this._ColumnWidths.Add(this._ColumnWidthDefault);
                    }
                    this._TotalWidth += this._ColumnWidths[i];
                }
            }
            else
            {
                this._TotalWidth = 0;
                for (int j = 0; j < this._ColumnNames.Count; j++)
                {
                    if (j >= this._ColumnWidths.Count)
                    {
                        this._ColumnWidths.Add(this._ColumnWidthDefault);
                    }
                    this._TotalWidth += this._ColumnWidths[j];
                }
            }
            if (this._LinkedColumnIndex >= this._ColumnNames.Count)
            {
                this._LinkedColumnIndex = 0;
            }
        }

        private void InitializeValueMemberColumn()
        {
            int num = 0;
            foreach (string str in this._ColumnNames)
            {
                if (string.Compare(str, base.ValueMember, true, CultureInfo.CurrentUICulture) == 0)
                {
                    this._ValueMemberColumnIndex = num;
                    break;
                }
                num++;
            }
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            this.InitializeColumns();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (!base.DesignMode)
            {
                Color black;
                e.DrawBackground();
                Rectangle bounds = e.Bounds;
                int right = 0;
                if ((e.State & DrawItemState.Selected) == DrawItemState.None)
                {
                    Color color2 = Convert.ToBoolean((int)(e.Index % 2)) ? this._BackColorOdd : this._BackColorEven;
                    using (SolidBrush brush = new SolidBrush(color2))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                    black = Color.Black;
                }
                else
                {
                    black = Color.White;
                }
                using (Pen pen = new Pen(SystemColors.GrayText))
                {
                    using (SolidBrush brush2 = new SolidBrush(black))
                    {
                        if (!Convert.ToBoolean(this._ColumnNames.Count))
                        {
                            e.Graphics.DrawString(Convert.ToString(base.Items[e.Index]), this.Font, brush2, bounds);
                        }
                        else if (this.RightToLeft.Equals(RightToLeft.Yes))
                        {
                            StringFormat format = new StringFormat
                            {
                                Alignment = StringAlignment.Near,
                                FormatFlags = StringFormatFlags.DirectionRightToLeft
                            };
                            for (int i = this._ColumnNames.Count - 1; i >= 0; i--)
                            {
                                if (Convert.ToBoolean(this._ColumnWidths[i]))
                                {
                                    string s = Convert.ToString(base.FilterItemOnProperty(base.Items[e.Index], this._ColumnNames[i]));
                                    bounds.X = right;
                                    bounds.Width = this._ColumnWidths[i];
                                    right = bounds.Right;
                                    e.Graphics.DrawString(s, this.Font, brush2, bounds, format);
                                    if (i > 0)
                                    {
                                        e.Graphics.DrawLine(pen, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < this._ColumnNames.Count; j++)
                            {
                                if (Convert.ToBoolean(this._ColumnWidths[j]))
                                {
                                    string str2 = Convert.ToString(base.FilterItemOnProperty(base.Items[e.Index], this._ColumnNames[j]));
                                    bounds.X = right;
                                    bounds.Width = this._ColumnWidths[j];
                                    right = bounds.Right;
                                    e.Graphics.DrawString(str2, this.Font, brush2, bounds);
                                    if (j < (this._ColumnNames.Count - 1))
                                    {
                                        e.Graphics.DrawLine(pen, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
                                    }
                                }
                            }
                        }
                    }
                }
                e.DrawFocusRectangle();
            }
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            if (this._TotalWidth > 0)
            {
                if (base.Items.Count > base.MaxDropDownItems)
                {
                    base.DropDownWidth = this._TotalWidth + SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    base.DropDownWidth = this._TotalWidth;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Escape))
            {
                this.SelectedIndex = -1;
                this.Text = "";
                if (this._LinkedTextBox > null)
                {
                    this._LinkedTextBox.Text = "";
                }
            }
            else if ((e.KeyCode == Keys.F3) && (this.OpenSearchForm > null))
            {
                this.OpenSearchForm(this, EventArgs.Empty);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            string str;
            int num = -1;
            base.DroppedDown = this._AutoDropdown;
            if (!char.IsControl(e.KeyChar))
            {
                if (this._AutoComplete)
                {
                    str = this.Text.Substring(0, base.SelectionStart) + e.KeyChar.ToString();
                    num = base.FindStringExact(str);
                    if (num == -1)
                    {
                        num = base.FindString(str);
                    }
                    else
                    {
                        base.DroppedDown = false;
                    }
                    if (num != -1)
                    {
                        this.SelectedIndex = num;
                        base.SelectionStart = str.Length;
                        base.SelectionLength = this.Text.Length - base.SelectionStart;
                    }
                    else
                    {
                        e.KeyChar = '\0';
                    }
                }
                else
                {
                    num = base.FindString(e.KeyChar.ToString(), this.SelectedIndex);
                    if (num != -1)
                    {
                        this.SelectedIndex = num;
                    }
                }
            }
            if (((e.KeyChar == '\b') && this._AutoComplete) && Convert.ToBoolean(base.SelectionStart))
            {
                str = this.Text.Substring(0, base.SelectionStart - 1);
                num = base.FindString(str);
                if (num != -1)
                {
                    this.SelectedIndex = num;
                    base.SelectionStart = str.Length;
                    base.SelectionLength = this.Text.Length - base.SelectionStart;
                }
            }
            e.Handled = true;
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            if ((this._LinkedTextBox > null) && (this._LinkedColumnIndex < this._ColumnNames.Count))
            {
                this._LinkedTextBox.Text = Convert.ToString(base.FilterItemOnProperty(base.SelectedItem, this._ColumnNames[this._LinkedColumnIndex]));
            }
        }

        protected override void OnValueMemberChanged(EventArgs e)
        {
            base.OnValueMemberChanged(e);
            this.InitializeValueMemberColumn();
        }

        // Properties
        public bool AutoComplete
        {
            get
            {
                return this._AutoComplete;
            }
            set
            {
                this._AutoComplete = value;
            }
        }

        public bool AutoDropdown
        {
            get
            {
                return this._AutoDropdown;
            }
            set
            {
                this._AutoDropdown = value;
            }
        }

        public Color BackColorEven
        {
            get
            {
                return this._BackColorEven;
            }
            set
            {
                this._BackColorEven = value;
            }
        }

        public Color BackColorOdd
        {
            get
            {
                return this._BackColorOdd;
            }
            set
            {
                this._BackColorOdd = value;
            }
        }

        public Collection<string> ColumnNameCollection
        {
            get
            {
                return this._ColumnNames;
            }
        }

        public string ColumnNames
        {
            get
            {
                return this._ColumnNameString;
            }
            set
            {
                if (!Convert.ToBoolean(value.Trim().Length))
                {
                    this._ColumnNameString = "";
                }
                else if (value > null)
                {
                    char[] separator = new char[] { ',', ';', ':' };
                    string[] strArray = value.Split(separator);
                    if (!base.DesignMode)
                    {
                        this._ColumnNames.Clear();
                    }
                    foreach (string str in strArray)
                    {
                        if (!Convert.ToBoolean(str.Trim().Length))
                        {
                            throw new NotSupportedException("Column names can not be blank.");
                        }
                        if (!base.DesignMode)
                        {
                            this._ColumnNames.Add(str.Trim());
                        }
                    }
                    this._ColumnNameString = value;
                }
            }
        }

        public Collection<int> ColumnWidthCollection
        {
            get
            {
                return this._ColumnWidths;
            }
        }

        public int ColumnWidthDefault
        {
            get
            {
                return this._ColumnWidthDefault;
            }
            set
            {
                this._ColumnWidthDefault = value;
            }
        }

        public string ColumnWidths
        {
            get
            {
                return this._ColumnWidthString;
            }
            set
            {
                if (!Convert.ToBoolean(value.Trim().Length))
                {
                    this._ColumnWidthString = "";
                }
                else if (value > null)
                {
                    char[] separator = new char[] { ',', ';', ':' };
                    string[] strArray = value.Split(separator);
                    string str = "";
                    int num = -1;
                    int num2 = 1;
                    foreach (string str2 in strArray)
                    {
                        if (Convert.ToBoolean(str2.Trim().Length))
                        {
                            int num3;
                            if (!int.TryParse(str2, out num3))
                            {
                                num = num2;
                                str = str2;
                            }
                            else
                            {
                                num2++;
                            }
                        }
                        else
                        {
                            num2++;
                        }
                    }
                    if (num > -1)
                    {
                        throw new ArgumentOutOfRangeException("Invalid column width '" + str + "' located at column " + num.ToString());
                    }
                    this._ColumnWidthString = value;
                    if (!base.DesignMode)
                    {
                        this._ColumnWidths.Clear();
                        foreach (string str4 in strArray)
                        {
                            if (Convert.ToBoolean(str4.Trim().Length))
                            {
                                this._ColumnWidths.Add(Convert.ToInt32(str4));
                            }
                            else
                            {
                                this._ColumnWidths.Add(this._ColumnWidthDefault);
                            }
                        }
                        if (base.DataManager > null)
                        {
                            this.InitializeColumns();
                        }
                    }
                }
            }
        }

        public DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawVariable)
                {
                    throw new NotSupportedException("Needs to be DrawMode.OwnerDrawVariable");
                }
                base.DrawMode = value;
            }
        }

        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
            set
            {
                if (value != ComboBoxStyle.DropDown)
                {
                    throw new NotSupportedException("ComboBoxStyle.DropDown is the only supported style");
                }
                base.DropDownStyle = value;
            }
        }

        public int LinkedColumnIndex
        {
            get
            {
                return this._LinkedColumnIndex;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("A column index can not be negative");
                }
                this._LinkedColumnIndex = value;
            }
        }

        public TextBox LinkedTextBox
        {
            get
            {
                return this._LinkedTextBox;
            }
            set
            {
                this._LinkedTextBox = value;
                if (this._LinkedTextBox > null)
                {
                    this._LinkedTextBox.ReadOnly = true;
                    this._LinkedTextBox.TabStop = false;
                }
            }
        }

        public int TotalWidth
        {
            get
            {
                return this._TotalWidth;
            }
        }
    }
}
