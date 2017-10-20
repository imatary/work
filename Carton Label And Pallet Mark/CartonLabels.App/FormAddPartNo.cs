using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace CartonLabels.App
{
    public partial class FormAddPartNo : XtraForm
    {
        public FormAddPartNo()
        {
            InitializeComponent();
            GetData();
        }
        private Repository<Part> repository = new Repository<Part>();

        private void GetData()
        {
            gridControl1.DataSource = new Repository<Part>().ReadAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditPartNo.Text))
            {
                //textEditPartNo.Properties.Appearance.BorderColor = Color.Red;
                XtraMessageBox.Show("Part No không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditPartNo.Focus();
            }
            else if (string.IsNullOrEmpty(textEditQuantity.Text))
            {
                //textEditQuantity.Properties.Appearance.BorderColor = Color.Red;
                XtraMessageBox.Show("Part Name không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditQuantity.Focus();
            }
            else if (string.IsNullOrEmpty(textEditWeight.Text))
            {
                //textEditWeight.Properties.Appearance.BorderColor = Color.Red;
                XtraMessageBox.Show("Part Name không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditWeight.Focus();
            }
            else
            {
                string partNo = textEditPartNo.Text;
                int quantity = int.Parse(textEditQuantity.Text);
                long price = 0;
                if (!string.IsNullOrEmpty(textEditPrice.Text))
                {
                    price = long.Parse(textEditPrice.Text);
                }
                
                string partName = string.Format("{0} pcs/box", quantity);
                double weight = double.Parse(textEditWeight.Text);
                try
                {
                    var part = new Part()
                    {
                        PartNoID = partNo,
                        Quantity = quantity,
                        Price = price,
                        PartNoValue = partName,
                        Weight = weight,
                    };
                    repository.Create(part);
                    GetData();
                    Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void FormAddPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSave.PerformClick();
                        break;
                }
            }

            // Đóng form
            if ((Keys)e.KeyValue == Keys.Tab)
                btnClose.PerformClick();
        }

        private void FormAddPartNo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            textEditPartNo.ResetText();
            textEditPrice.ResetText();
            textEditQuantity.ResetText();
            textEditWeight.ResetText();
            textEditPartNo.Enabled = true;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks >= 1)
            {
                
                var partNo = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "PartNoID");

                var part = new Repository<Part>().Read(partNo);
                textEditPartNo.Text = part.PartNoID;
                textEditPrice.Text = part.Price.ToString();
                textEditQuantity.Text = part.Quantity.ToString();
                textEditWeight.Text = part.Weight.ToString();

                if (!string.IsNullOrEmpty(textEditPartNo.Text))
                {
                    textEditPartNo.Enabled = false;
                }
            }
        }
    }
}