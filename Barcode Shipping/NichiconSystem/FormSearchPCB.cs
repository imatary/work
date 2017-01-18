using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Lib.Core.Helper;
using System.Drawing;
using DevExpress.XtraEditors;
using NichiconSystem.Data;

namespace NichiconSystem
{
    public partial class FormSearchPCB : Form
    {
        private readonly NichiconDbContext _context;

        public FormSearchPCB()
        {
            _context = new NichiconDbContext();
            InitializeComponent();

        }

        /// <summary>
        /// Find by ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPCB(txtSearchPCB.Text.Trim());
        }

        /// <summary>
        /// Delete by ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtSearchPCB.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                Ultils.TextControlNotNull(txtSearchPCB, "Vui lòng nhập thông tin cần tìm");
            }
            else
            {
                dynamic mboxResult = XtraMessageBox.Show($"Bạn có muốn xóa [{id}] hay không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (mboxResult == DialogResult.Yes)
                {
                    if (comboBoxEditSearchByKey.EditValue.ToString() == "Production ID")
                    {


                        try
                        {
                            // Delete by ID
                            Remove(id);

                            MessageBox.Show($"Delete Label [{id}] success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControlData.DataSource = null;
                            gridControlData.Refresh();
                            btnDelete.Enabled = false;
                            txtSearchPCB.ResetText();
                            txtSearchPCB.Focus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (comboBoxEditSearchByKey.EditValue.ToString() == "Box ID")
                    {
                        try
                        {
                            RemoveItemInBoxId(id);

                            MessageBox.Show($"Delete BoxID [{id}] success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControlData.DataSource = null;
                            gridControlData.Refresh();
                            txtSearchPCB.ResetText();
                            txtSearchPCB.Focus();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                
            }
        }

        private void txtSearchPCB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPCB(txtSearchPCB.Text.Trim());
            }
            if (e.KeyCode == Keys.Tab)
            {
                SearchPCB(txtSearchPCB.Text.Trim());
            }
        }

        private void SearchPCB(string productionId)
        {
            splashScreenManager2.ShowWaitForm();
            if (string.IsNullOrEmpty(productionId))
            {
                splashScreenManager2.CloseWaitForm();
                Ultils.TextControlNotNull(txtSearchPCB, "Nhập vào từ khóa cần tìm!");
                txtSearchPCB.SelectAll();
            }
            else
            {
                if (comboBoxEditSearchByKey.EditValue.Equals("Production ID"))
                {
                    var logs = _context.Nichicon.SingleOrDefault(n => n.ProductionID == productionId);
                    var list = new List<Nichicon>();
                    if (logs != null)
                    {
                        list.Add(logs);
                        gridControlData.DataSource = list;
                        btnDelete.Enabled = true;
                        splashScreenManager2.CloseWaitForm();
                    }
                    else
                    {
                        splashScreenManager2.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxWaring($"No results width ID:[{productionId}]");
                        txtSearchPCB.SelectAll();
                        txtSearchPCB.Focus();
                    }
                }
                else if (comboBoxEditSearchByKey.EditValue.Equals("Box ID"))
                {
                    string strLength = txtSearchPCB.Text;
                    if (strLength.Length >= 3)
                    {
                        if (strLength.Substring(0, 3).ToUpper() != "F00")
                        {
                            splashScreenManager2.CloseWaitForm();
                            Ultils.EditTextErrorMessage(txtSearchPCB, "BOX ID phải bắt đầu bằng F00");
                            txtSearchPCB.SelectAll();
                        }
                        else
                        {
                            var logs = _context.Nichicon.Where(n => n.BoxID == productionId).ToList();

                            if (logs.Any())
                            {
                                gridControlData.DataSource = logs;
                                btnDelete.Enabled = true;
                                splashScreenManager2.CloseWaitForm();
                            }
                            else
                            {
                                splashScreenManager2.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào trong Box [{productionId}]");
                                txtSearchPCB.SelectAll();
                                txtSearchPCB.Focus();
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Delete Nichicon
        /// </summary>
        /// <param name="id"></param>
        private void Remove(string id)
        {
            var item = _context.Nichicon.SingleOrDefault(n => n.ProductionID == id);
            if (item != null)
            {
                try
                {
                    _context.Nichicon.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Delete!\n {ex.Message}", "Error Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ID Notfound");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void RemoveItemInBoxId(string boxId)
        {
            var items = _context.Nichicon.Where(n => n.BoxID == boxId);
            if (items != null)
            {
                foreach (var item in items)
                {
                    try
                    {
                        _context.Nichicon.Remove(item);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error Delete!\n {ex.Message}", "Error Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("ID Notfound");
            }
        }

        private void FormSearchPCB_Load(object sender, EventArgs e)
        {
            txtSearchPCB.Focus();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "JudgeResult")
            {
                bool value = (bool)gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns.ColumnByFieldName("JudgeResult"));
                if (value == true)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (value == false)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
    }
}
