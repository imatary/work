using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormInsertOrUpdateProduct : XtraForm
    {
        private readonly ProductService _productService;
        private readonly StockService _stockService;
        private readonly ProductGroupService _productGroupService;
        private readonly UnitService _unitService;
        private readonly LogService _logService;
        private string _productId;
        private Product _product;
        public FormInsertOrUpdateProduct(string productId)
        {
            InitializeComponent();

            _productId = productId;
            _productService = new ProductService();
            _stockService = new StockService();
            _productGroupService = new ProductGroupService();
            _unitService = new UnitService();
            _logService = new LogService();      
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditStock.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditStock, "Kho Hàng");
            }
            else if (string.IsNullOrEmpty(gridLookUpEditProductGroup.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditProductGroup, "Nhóm Hàng");
            }
            else if (string.IsNullOrEmpty(txtProductID.Text))
            {
                Ultils.TextControlNotNull(txtProductID, "Mã Hàng");
            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                Ultils.TextControlNotNull(txtProductName, "Tên Hàng");
            }
            else if (string.IsNullOrEmpty(gridLookUpEditUnit.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditUnit, "Đơn Vị Tính");
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                Ultils.TextControlNotNull(txtPrice, "Giá Nhập");
            }
            else
            {
                if (string.IsNullOrEmpty(_productId))
                {
                    _product = new Product()
                    {
                        ProductID = txtProductID.Text,
                        ProductName = txtProductName.Text,
                        ProductGroupID = gridLookUpEditProductGroup.EditValue.ToString(),
                        StockID = gridLookUpEditStock.EditValue.ToString(),
                        UnitID = gridLookUpEditUnit.EditValue.ToString(),
                        Origin = txtOrigin.Text,
                        Barcode = string.IsNullOrEmpty(txtBarcode.Text) ? _productService.NextId() : txtBarcode.Text,
                        //Quantity = int.Parse(txtQuantity.Text),
                        Color = txtColor.Text,
                        Supplier = txtSupplier.Text,
                        Description = txtDescription.Text,
                        Active = checkActive.Checked,
                        CreatedDate = DateTime.Now,
                        Price = Convert.ToInt32(txtPrice.Text),
                        CreatedBy = Program.CurrentUser.Username,
                    };
                    //if (!string.IsNullOrEmpty(gridLookUpEditColor.SelectedText))
                    //{
                    //    product.ColorID = Convert.ToInt32(gridLookUpEditColor.EditValue.ToString());
                    //}
                    try
                    {
                        _productService.Add(_product);
                        ResetControls();
                        _logService.InsertLog(Program.CurrentUser.Username, "Thêm", this.Text);
                        MessageBoxHelper.ShowMessageBoxInfo("Thêm thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowMessageBoxError(ex.Message);
                    }
                }
                else
                {
                    // Update
                    _product = _productService.GetProductById(_productId);
                    if (_product != null)
                    {
                        _product.ProductName = txtProductName.Text;
                        _product.ProductGroupID = gridLookUpEditProductGroup.EditValue.ToString();
                        _product.StockID = gridLookUpEditStock.EditValue.ToString();
                        _product.UnitID = gridLookUpEditUnit.EditValue.ToString();
                        _product.Supplier = txtSupplier.Text;
                        _product.Barcode = txtBarcode.Text;
                        _product.Origin = txtOrigin.Text;
                        //product.Quantity = int.Parse(txtQuantity.Text);
                        _product.Description = txtDescription.Text;
                        _product.Active = checkActive.Checked;
                        _product.ModifyDate = DateTime.Now;
                        _product.ModifyBy = Program.CurrentUser.Username;
                        _product.Price = int.Parse(txtPrice.Text);
                        //if (!string.IsNullOrEmpty(gridLookUpEditColor.SelectedText))
                        //{
                        //    product.ColorID = Convert.ToInt32(gridLookUpEditColor.EditValue.ToString());
                        //}
                    }
                    try
                    {
                        _productService.Update(_product);
                        _logService.InsertLog(Program.CurrentUser.Username, "Sửa", this.Text);
                        MessageBoxHelper.ShowMessageBoxInfo("Sửa thành công!");
                        this.Dispose();

                    }
                    catch (Exception ex)
                    {
                       MessageBoxHelper.ShowMessageBoxError(ex.Message); 

                    }

                }
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Resources.MessageBoxColseForm, Resources.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void GetProductById(string productId)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                Product product = _productService.GetProductById(productId);
                if (product != null)
                {
                    txtProductID.Text = product.ProductID;
                    txtProductName.Text = product.ProductName;
                    gridLookUpEditProductGroup.EditValue = product.ProductGroupID;
                    gridLookUpEditStock.EditValue = product.StockID;
                    gridLookUpEditUnit.EditValue = product.UnitID;
                    txtBarcode.Text = product.Barcode;
                    txtOrigin.Text = product.Origin;
                    //txtQuantity.Text = product.Quantity.ToString();
                    txtDescription.Text = product.Description;
                    txtPrice.Text = product.Price.ToString();
                    if (product.Active != null)
                        checkActive.Checked = (bool) product.Active;
                }
            }

            else
            {
                txtProductID.Text = _productService.NextId();
            }

        }

        private void FormInsertOrUpdateProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show(Resources.MessageBoxColseForm,
                    Resources.MessageBoxTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (mboxResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (mboxResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Dispose();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    {
                        btnSave.PerformClick();
                        return true;
                    }
                case Keys.Escape:
                    {
                        btnClose.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ResetControls()
        {
            _productId = null;
            txtProductID.Text = _productService.NextId();
            txtBarcode.Text = _productService.NextId();
            gridLookUpEditProductGroup.EditValue = null;
            gridLookUpEditProductGroup.Text = string.Empty;

            gridLookUpEditStock.EditValue = null;
            gridLookUpEditStock.Text = string.Empty;

            gridLookUpEditUnit.EditValue = null;
            gridLookUpEditUnit.Text = string.Empty;

            txtColor.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtOrigin.Text = string.Empty;

            txtPrice.EditValue = string.Empty;
            txtPrice.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtSupplier.Text = string.Empty;

        }

        private void LoadGirdLookUpStock()
        {
            var stocks = _stockService.GetStocks();
            gridLookUpEditStock.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditStock.Properties.DisplayMember = "StockName";
            gridLookUpEditStock.Properties.ValueMember = "StockID";
            gridLookUpEditStock.Properties.View.BestFitColumns();
            gridLookUpEditStock.Properties.PopupFormWidth = 300;
            gridLookUpEditStock.Properties.DataSource = stocks;
        }

        /// <summary>
        /// Load danh sách nhóm hàng
        /// </summary>
        private void LoadGirdLookUpProductGroup()
        {
            var stocks = _productGroupService.GetProductGroups();
            gridLookUpEditProductGroup.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditProductGroup.Properties.DisplayMember = "ProductGroupName";
            gridLookUpEditProductGroup.Properties.ValueMember = "ProductGroupID";
            gridLookUpEditProductGroup.Properties.View.BestFitColumns();
            gridLookUpEditProductGroup.Properties.PopupFormWidth = 406;
            gridLookUpEditProductGroup.Properties.DataSource = stocks;
        }


        /// <summary>
        /// Load danh sách Đơn vị tính
        /// </summary>
        private void LoadGirdLookUpUnit()
        {
            var units = _unitService.GetUnits();
            gridLookUpEditUnit.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditUnit.Properties.DisplayMember = "UnitName";
            gridLookUpEditUnit.Properties.ValueMember = "UnitID";
            gridLookUpEditUnit.Properties.View.BestFitColumns();
            gridLookUpEditUnit.Properties.PopupFormWidth = 300;
            gridLookUpEditUnit.Properties.DataSource = units;

        }

        private void FormInsertOrUpdateProduct_Load(object sender, EventArgs e)
        {
            GetProductById(_productId);
            LoadGirdLookUpStock();
            LoadGirdLookUpProductGroup();
            LoadGirdLookUpUnit();
        }

        private void gridLookUpEditStock_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var stock = new FormInsertOrUpdateStock(null);
                stock.ShowDialog();
                LoadGirdLookUpStock();
            }
            
        }

        private void gridLookUpEditProductGroup_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var productGroup = new FormInsertOrUpdateProductGroup(null);
                productGroup.ShowDialog();
                LoadGirdLookUpProductGroup();
            } 
        }

        private void gridLookUpEditUnit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var unit = new FormInsertOrUpdateUnit(null);
                unit.ShowDialog();
                LoadGirdLookUpUnit();
            }    
        }
    }
}