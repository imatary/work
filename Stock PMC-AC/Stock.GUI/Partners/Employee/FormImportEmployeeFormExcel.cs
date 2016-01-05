﻿using System;
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
    public partial class FormImportEmployeeFormExcel : XtraForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly string _userName = Program.CurrentUser.UserName;
        private string _departmentId;
        public FormImportEmployeeFormExcel()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
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
            var employees = from a in excelFile.Worksheet<ImportEmployeeView>(sheetName) select a;

            gridControl1.DataSource = employees;
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
                FileName = "Nhan-Vien.xls",
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    _waitDialog.CreateWaitDialog();
                    _waitDialog.SetWaitDialogCaption("Chương trình đang mở file");

                    string path = Path.Combine(Environment.CurrentDirectory, @"ExcelTemplate\\Employees.xls");
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "ExcelTemplate\\Employees.xls";
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
                excelFile.AddMapping<Employee>(x => x.DepartmentID, "DepartmentName");
                excelFile.AddMapping<Employee>(x => x.EmployeeCode, "EmployeeCode");
                excelFile.AddMapping<Employee>(x => x.EmployeeName, "EmployeeName");
                excelFile.AddMapping<Employee>(x => x.Address, "Address");
                excelFile.AddMapping<Employee>(x => x.HomeTell, "HomeTell");
                excelFile.AddMapping<Employee>(x => x.Mobile, "Mobile");
                excelFile.AddMapping<Employee>(x => x.Fax, "Fax");
                excelFile.AddMapping<Employee>(x => x.Email, "Email");
                excelFile.AddMapping<Employee>(x => x.Note, "Note");
                excelFile.AddMapping<Employee>(x => x.Sex, null);
                excelFile.AddMapping<Employee>(x => x.Birthday, null);
                excelFile.AddMapping<Employee>(x => x.IsActive, null);
                excelFile.AddMapping<Employee>(x => x.IsManagerStock, null);

                excelFile.TrimSpaces = TrimSpacesType.Both;
                excelFile.ReadOnly = true;

                IQueryable<Employee> employees = (from a in excelFile.Worksheet<Employee>(sheetName) select a);

                try
                {
                    foreach (Employee employee in employees)
                    {
                        // Kiểm tra nếu ID Bộ Phận
                        // => Đã tồn tại rồi thì trả về thông tin của Bộ Phận đó
                        // => Chưa tồn tại Tên Bộ Phận này thì thực hiện thêm mới Bộ Phận
                        // => Nếu Tên Bộ Phận không được người dùng nhập vào thì gán = null
                        _departmentId = InsertOrUpdateDepartment(employee.DepartmentID) != null ? InsertOrUpdateDepartment(employee.DepartmentID).DepartmentID : null;

                        if (!_employeeService.CheckEmployeeCodeExit(employee.EmployeeCode))
                        {
                            // Bỏ qua nếu đã tồn tại rồi
                            if (radioButtonIgnoreIfDepartmentExits.Checked)
                            {
                                countExits++;
                            }
                            // Cập nhật nếu tên Bộ Phận đã tồn tại rồi
                            if (radioButtonUpdateIfDepartmentExits.Checked)
                            {
                                Employee updateEmployee = _employeeService.GetEmployeeByCode(employee.EmployeeCode);
                                if (!string.IsNullOrEmpty(_departmentId))
                                {
                                    updateEmployee.DepartmentID = _departmentId;
                                }

                                try
                                {
                                    _employeeService.Update(updateEmployee);
                                    countUpdate++;
                                    strUpdate += string.Format("{0}, ", employee.EmployeeName);
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
                            employee.EmployeeID = _employeeService.NextId();
                            if (!string.IsNullOrEmpty(_departmentId))
                            {
                                employee.DepartmentID = _departmentId;
                            }
                            employee.IsActive = true;
                            try
                            {
                                _employeeService.Add(employee);
                                countInsert++;
                                strInsert += string.Format("{0}, ", employee.EmployeeName);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi thêm mới \n{0}", ex.Message));
                            }
                        }
                    }
                    if (XtraMessageBox.Show(
                        string.Format("Thực hiện thành công.\n" +
                                      "=> Bỏ qua: {3} - Nhân Viên đã tồn tại \n" +
                                      "=> Thêm mới: {0} - {2} \n" +
                                      "=> Cập nhật: {1} - {4} \n" +
                                      "Bạn có muốn thêm mới Nhân Viên nữa không?", countInsert, countUpdate, strInsert, countExits, strUpdate),
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
        /// Thêm mới hoặc Cập nhật thông tin Bộ Phận
        /// </summary>
        /// <param name="departmentName"></param>
        private Department InsertOrUpdateDepartment(string departmentName)
        {
            if (!string.IsNullOrEmpty(departmentName))
            {
                Department department;
                if (!_departmentService.CheckDepartmentNameExits(departmentName))
                {
                    department = _departmentService.GetDepartmentName(departmentName);
                }
                else
                {
                    department = new Department()
                    {
                        DepartmentID = NextDepartmentId(),
                        DepartmentName = departmentName,
                        CreatedBy = _userName,
                        CreatedDate = DateTime.Now,
                        Description = departmentName,
                        
                    };
                    try
                    {
                        _departmentService.Add(department);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("Lỗi thêm Bộ Phận \n{0}", ex.Message));
                    }
                }
                return department;
            }
            return null;
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextDepartmentId()
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

        #endregion

        private void FormImportEmployeeFormExcel_KeyDown(object sender, KeyEventArgs e)
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