using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using LinqToExcel;
using LinqToExcel.Query;
using Microsoft.Office.Interop.Excel;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Models;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormImportProductFormExcel : XtraForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private readonly SuppliersService _suppliersService;
        private readonly ProductGroupService _productGroupService;
        private readonly ProductService _productService;
        private readonly StockService _stockService;
        private readonly UnitService _unitService;
        private readonly ColorService _colorService;
        private readonly string _userName = Program.CurrentUser.UserName;
        private string _productGroupId;
        private string _stockId;
        private string _unitId;
        private string _supplierId;
        private int _colorId;
        public FormImportProductFormExcel()
        {
            InitializeComponent();
            _suppliersService = new SuppliersService();
            _productGroupService = new ProductGroupService();
            _productService = new ProductService();
            _stockService = new StockService();
            _unitService = new UnitService();
            _colorService = new ColorService();
        }

        /// <summary>
        /// Duyệt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textEditPathFileExel_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                var theDialog = new OpenFileDialog
                {
                    Title = Resources.TitleSelectedFileExcel,
                    Filter = Resources.FilterFormartExel2003,
                    //theDialog.InitialDirectory = @"C:\Destop";
                };

                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    textEditPathFileExel.Text = theDialog.FileName;
                    if (!string.IsNullOrEmpty(theDialog.FileName))
                    {
                        ReadingDataFormExcels(textEditPathFileExel.Text);
                    }
                }
            }
        }

        /// <summary>
        /// Đọc file excel
        /// </summary>
        /// <param name="filePath"></param>
        private void ReadingDataFormExcels(string filePath)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang mở file");

            const string sheetName = "Sheet1";

            var excelFile = new ExcelQueryFactory(filePath);
            var suppliers = from a in excelFile.Worksheet<ImportProductView>(sheetName) select a;

            gridControl1.DataSource = suppliers;
            _waitDialog.CloseWait();
        }

        

        /// <summary>
        /// Lưu file excel mẫu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelAreaExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileDialogFilterExel,
                Title = Resources.SaveFileDialogTitle,
                FileName = "Hang-Hoa.xls",
            };

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    _waitDialog.CreateWaitDialog();
                    _waitDialog.SetWaitDialogCaption("Chương trình đang mở file");

                    string path = Path.Combine(Environment.CurrentDirectory, @"ExcelTemplate\\Products.xls");
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "ExcelTemplate\\Products.xls";
                    try
                    {
                        string filePath = saveFileDialog1.FileName;
                        var excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Workbook workBook = excelApp.Workbooks.Open(path, ReadOnly: false);
                        workBook.SaveAs(filePath, AccessMode: XlSaveAsAccessMode.xlShared);
                        var fi = new FileInfo(filePath);
                        if (fi.Exists)
                        {
                            System.Diagnostics.Process.Start(filePath);
                            _waitDialog.CloseWait();
                        }
                        workBook.Close();
                    }

                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi! \n{0}", ex.Message));
                    }
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Lưu thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDataFormExel_Click(object sender, EventArgs e)
        {
            
            string strUpdate = null;
            string strInsert = null;
            int countUpdate = 0;
            int countInsert = 0;
            int countExits = 0;
            if (!string.IsNullOrEmpty(textEditPathFileExel.Text))
            {
                const string sheetName = "Sheet1";
                string pathToExcelFile = textEditPathFileExel.Text.Trim();
                var excelFile = new ExcelQueryFactory(pathToExcelFile);
                excelFile.AddMapping<Product>(x => x.ProductID, null);
                excelFile.AddMapping<Product>(x => x.ProductName, "ProductName");
                excelFile.AddMapping<Product>(x => x.ProductGroupID, "ProductGroupName");
                excelFile.AddMapping<Product>(x => x.StockID, "StockName");
                excelFile.AddMapping<Product>(x => x.UnitID, "UnitkName");
                excelFile.AddMapping<Product>(x => x.SupplierID, "SupplierName");
                excelFile.AddMapping<Product>(x => x.Barcode, null);
                excelFile.AddMapping<Product>(x => x.Origin, "Origin");
                excelFile.AddMapping<Product>(x => x.TaxCode, null);
                excelFile.AddMapping<Product>(x => x.Quantity, null);
                excelFile.AddMapping<Product>(x => x.ExpireDate, "ExpireDate");
                excelFile.AddMapping<Product>(x => x.Image, null);
                excelFile.AddMapping<Product>(x => x.Description, "Description");
                excelFile.AddMapping<Product>(x => x.IsActive, null);
                excelFile.AddMapping<Product>(x => x.CreatedDate, null);
                excelFile.AddMapping<Product>(x => x.ModifyDate, null);
                excelFile.AddMapping<Product>(x => x.CreatedBy, null);
                excelFile.AddMapping<Product>(x => x.UpdateBy, null);
                excelFile.AddMapping<Product>(x => x.Price, "Price");
                excelFile.AddMapping<Product>(x => x.ColorID, null);

                
                excelFile.TrimSpaces = TrimSpacesType.Both;
                excelFile.ReadOnly = true;

                IQueryable<Product> products = (from a in excelFile.Worksheet<Product>(sheetName) select a);

                try
                {
                    foreach (Product product in products)
                    {
                        // Kiểm tra nếu ID Nhóm Hàng
                        // => Đã tồn tại rồi thì trả về thông tin của Nhóm Hàng đó
                        // => Chưa tồn tại Tên Nhóm hàng này thì thực hiện thêm mới
                        // => Nếu Tên Nhóm Hàng không được người dùng nhập vào thì gán = null
                        _productGroupId = InsertOrUpdateProductGroup(product.ProductGroupID) != null ? InsertOrUpdateProductGroup(product.ProductGroupID).ProductGroupID : null;

                        // Kiểm tra nếu ID Kho Hàng
                        // => Đã tồn tại rồi thì trả về thông tin của Kho Hàng đó
                        // => Chưa tồn tại Tên Kho hàng này thì thực hiện thêm mới
                        // => Nếu Tên Kho Hàng không được người dùng nhập vào thì gán = null
                        _stockId = InsertOrUpdateStock(product.StockID) != null ? InsertOrUpdateStock(product.StockID).StockID : null;

                        // Kiểm tra nếu ID Đơn Vị Tính
                        // => Đã tồn tại rồi thì trả về thông tin của Đơn Vị Tính đó
                        // => Chưa tồn tại Tên Đơn Vị Tính này thì thực hiện thêm mới
                        // => Nếu Tên Đơn Vị Tính không được người dùng nhập vào thì gán = null
                        _unitId = InsertOrUpdateUnit(product.UnitID) != null ? InsertOrUpdateUnit(product.UnitID).UnitID : null;

                        // Kiểm tra nếu ID Nhà Cung Cấp
                        // => Đã tồn tại rồi thì trả về thông tin của Nhà Cung Cấp đó
                        // => Chưa tồn tại Tên Nhà Cung Cấp này thì thực hiện thêm mới
                        // => Nếu Tên Nhà Cung Cấp không được người dùng nhập vào thì gán = null
                        _supplierId = InsertOrUpdateSupplier(product.SupplierID) != null ? InsertOrUpdateSupplier(product.SupplierID).SupplierID : null;

                        // Kiểm tra nếu ID Màu Sắc
                        // => Đã tồn tại rồi thì trả về thông tin của Màu Sắc đó
                        // => Chưa tồn tại Tên Màu Sắc này thì thực hiện thêm mới
                        // => Nếu Tên Màu Sắc không được người dùng nhập vào thì gán = 0
                        _colorId = InsertOrUpdateColor(product.ColorID.ToString()) != null ? InsertOrUpdateColor(product.ColorID.ToString()).ColorID :  0;

                        if (!_productService.CheckProductNameExit(product.ProductName))
                        {
                            // Bỏ qua nếu đã tồn tại rồi
                            if (radioButtonIgnoreIfDepartmentExits.Checked)
                            {
                                countExits++;
                            }
                            // Cập nhật nếu tên Bộ Phận đã tồn tại rồi
                            if (radioButtonUpdateIfDepartmentExits.Checked)
                            {
                                Product updateProduct = _productService.GetProductByName(product.ProductName);
                                updateProduct.UpdateBy = _userName;
                                updateProduct.ModifyDate = DateTime.Now;

                                if (!string.IsNullOrEmpty(_productGroupId))
                                {
                                    updateProduct.ProductGroupID = _productGroupId;
                                }
                                if (!string.IsNullOrEmpty(_stockId))
                                {
                                    updateProduct.StockID = _stockId;
                                }
                                if (!string.IsNullOrEmpty(_unitId))
                                {
                                    updateProduct.UnitID = _unitId;
                                }
                                if (!string.IsNullOrEmpty(_supplierId))
                                {
                                    updateProduct.SupplierID = _supplierId;
                                }
                                if (_colorId > 0)
                                {
                                    updateProduct.ColorID = _colorId;
                                }
                                try
                                {
                                    _productService.Update(updateProduct);
                                    countUpdate++;
                                    strUpdate += string.Format("{0}, ", updateProduct.ProductName);
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show(string.Format("Lỗi cập nhật \n{0}", ex.Message));
                                }

                            }
                        }
                        // Nếu tên chưa tồn tại thì thực hiện thêm mới
                        else
                        {
                            product.ProductID = _productService.NextId();
                            if (!string.IsNullOrEmpty(_productGroupId))
                            {
                                product.ProductGroupID = _productGroupId;
                            }
                            product.CreatedDate = DateTime.Now;
                            product.CreatedBy = _userName;
                            product.IsActive = true;
                            try
                            {
                                _productService.Add(product);
                                countInsert++;
                                strInsert += string.Format("{0}, ", product.ProductName);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi thêm mới \n{0}", ex.Message));
                            }
                        }
                    }
                    if (XtraMessageBox.Show(
                        string.Format("Thực hiện thành công.\n" +
                                      "=> Bỏ qua: {3} - Nhà Cung Cấp đã tồn tại \n" +
                                      "=> Thêm mới: {0} - {2} \n" +
                                      "=> Cập nhật: {1} - {4} \n" +
                                      "Bạn có muốn thêm mới Hàng Hóa nữa không?", countInsert, countUpdate, strInsert, countExits, strUpdate),
                                      "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        gridControl1.DataSource = null;
                        textEditPathFileExel.Text = string.Empty;
                    }
                    else
                    {
                        DialogResult = DialogResult.No;
                    }
                }

                catch (DbEntityValidationException ex)
                {
                    var sb = new StringBuilder();
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        sb.AppendLine(String.Format("Entity of type '{0}' in state '{1}' has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(String.Format("- Property: '{0}', Error: '{1}'", ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                    throw new Exception(sb.ToString(), ex);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn tập tin để nhập", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditPathFileExel.Focus();
            }
        }

        #region Nhóm Hàng
        /// <summary>
        /// Thêm mới hoặc Cập nhật thông tin Nhóm Hàng
        /// </summary>
        /// <param name="productGroupName"></param>
        private ProductGroup InsertOrUpdateProductGroup(string productGroupName)
        {
            if (!string.IsNullOrEmpty(productGroupName))
            {
                ProductGroup productGroup;
                if (!_productGroupService.CheckProductGroupNameExit(productGroupName))
                {
                    productGroup = _productGroupService.GetProductGrouprByName(productGroupName);
                }
                else
                {
                    productGroup = new ProductGroup()
                    {
                        ProductGroupID = _productGroupService.NextId(),
                        ProductGroupName = productGroupName,
                        CreatedBy = _userName,
                        CreatedDate = DateTime.Now,
                        Description = productGroupName,
                    };
                    try
                    {
                        _productGroupService.Add(productGroup);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Nhóm Hàng \n{0}", ex.Message));
                    }
                }
                return productGroup;
            }
            return null;
        }
        #endregion

        #region Kho Hàng
        /// <summary>
        /// Thêm mới hoặc Cập nhật thông tin Nhóm Hàng
        /// </summary>
        /// <param name="stockName"></param>
        private Data.Stock InsertOrUpdateStock(string stockName)
        {
            if (!string.IsNullOrEmpty(stockName))
            {
                Data.Stock stock;
                if (!_stockService.CheckStockNameExit(stockName))
                {
                    stock = _stockService.GetStockByName(stockName);
                }
                else
                {
                    stock = new Data.Stock()
                    {
                        StockID = _stockService.NextId(),
                        StockName = stockName,
                        CreatedBy = _userName,
                        CreatedDate = DateTime.Now,
                        Description = stockName,
                        IsActive = true,
                    };
                    try
                    {
                        _stockService.Add(stock);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Kho Hàng \n{0}", ex.Message));
                    }
                }
                return stock;
            }
            return null;
        }
        #endregion

        #region Nhà Cung Cấp
        /// <summary>
        /// Thêm mới hoặc Cập nhật thông tin Nhà Cung Cấp
        /// </summary>
        /// <param name="supplierName"></param>
        private Data.Supplier InsertOrUpdateSupplier(string supplierName)
        {
            if (!string.IsNullOrEmpty(supplierName))
            {
                Supplier supplier;
                if (!_suppliersService.CheckSupplierNameExit(supplierName))
                {
                    supplier = _suppliersService.GetSupplierByName(supplierName);
                }
                else
                {
                    supplier = new Supplier()
                    {
                        SupplierID = _suppliersService.NextId(),
                        SupplierName = supplierName,
                        CreatedBy = _userName,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    try
                    {
                        _suppliersService.Add(supplier);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Nhà Cung Cấp \n{0}", ex.Message));
                    }
                }
                return supplier;
            }
            return null;
        }
        #endregion

        #region Đơn Vị Tính
        /// <summary>
        /// Thêm mới hoặc Cập nhật thông tin Nhà Cung Cấp
        /// </summary>
        /// <param name="unitName"></param>
        private Unit InsertOrUpdateUnit(string unitName)
        {
            if (!string.IsNullOrEmpty(unitName))
            {
                Unit unit;
                if (!_unitService.CheckUnitNameExit(unitName))
                {
                    unit = _unitService.GetUnitByName(unitName);
                }
                else
                {
                    unit = new Unit()
                    {
                        UnitID = StringHelper.RemoveChar(unitName),
                        UnitName = unitName,
                        Description = unitName,
                        CreatedBy = _userName,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    try
                    {
                        _unitService.Add(unit);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Đơn Vị Tính \n{0}", ex.Message));
                    }
                }
                return unit;
            }
            return null;
        }
        #endregion

        #region Màu Sắc
        /// <summary>
        /// Thêm mới hoặc Cập nhật thông tin Nhà Cung Cấp
        /// </summary>
        /// <param name="colorName"></param>
        private Color InsertOrUpdateColor(string colorName)
        {
            if (!string.IsNullOrEmpty(colorName))
            {
                Color color;
                if (!_colorService.CheckUnitNameExit(colorName))
                {
                    color = _colorService.GetColorByName(colorName);
                }
                else
                {
                    color = new Color()
                    {
                        ColorCode = colorName,
                        Description = colorName,
                        ColorName = colorName,
                        IsActive = true,
                    };
                    try
                    {
                        _colorService.Add(color);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Màu Sắc \n{0}", ex.Message));
                    }
                }
                return color;
            }
            return null;
        }
        #endregion

        private void FormImportProductFormExcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSaveDataFormExel.PerformClick();
                        break;
                }
            }

            // Đóng form
            if ((Keys)e.KeyValue == Keys.Escape)
                btnClose.PerformClick();
        }
    }
}