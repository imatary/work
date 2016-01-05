using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace VAT
{
    public class ExcelWriter
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        //public ExcelWriter()
        //{
        //    // Do not delete - a parameterless constructor is required!
        //}


        public void Driver(string row, string col, string value, string path, string sheetName)
        {
            if (File.Exists(path))
            {
                try
                {
                    FnOpenExcel(path, sheetName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    WriteExcel(row, col, value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    FnCloseExcel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
        Microsoft.Office.Interop.Excel.Application application;
        Workbook workbook;
        Worksheet worksheet;
        //Open Excel file
        public int FnOpenExcel(string sPath, string iSheet)
        {

            int functionReturnValue = 0;
            try
            {

                application = new Microsoft.Office.Interop.Excel.Application { Visible = true }; //Microsoft.Office.Interop.Excel.Application();
                workbook = application.Workbooks.Open(sPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                // get all sheets in workbook
                //worksheet = (Worksheet) workbook.Worksheets;

                // get some sheet
                //string currentSheet = "Main Invoice";
                worksheet = (Worksheet) workbook.Worksheets["" + iSheet + ""];
                // Get the active sheet
                worksheet = (Worksheet)workbook.ActiveSheet;
                functionReturnValue = 0;
            }
            catch (Exception ex)
            {
                functionReturnValue = -1;
                MessageBox.Show(ex.Message);
            }
            return functionReturnValue;
        }


        // Close the excel file and release objects.
        public int FnCloseExcel()
        {
            //exlWB.Close();

            try
            {
                application.ActiveWorkbook.Save();
                application.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);

                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public void WriteExcel(string i, string j, string value)
        {
            Range exlRange = worksheet.Range["" + i + "", "" + j + ""];
            exlRange.Value2 = value;

        } 
    }
}