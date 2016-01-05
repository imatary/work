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
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormImportProductGroupFormExcel : XtraForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private readonly ProductGroupService _productGroupService;
        public FormImportProductGroupFormExcel()
        {
            InitializeComponent();
            _productGroupService = new ProductGroupService();
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
                    if (!string.IsNullOrEmpty(textEditPathFileExel.Text))
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
            const string sheetName = "Sheet1";

            var excelFile = new ExcelQueryFactory(filePath);
            // ADD COLUMN MAPPINGS:
            //excelFile.AddMapping("AreaName", "Tên");
            //excelFile.AddMapping("Description", "Ghi Chú");
            var productGroups = from a in excelFile.Worksheet<ProductGroup>(sheetName) select a;

            gridControl1.DataSource = productGroups;
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextId()
        {
            string lastId = _productGroupService.GetProductGroups().Last().ProductGroupID.Remove(0, 3);
            string productGroupId;
            if (!string.IsNullOrEmpty(lastId))
            {
                int nextId = int.Parse(lastId) + 1;
                productGroupId = string.Format("NH{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
            }
            else
            {
                productGroupId = string.Format("NH0000{0}", 1);
            }
            return productGroupId;
        }

        /// <summary>
        /// Xuất file excel Mẫu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelAreaExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileDialogFilterExel,
                Title = Resources.SaveFileDialogTitle,
                FileName = "Nhom-Hang.xls",
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    _waitDialog.CreateWaitDialog();
                    _waitDialog.SetWaitDialogCaption("Chương trình đang mở file");

                    string path = Path.Combine(Environment.CurrentDirectory, @"ExcelTemplate\\ProductGroups.xls");
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "ExcelTemplate\\ProductGroups.xls";
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
                        //else
                        //{
                        //    XtraMessageBox.Show("File không tồn tại");
                        //}
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
            string userName = Program.CurrentUser.UserName;
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
                excelFile.AddMapping<ProductGroup>(x => x.ProductGroupName, "ProductGroupName");
                excelFile.AddMapping<ProductGroup>(x => x.Description, "Description");

                excelFile.TrimSpaces = TrimSpacesType.Both;
                excelFile.ReadOnly = true;

                IQueryable<ProductGroup> productGroups = (from a in excelFile.Worksheet<ProductGroup>(sheetName) select a);

                try
                {
                    foreach (ProductGroup productGroup in productGroups)
                    {
                        if (!_productGroupService.CheckProductGroupNameExit(productGroup.ProductGroupName))
                        {
                            // Bỏ qua nếu đã tồn tại rồi
                            if (radioButtonIgnoreIfDepartmentExits.Checked)
                            {
                                countExits++;
                            }
                            // Cập nhật nếu tên Bộ Phận đã tồn tại rồi
                            if (radioButtonUpdateIfDepartmentExits.Checked)
                            {
                                ProductGroup updateProductGroup = _productGroupService.GetProductGrouprByName(productGroup.ProductGroupName);
                                updateProductGroup.UpdateBy = userName;
                                updateProductGroup.ModifyDate = DateTime.Now;
                                try
                                {
                                    _productGroupService.Update(updateProductGroup);
                                    countUpdate++;
                                    strUpdate += string.Format("{0}, ", productGroup.ProductGroupName);
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
                            productGroup.ProductGroupID = NextId();
                            productGroup.CreatedDate = DateTime.Now;
                            productGroup.CreatedBy = userName;
                            productGroup.IsActive = true;
                            try
                            {
                                _productGroupService.Add(productGroup);
                                countInsert++;
                                strInsert += string.Format("{0}, ", productGroup.ProductGroupName);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi thêm mới \n{0}", ex.Message));
                            }
                        }

                    }
                    if (XtraMessageBox.Show(
                        string.Format("Thực hiện thành công.\n" +
                                      "=> Bỏ qua: {3} - Nhóm Hàng đã tồn tại \n" +
                                      "=> Thêm mới: {0} - Nhóm Hàng \n" +
                                      "=> Cập nhật: {1} - Nhóm Hàng \n" +
                                      "Bạn có muốn thêm mới Bộ Phận nữa không?", countInsert, countUpdate, strInsert, countExits, strUpdate),
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

        private void FormImportProductGroupFormExcel_KeyDown(object sender, KeyEventArgs e)
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