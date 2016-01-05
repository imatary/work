using System;
using System.Data.Entity.Validation;
using System.Globalization;
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
    public partial class FormImportSuppliersFormExcel : XtraForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private readonly SuppliersService _suppliersService;
        private readonly AreaService _areaService;
        private readonly string _userName = Program.CurrentUser.UserName;
        private string _areaId;
        public FormImportSuppliersFormExcel()
        {
            InitializeComponent();
            _suppliersService = new SuppliersService();
            _areaService = new AreaService();
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
            // ADD COLUMN MAPPINGS:
            //excelFile.AddMapping("AreaName", "Tên");
            //excelFile.AddMapping("Description", "Ghi Chú");
            var suppliers = from a in excelFile.Worksheet<ImportSupplierView>(sheetName) select a;

            gridControl1.DataSource = suppliers;
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextId()
        {
            Supplier suppliers = _suppliersService.GetSuppliers().Last();
            if (suppliers != null)
            {
                string lastId = suppliers.SupplierID.Remove(0, 3);
                string suppliersId;
                if (!string.IsNullOrEmpty(lastId))
                {
                    int nextId = int.Parse(lastId) + 1;
                    suppliersId = string.Format("NCC{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                }
                else
                {
                    suppliersId = string.Format("NCC0000{0}", 1);
                }
                return suppliersId;
            }
            return string.Format("NCC0000{0}", 1);
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
                FileName = "Nha-Cung-Cap.xls",
            };

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    _waitDialog.CreateWaitDialog();
                    _waitDialog.SetWaitDialogCaption("Chương trình đang mở file");

                    string path = Path.Combine(Environment.CurrentDirectory, @"ExcelTemplate\\Suppliers.xls");
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "ExcelTemplate\\Suppliers.xls";
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
                excelFile.AddMapping<Supplier>(x => x.AreaID, "AreaName");
                excelFile.AddMapping<Supplier>(x => x.SupplierName, "SupplierName");
                excelFile.AddMapping<Supplier>(x => x.PhoneNumber, "PhoneNumber");
                excelFile.AddMapping<Supplier>(x => x.Address, "Address");
                excelFile.AddMapping<Supplier>(x => x.Email, "Email");
                excelFile.AddMapping<Supplier>(x => x.AccountNumber, "AccountNumber");
                excelFile.AddMapping<Supplier>(x => x.Bank, "Bank");
                excelFile.AddMapping<Supplier>(x => x.TaxCode, "TaxCode");
                excelFile.AddMapping<Supplier>(x => x.Fax, "Fax");
                excelFile.AddMapping<Supplier>(x => x.Website, "Website");
                
                excelFile.TrimSpaces = TrimSpacesType.Both;
                excelFile.ReadOnly = true;

                IQueryable<Supplier> suppliers = (from a in excelFile.Worksheet<Supplier>(sheetName) select a);

                try
                {
                    foreach (Supplier supplier in suppliers)
                    {
                        // Kiểm tra nếu ID Khu Vực
                        // => Đã tồn tại rồi thì trả về thông tin của Khu vực đó
                        // => Chưa tồn tại Tên khu vực này thì thực hiện thêm mới khu vực
                        // => Nếu Tên Khu vực không được người dùng nhập vào thì gán = null
                        _areaId = InsertOrUpdateArea(supplier.AreaID) != null ? InsertOrUpdateArea(supplier.AreaID).AreaID : null;

                        if (!_suppliersService.CheckSupplierNameExit(supplier.SupplierName))
                        {
                            // Bỏ qua nếu đã tồn tại rồi
                            if (radioButtonIgnoreIfDepartmentExits.Checked)
                            {
                                countExits++;
                            }
                            // Cập nhật nếu tên Bộ Phận đã tồn tại rồi
                            if (radioButtonUpdateIfDepartmentExits.Checked)
                            {
                                Supplier updateSupplier = _suppliersService.GetSupplierByName(supplier.SupplierName);
                                updateSupplier.UpdateBy = _userName;
                                updateSupplier.ModifyDate = DateTime.Now;

                                if (!string.IsNullOrEmpty(_areaId))
                                {
                                    updateSupplier.AreaID = _areaId;
                                }
                                
                                try
                                {
                                    _suppliersService.Update(updateSupplier);
                                    countUpdate++;
                                    strUpdate += string.Format("{0}, ", supplier.SupplierName);
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
                            supplier.SupplierID = NextId();
                            if (!string.IsNullOrEmpty(_areaId))
                            {
                                supplier.AreaID = _areaId;
                            }
                            supplier.CreatedDate = DateTime.Now;
                            supplier.CreatedBy = _userName;
                            supplier.SupplierName = supplier.SupplierName;
                            supplier.IsActive = true;
                            try
                            {
                                _suppliersService.Add(supplier);
                                countInsert++;
                                strInsert += string.Format("{0}, ", supplier.SupplierName);
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
                                      "Bạn có muốn thêm mới Nhà Cung Cấp nữa không?", countInsert, countUpdate, strInsert, countExits, strUpdate),
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

        #region Khu vực
        /// <summary>
        /// Thêm mới hoặc Cập nhật thông tin Khu vực
        /// </summary>
        /// <param name="areaName"></param>
        private Area InsertOrUpdateArea(string areaName)
        {
            if (!string.IsNullOrEmpty(areaName))
            {
                Area area;
                if (!_areaService.CheckAreaNameExits(areaName))
                {
                    area = _areaService.GetAreaByName(areaName);
                }
                else
                {
                    area = new Area()
                    {
                        AreaID = NextAreaId(),
                        AreaName = areaName,
                        CreatedBy = _userName,
                        CreatedDate = DateTime.Now,
                        Description = areaName,
                    };
                    try
                    {
                        _areaService.Add(area);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Khu vực \n{0}", ex.Message));
                    }
                }
                return area;
            }
            return null;
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextAreaId()
        {
            string lastId = _areaService.GetAreas().Last().AreaID.Remove(0, 3);
            string areaId;
            if (!string.IsNullOrEmpty(lastId))
            {
                int nextId = int.Parse(lastId) + 1;
                areaId = string.Format("KV{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
            }
            else
            {
                areaId = string.Format("KV0000{0}", 1);
            }
            return areaId;
        }
        #endregion

        private void FormImportSuppliersFormExcel_KeyDown(object sender, KeyEventArgs e)
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