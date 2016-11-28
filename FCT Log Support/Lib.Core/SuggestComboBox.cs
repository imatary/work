using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Lib.Core
{
    public class SuggestComboBox : ComboBox
    {
        // Fields
        private Expression<Func<string, string, bool>> _filterRule;
        private Func<string, bool> _filterRuleCompiled;
        private Expression<Func<ComboBox.ObjectCollection, IEnumerable<string>>> _propertySelector;
        private Func<ComboBox.ObjectCollection, IEnumerable<string>> _propertySelectorCompiled;
        private readonly BindingList<string> _suggBindingList;
        private Expression<Func<string, string>> _suggestListOrderRule;
        private Func<string, string> _suggestListOrderRuleCompiled;
        private readonly ListBox _suggLb;
        private static readonly Keys[] KeysToHandle = new Keys[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };

        // Methods
        public SuggestComboBox()
        {
            ListBox box1 = new ListBox
            {
                Visible = false,
                TabStop = false
            };
            this._suggLb = box1;
            this._suggBindingList = new BindingList<string>();
            this._filterRuleCompiled = s => s.ToLower().Contains(this.Text.Trim().ToLower());
            this._suggestListOrderRuleCompiled = s => s;
            this._propertySelectorCompiled = collection => collection.Cast<string>();
            this._suggLb.DataSource = this._suggBindingList;
            this._suggLb.Click += new EventHandler(this.SuggLbOnClick);
            base.ParentChanged += new EventHandler(this.OnParentChanged);
        }

        private void HideSuggBox()
        {
            this._suggLb.Visible = false;
        }

        protected override void OnDropDown(EventArgs e)
        {
            this.HideSuggBox();
            base.OnDropDown(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            this._suggLb.Top = (base.Top + base.Height) - 3;
            this._suggLb.Left = base.Left + 3;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!this._suggLb.Focused)
            {
                this.HideSuggBox();
            }
            base.OnLostFocus(e);
        }

        private void OnParentChanged(object sender, EventArgs e)
        {
            base.Parent.Controls.Add(this._suggLb);
            base.Parent.Controls.SetChildIndex(this._suggLb, 0);
            this._suggLb.Top = (base.Top + base.Height) - 3;
            this._suggLb.Left = base.Left + 3;
            this._suggLb.Width = base.Width - 20;
            this._suggLb.Font = new Font("Segoe UI", 9f);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (!this._suggLb.Visible)
            {
                base.OnPreviewKeyDown(e);
                return;
            }
            Keys keyCode = e.KeyCode;
            if (keyCode <= Keys.Escape)
            {
                switch (keyCode)
                {
                    case Keys.Enter:
                        this.Text = this._suggLb.Text;
                        base.Select(0, this.Text.Length);
                        this._suggLb.Visible = false;
                        return;

                    case Keys.Escape:
                        this.HideSuggBox();
                        return;
                }
            }
            else
            {
                if (keyCode != Keys.Up)
                {
                    if (keyCode != Keys.Down)
                    {
                        goto Label_00F4;
                    }
                    if (this._suggLb.SelectedIndex < (this._suggBindingList.Count - 1))
                    {
                        this._suggLb.SelectedIndex++;
                    }
                }
                else if (this._suggLb.SelectedIndex > 0)
                {
                    this._suggLb.SelectedIndex--;
                }
                return;
            }
            Label_00F4:
            base.OnPreviewKeyDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this._suggLb.Width = base.Width - 20;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.Focused)
            {
                this._suggBindingList.Clear();
                this._suggBindingList.RaiseListChangedEvents = false;
                this._propertySelectorCompiled(base.Items).Where<string>(this._filterRuleCompiled).OrderBy<string, string>(this._suggestListOrderRuleCompiled).ToList<string>().ForEach(new Action<string>(this._suggBindingList.Add));
                this._suggBindingList.RaiseListChangedEvents = true;
                this._suggBindingList.ResetBindings();
                this._suggLb.Visible = this._suggBindingList.Any<string>();
                if ((this._suggBindingList.Count == 1) && (this._suggBindingList.Single<string>().Length == this.Text.Trim().Length))
                {
                    this.Text = this._suggBindingList.Single<string>();
                    base.Select(0, this.Text.Length);
                    this._suggLb.Visible = false;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return ((this._suggLb.Visible && KeysToHandle.Contains<Keys>(keyData)) || base.ProcessCmdKey(ref msg, keyData));
        }

        private void SuggLbOnClick(object sender, EventArgs eventArgs)
        {
            this.Text = this._suggLb.Text;
            base.Focus();
        }

        // Properties
        public Expression<Func<string, string, bool>> FilterRule
        {
            get
            {
                return this._filterRule;
            }
            set
            {
                if (value != null)
                {
                    this._filterRule = value;
                    this._filterRuleCompiled = item => value.Compile()(item, this.Text);
                }
            }
        }

        public Expression<Func<ComboBox.ObjectCollection, IEnumerable<string>>> PropertySelector
        {
            get
            {
                return this._propertySelector;
            }
            set
            {
                if (value != null)
                {
                    this._propertySelector = value;
                    this._propertySelectorCompiled = value.Compile();
                }
            }
        }

        public int SuggestBoxHeight
        {
            get
            {
                return this._suggLb.Height;
            }
            set
            {
                if (value > 0)
                {
                    this._suggLb.Height = value;
                }
            }
        }

        public Expression<Func<string, string>> SuggestListOrderRule
        {
            get
            {
                return this._suggestListOrderRule;
            }
            set
            {
                if (value != null)
                {
                    this._suggestListOrderRule = value;
                    this._suggestListOrderRuleCompiled = value.Compile();
                }
            }
        }
    }


}
