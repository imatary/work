using System;
using System.Windows.Forms;
using BarcodeShipping.Services;
using Lib.Core.Helper;

namespace BarcodeMurata
{
    public partial class FormAction : Form
    {
        private readonly OQCService _oqcService;
        public FormAction()
        {
            InitializeComponent();
            _oqcService = new OQCService();
            txtProductionId.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductionId.Text))
            {
                Ultils.EditTextErrorMessage(txtProductionId, "The Production ID required.");
            }
            else if (string.IsNullOrEmpty(txtBoxId.Text))
            {
                Ultils.EditTextErrorMessage(txtBoxId, "The Box ID required.");
            }
            else
            {
                var productionIds = txtProductionId.Text.Split('\n');
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    foreach (var productionId in productionIds)
                    {
                        _oqcService.UpdateBoxIdByProductionId(txtBoxId.Text, productionId);
                    }

                    txtProductionId.Focus();
                    txtProductionId.ResetText();
                    txtBoxId.ResetText();
                    StatusMessage(true, "Update Success");
                    splashScreenManager1.CloseWaitForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void StatusMessage(bool visible,string title)
        {
            lblStatusMessage.Visible = visible;
            lblStatusMessage.Text = title;
        }
        private void txtProductionId_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtProductionId.Text))
                {
                    Ultils.TextControlNotNull(txtProductionId, "The Production ID required.");
                }
                else
                {
                    var production = _oqcService.GetLogByProductionId(txtProductionId.Text);
                    if (production != null)
                    {
                        txtBoxId.Focus();
                    }
                    else
                    {
                        Ultils.EditTextErrorMessage(txtProductionId, "The Production ID not exits.");
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtProductionId.Text))
                {
                    Ultils.TextControlNotNull(txtProductionId, "The Production ID required.");
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeleteId.Text))
            {
                Ultils.TextControlNotNull(txtProductionId, "The Box ID required.");
            }
            else
            {
                if (comboBoxEditDelete.EditValue.ToString() == "Production ID")
                {
                    try
                    {
                        _oqcService.DeleteLogByProductionId(txtDeleteId.Text);
                        VisibleDeleteMessage(true, "Delete PCB success!");
                        MessageBox.Show($"Delete [{txtDeleteId.Text}] success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDeleteId.ResetText();
                        txtDeleteId.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (comboBoxEditDelete.EditValue.ToString() == "Box ID")
                {
                    try
                    {
                        _oqcService.DeleteLogByBoxId(txtDeleteId.Text);
                        VisibleDeleteMessage(true, "Delete Box success!");
                        MessageBox.Show($"Delete [{txtDeleteId.Text}] success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDeleteId.ResetText();
                        txtDeleteId.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }  
        }
        private void txtBoxId_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtBoxId.Text))
                {
                    Ultils.TextControlNotNull(txtBoxId, "The Box ID required.");
                }
                else
                {
                    btnUpdate.Focus();
                    btnUpdate.PerformClick();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtBoxId.Text))
                {
                    Ultils.TextControlNotNull(txtBoxId, "The Box ID required.");
                }
            }
        }

        private void txtProductionId_EditValueChanged(object sender, EventArgs e)
        {
            StatusMessage(false, null);
            //txtProductionId.AutoSize = true;
            //Size sz = new Size(txtProductionId.ClientSize.Width, int.MaxValue);
            //TextFormatFlags flags = TextFormatFlags.WordBreak;
            //int padding = 3;
            //int borders = txtProductionId.Height - txtProductionId.ClientSize.Height;
            //sz = TextRenderer.MeasureText(txtProductionId.Text, txtProductionId.Font, sz, flags);
            //int h = sz.Height + borders + padding;
            //if (txtProductionId.Top + h > this.ClientSize.Height - 10)
            //{
            //    h = this.ClientSize.Height - 10 - txtProductionId.Top;
            //}
            //txtProductionId.Height = h;

        }

        private void comboBoxEditDelete_EditValueChanged(object sender, EventArgs e)
        {
            txtDeleteId.Focus();
        }

        private void txtDeleteId_EditValueChanged(object sender, EventArgs e)
        {
            VisibleDeleteMessage(true, null);
        }

        private void VisibleDeleteMessage(bool visible, string message)
        {
            lblDeleteMessage.Visible = visible;
            lblDeleteMessage.Text = message;
        }
    }
}
