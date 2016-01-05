using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace  Stock.GUI.Helpers
{
    public static class ControlHelper
    {
        /// <summary>
        /// Set value for a property of specified component
        /// </summary>
        /// <param name="component">A specified component</param>
        /// <param name="propertyPath">Path of property</param>
        /// <param name="value">Value to set</param>
        public static void SetValue(object component, string propertyPath, object value)
        {
            try
            {
                object propValue = component;
                var props = propertyPath.Split('.');

                for (int i = 0; i < props.Length - 1; i++)
                {
                    if (propValue != null)
                        propValue = TypeDescriptor.GetProperties(propValue)[props[i]].GetValue(propValue);
                }

                if (propValue != null)
                    TypeDescriptor.GetProperties(propValue)[props[props.Length - 1]].SetValue(propValue, value);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi gán giá trị cho thuộc tính của thành phần :" + component);
            }
        }

        /// <summary>
        /// Find control in a parent control, find by name
        /// </summary>
        /// <param name="parent">Parent control</param>
        /// <param name="controlName">Control name</param>
        /// <returns></returns>
        public static object FindControl(object parent, string controlName)
        {
            var types = new List<Type>(new[] { typeof(BarButtonItem), typeof(LookUpEdit), typeof(DateEdit), typeof(SpinEdit), typeof(MemoEdit), typeof(TextEdit), typeof(TimeEdit), typeof(GridColumn) });

            var excludeList = new List<Type>(new[] { typeof(Label), typeof(LabelControl) });
            var queue = new Queue<object>();
            queue.Enqueue(parent);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.GetType() == typeof(RibbonControl))
                {
                    var ribbonControl = node as RibbonControl;
                    if (ribbonControl != null)
                    {
                        var children = ribbonControl.Items;

                        foreach (var child in children)
                        {
                            if (child.GetType() == typeof(BarButtonItem))
                            {
                                var btn = child as BarButtonItem;

                                if (btn != null && btn.Name == controlName)
                                    return btn;

                                queue.Enqueue(child);
                            }
                        }
                    }
                }
                else if (types.Contains(node.GetType()))
                {

                }
                else if (node.GetType() == typeof(GridControl))
                {
                    var gridControl = node as GridControl;
                    if (gridControl != null)
                    {
                        var children = gridControl.Views;

                        foreach (GridView child in children)
                        {
                            if (child.Name == controlName)
                                return child;

                            queue.Enqueue(child);
                        }
                    }
                }
                else if (node.GetType() == typeof(GridView))
                {
                    var gridView = node as GridView;
                    if (gridView != null)
                    {
                        var children = gridView.Columns;

                        foreach (GridColumn child in children)
                        {
                            if (child.Name == controlName)
                                return child;

                            queue.Enqueue(child);
                        }
                    }
                }
                else
                {
                    var control = node as Control;
                    if (control != null)
                    {
                        var children = control.Controls;

                        foreach (Control child in children)
                        {
                            if (!excludeList.Contains(child.GetType()))
                            {
                                if (child.Name == controlName)
                                    return child;

                                queue.Enqueue(child);
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Reset value of child controls in a specified parent controls to default values
        /// </summary>
        /// <param name="parent">Parent control</param>
        public static void ResetControls(Control parent)
        {
            foreach (var control in parent.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    var textBox = control as TextBox;
                    if (textBox != null) 
                        textBox.ResetText();
                }
                else if (control.GetType() == typeof(TextEdit))
                {
                    var textEdit = control as TextEdit;
                    if (textEdit != null) 
                        textEdit.ResetText();
                }
                else if (control.GetType() == typeof(MemoEdit))
                {
                    var memoEdit = control as MemoEdit;
                    if (memoEdit != null) 
                        memoEdit.ResetText();
                }
                else if (control.GetType() == typeof(LookUpEdit))
                {
                    var lookUpEdit = control as LookUpEdit;
                    if (lookUpEdit != null) 
                        lookUpEdit.EditValue = null;
                }
                else if (control.GetType() == typeof(DateEdit))
                {
                    //(control as DateEdit).EditValue = DatabaseHelper.GetDatabaseDate();
                }
                else if (control.GetType() == typeof(SpinEdit))
                {
                    var spinEdit = control as SpinEdit;
                    if (spinEdit != null)
                        spinEdit.EditValue = spinEdit.Properties.MinValue;
                }
                else if (control.GetType() == typeof(GridControl))
                {
                    var gridControl = control as GridControl;
                    if (gridControl != null) 
                        gridControl.Views[0].RefreshData();
                }
                else if (control.GetType() == typeof(TableLayoutPanel) || control.GetType() == typeof(Panel) || control.GetType() == typeof(PanelControl) || control.GetType() == typeof(GroupControl) || control.GetType() == typeof(SplitContainerControl) || control.GetType() == typeof(SplitContainerControl) || control.GetType() == typeof(SplitContainer))
                {
                    ResetControls((Control)control);
                }
            }
        }
    }
}
