using System.Drawing;
using System.Globalization;
using System.Linq;
using CartonLabel.GUI.Helpers;
using CartonLabel.GUI.Reports;
using CartonLabel.Services;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
namespace CartonLabel.GUI
{
    public partial class FormInput : XtraForm
    {
        private readonly PartNoService _partNoService;
        private readonly CartonLabelService _cartonLabelService;
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private int _quantity;
        private int _shippingQuantity;
        private float _total;
        private int _count;
        private const float WeightBox = 2;
        private float _weightItem;
        public FormInput()
        {
            InitializeComponent();
            _partNoService = new PartNoService();
            _cartonLabelService = new CartonLabelService();
            dateEditDelivery.EditValue = DateTime.Now.ToShortDateString();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DateTime delivery_Date = DateTime.Parse(dateEditDelivery.EditValue.ToString());
            if (string.IsNullOrEmpty(textEditPoNo.Text))
            {
                textEditPoNo.Properties.Appearance.BorderColor = Color.Red;
                XtraMessageBox.Show("Po No Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditPoNo.Focus();
                
            }
            else if (string.IsNullOrEmpty(gridLookUpEditPartNo.Text))
            {
                XtraMessageBox.Show("Part No Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditPartNo.Focus();
            }
            else if (string.IsNullOrEmpty(textEditShippingQuantity.Text))
            {
                XtraMessageBox.Show("Shipping Quantity Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditShippingQuantity.Focus();

            }
            else if (string.IsNullOrEmpty(textEditPOQuantity.Text))
            {
                XtraMessageBox.Show("PO Quantity Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditPOQuantity.Focus();
            }
            else if (string.IsNullOrEmpty(dateEditDelivery.Text))
            {
                XtraMessageBox.Show("Delivery Date Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditDelivery.Focus();
            }
            
            else if (delivery_Date < DateTime.Now.Date)
            {
                XtraMessageBox.Show("Delivery Date Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditDelivery.Focus();
            }
            else
            {
                _shippingQuantity = Convert.ToInt32(textEditShippingQuantity.Text);
                _total = _shippingQuantity / _quantity;
                int i;
                double weightItemsInBox = _quantity * _weightItem;
                double weightTotal = WeightBox + weightItemsInBox;
                string createdDate = DateTime.Now.ToString("d/M/yyyy");
                const string finalConsignee = "FXSL";
                const string supplier = "UMC Electronics Viet Nam Co., Ltd";
                string manufactureDate = DateTime.Now.ToString("d/M/yyyy");
                string deliveryDate = String.Format("{0: yyyy/M/d}", dateEditDelivery.EditValue);
                string grossWeight = string.Format("{0} kgs", Math.Round(weightTotal, 2));
                string partNo = gridLookUpEditPartNo.EditValue.ToString();
                string poNo = textEditPoNo.Text;
                string pOQuantity = string.Format("{0} pcs", textEditPOQuantity.Text);
                string boxQuantity = string.Format("{0} pcs", _quantity.ToString(CultureInfo.InvariantCulture));
                string strCno;
                
                for (i = 1; i <= _total; i++)
                {
                    _count = (_count + _quantity);

                    strCno = _shippingQuantity % _quantity != 0 
                        ? string.Format("{0}/{1}", i, _total + 1) 
                        : string.Format("{0}/{1}", i, _total);
                    InsertToDatabase(createdDate, boxQuantity, strCno, deliveryDate, finalConsignee, supplier, grossWeight, manufactureDate, partNo, poNo, pOQuantity);
                }
                float sodu = _shippingQuantity - _count;
                if (_count < _shippingQuantity)
                {
                    //MessageBox.Show(_count.ToString());
                    double weightItemsInBox2 = sodu * _weightItem;
                    double weightTotal2 = WeightBox + weightItemsInBox2;
                    string grossWeight2 = string.Format("{0} kgs", Math.Round(weightTotal2, 2));
                    string boxQuantity2 = string.Format("{0} pcs", sodu);
                    strCno = _shippingQuantity % _quantity != 0 
                        ? string.Format("{0}/{1}", i, _total + 1) 
                        : string.Format("{0}/{1}", i, _total);
                    InsertToDatabase(createdDate, boxQuantity2, strCno, deliveryDate, finalConsignee, supplier, grossWeight2, manufactureDate, partNo, poNo, pOQuantity);
                    _count = 0;
                }

                DialogResult dlgresult = MessageBox.Show(@"Bạn có muốn thêm tiếp PO NO nữa không?", @"THÔNG BÁO",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning);
                if (dlgresult == DialogResult.No)
                {
                    using (var report = new ReportCartonLabels())
                    {
                        btnPreview.Enabled = false;
                        _waitDialog.CreateWaitDialog();
                        _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu...!");
                        var results = _cartonLabelService.GetCartonLabels().Where(l => l.CreatedDate == DateTime.Now.ToString("d/M/yyyy"));

                        report.DataSource = results;
                        report.Landscape = true;
                        ReportPrintTool tool = new ReportPrintTool(report);
                        tool.PreviewForm.FormClosing += new FormClosingEventHandler(ReportCartonLabels_FormClosing);


                        _waitDialog.CloseWait();
                        report.ShowPreviewDialog();
                    }
                }
                else
                {
                    ResetControls();
                }

                
            }
        }

        private void ReportCartonLabels_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (XtraMessageBox.Show("Bạn có muốn xóa dữ liệu cũ đi không?", "XÓA DỮ LIỆU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                var labels = _cartonLabelService.GetCartonLabels();
                foreach (var label in labels)
                {
                    _cartonLabelService.Delete(label);
                }
                //XtraMessageBox.Show("Xóa dữ liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPreview.Enabled = true;
                ResetControls();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có thực sự muốn đóng chương trình không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void gridLookUpEditPartNo_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridLookUpEditPartNo.EditValue.ToString()))
            {
                string value = gridLookUpEditPartNo.EditValue.ToString();

                _quantity = _partNoService.GetQuantityByValue(value);
                _weightItem = _partNoService.GetWeightByValue(value);

                //MessageBox.Show(_quantity + _weightItem.ToString());
            }
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            LoadGirdLookUpPartNo();
        }

        private void ResetControls()
        {
            textEditPOQuantity.Text = string.Empty;
            textEditShippingQuantity.Text = string.Empty;
            textEditPoNo.Text = string.Empty;
            //dateEditDelivery.Text = string.Empty;
            gridLookUpEditPartNo.Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createdDate"></param>
        /// <param name="boxQuantity"></param>
        /// <param name="cno"></param>
        /// <param name="deliveryDate"></param>
        /// <param name="finalConsignee"></param>
        /// <param name="supplier"></param>
        /// <param name="grossWeight"></param>
        /// <param name="manufactureDate"></param>
        /// <param name="partNo"></param>
        /// <param name="poNo"></param>
        /// <param name="poQuantity"></param>
        private void InsertToDatabase(string createdDate, string boxQuantity, string cno, string deliveryDate, string finalConsignee, string supplier, string grossWeight, string manufactureDate, string partNo, string poNo, string poQuantity)
        {
            var label = new Data.Label()
            {
                CreatedDate = createdDate,
                BoxQuantity = boxQuantity,
                CNO = cno,
                DeliveryDate = deliveryDate,
                FinalConsignee = finalConsignee,
                Supplier = supplier,
                GrossWeight = grossWeight,
                ManufactureDate = manufactureDate,
                PartNo = partNo,
                PoNo = poNo,
                POQuantity = poQuantity,
            };
            try
            {
                _cartonLabelService.Add(label);
                ResetControls();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadGirdLookUpPartNo()
        {
            gridLookUpEditPartNo.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditPartNo.Properties.DisplayMember = "PartNoValue";
            gridLookUpEditPartNo.Properties.ValueMember = "PartNoID";
            gridLookUpEditPartNo.Properties.View.BestFitColumns();
            //gridLookUpEditPartNo.Properties.PopupFormWidth = 216;
            gridLookUpEditPartNo.Properties.PopupFormWidth = 300;
            gridLookUpEditPartNo.Properties.DataSource = _partNoService.GetPartNoes();
        }

        private void FormInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgresult = MessageBox.Show(@"Bạn có thực sự muốn đóng chương trình không?", @"THÔNG BÁO",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning);
            if (dlgresult == DialogResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                Application.ExitThread();
            }
        }

        private void gridLookUpEditPartNo_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var part = new FormAddPartNo();
                part.ShowDialog();
                LoadGirdLookUpPartNo();
            }
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case Keys.Control | Keys.P:
        //            {
        //                btnPreview.PerformClick();
        //                return true;
        //            }
        //        case Keys.Escape:
        //            {
        //                btnClose.PerformClick();
        //                return true;
        //            }
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}