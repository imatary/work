using System;
using System.Windows.Forms;
using BarcodeShipping.GUI.Helper;
using BarcodeShipping.Services;

namespace BarcodeShipping.GUI
{
    public partial class FormAddPO : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        public FormAddPO(string modelId, string po)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(modelId) && !string.IsNullOrEmpty(po))
            {
                txtModelID.Text = modelId;
                txtPO.Text = po;
            }
        }

        private void FormAddPO_Load(object sender, EventArgs e)
        {

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            var po = _iqcService.GetPackingPoModelAndPoNo(txtModelID.Text, txtPO.Text);
            if (po != null)
            {
                try
                {
                    _iqcService.UpdatePo(txtModelID.Text, txtPO.Text, int.Parse(txtQtyPO.EditValue.ToString()), null);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
            }
            else
            {
                try
                {
                    _iqcService.InsertPo(txtModelID.Text, txtPO.Text, int.Parse(txtQtyPO.EditValue.ToString()), null);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
            }
            
        }

        private void txtModelID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtModelID.Text))
                {
                    Ultils.TextControlNotNull(txtModelID, "Model");
                }
                else
                {
                    txtPO.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtModelID.Text))
                {
                    Ultils.TextControlNotNull(txtModelID, "Model");
                }
            }
        }

        private void txtPO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtPO.Text))
                {
                    Ultils.TextControlNotNull(txtPO, "PO");
                }
                else
                {
                    txtQtyPO.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtPO.Text))
                {
                    Ultils.TextControlNotNull(txtPO, "PO");
                }
            }
        }

        private void txtQtyPO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtQtyPO.Text))
                {
                    Ultils.TextControlNotNull(txtQtyPO, "Qty PO");
                }
                else
                {
                    btnSave.PerformClick();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtQtyPO.Text))
                {
                    Ultils.TextControlNotNull(txtQtyPO, "Qty PO");
                }
            }
        }
    }
}
