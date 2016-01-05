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
    public partial class FormImportDepartmentFormExel : XtraForm
    {

        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private readonly DepartmentService _departmentService;
        public FormImportDepartmentFormExel()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
        }

        /// <summary>
        /// Duyệt file exel
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
            var departments = from a in excelFile.Worksheet<Department>(sheetName) select a;

            gridControl1.DataSource = departments;
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextId()
        {
            string lastId = _departmentService.GetDepartments().Last().DepartmentID.Remove(0, 3);
            string areaId;
            if (!string.IsNullOrEmpty(lastId))
            {
                int nextId = int.Parse(lastId) + 1;
                areaId = string.Format("BP{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
            }
            else
            {
                areaId = string.Format("BP0000{0}", 1);
            }
            return areaId;
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
                FileName = "Bo-Phan.xls",
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    _waitDialog.CreateWaitDialog();
                    _waitDialog.SetWaitDialogCaption("Chương trình đang mở file");

                    string path = Path.Combine(Environment.CurrentDirectory, @"ExcelTemplate\\Departments.xls");
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "ExcelTemplate\\Departments.xls";
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
                excelFile.AddMapping<Department>(x => x.DepartmentName, "DepartmentName");
                excelFile.AddMapping<Department>(x => x.Description, "Description");

                excelFile.TrimSpaces = TrimSpacesType.Both;
                excelFile.ReadOnly = true;

                IQueryable<Department> departments = (from a in excelFile.Worksheet<Department>(sheetName) select a);

                try
                {
                    foreach (Department department in departments)
                    {
                        if (!_departmentService.CheckDepartmentNameExits(department.DepartmentName))
                        {
                            // Bỏ qua nếu đã tồn tại rồi
                            if (radioButtonIgnoreIfDepartmentExits.Checked)
                            {
                                countExits++;                   
                            }
                            // Cập nhật nếu tên Bộ Phận đã tồn tại rồi
                            if (radioButtonUpdateIfDepartmentExits.Checked)
                            {
                                Department updateDepartment = _departmentService.GetDepartmentName(department.DepartmentName);
                                updateDepartment.UpdateBy = userName;
                                updateDepartment.ModifyDate = DateTime.Now;
                                updateDepartment.DepartmentName = department.DepartmentName;
                                updateDepartment.Description = department.Description;
                                try
                                {
                                    _departmentService.Update(updateDepartment);
                                    countUpdate++;
                                    strUpdate += string.Format("{0}, ", department.DepartmentName);
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
                            department.DepartmentID = NextId();
                            department.CreatedDate = DateTime.Now;
                            department.CreatedBy = userName;
                            department.IsActive = true; 
                            try
                            {
                                _departmentService.Add(department);
                                countInsert++;
                                strInsert += string.Format("{0}, ", department.DepartmentName);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi thêm mới \n{0}", ex.Message));
                            }
                        }
                        
                    }
                    if (XtraMessageBox.Show(
                        string.Format("Thực hiện thành công.\n" +
                                      "=> Bỏ qua: {3} - Bộ phận đã tồn tại \n" +
                                      "=> Thêm mới: {0} - {2} \n" +
                                      "=> Cập nhật: {1} - {4}" +
                                      "\nBạn có muốn thêm mới Bộ Phận nữa không?", countInsert, countUpdate, strInsert, countExits, strUpdate), 
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormImportDepartmentFormExel_KeyDown(object sender, KeyEventArgs e)
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