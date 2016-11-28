using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Lib.Core
{
    public class ControlExcelFile
    {
        // Methods
        private static void AppendNumericCell(string cellReference, string cellStringValue, Row excelRow)
        {
            Cell cell = new Cell
            {
                CellReference = cellReference
            };
            CellValue value2 = new CellValue
            {
                Text = cellStringValue
            };
            OpenXmlElement[] newChildren = new OpenXmlElement[] { value2 };
            cell.Append(newChildren);
            OpenXmlElement[] elementArray2 = new OpenXmlElement[] { cell };
            excelRow.Append(elementArray2);
        }

        private static void AppendTextCell(string cellReference, string cellStringValue, Row excelRow)
        {
            Cell cell = new Cell
            {
                CellReference = cellReference,
                //DataType = 4,
                DataType = new EnumValue<CellValues>()
            };
            CellValue value2 = new CellValue
            {
                Text = cellStringValue
            };
            OpenXmlElement[] newChildren = new OpenXmlElement[] { value2 };
            cell.Append(newChildren);
            OpenXmlElement[] elementArray2 = new OpenXmlElement[] { cell };
            excelRow.Append(elementArray2);
        }

        public static bool CreateExcelDocument<T>(List<T> list, string xlsxFilePath)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(ListToDataTable<T>(list));
            return CreateExcelDocument(ds, xlsxFilePath);
        }

        public static bool CreateExcelDocument(DataSet ds, string excelFilename)
        {
            try
            {
                //using (SpreadsheetDocument document = new SpreadsheetDocument.Create(excelFilename, SpreadsheetDocumentType.Workbook))
                //{
                //    WriteExcelFile(ds, document);
                //}
                Trace.WriteLine("Successfully created: " + excelFilename);
                return true;
            }
            catch (Exception exception)
            {
                Trace.WriteLine("Failed, exception thrown: " + exception.Message);
                return false;
            }
        }

        public static bool CreateExcelDocument(DataTable dt, string xlsxFilePath)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            bool flag = CreateExcelDocument(ds, xlsxFilePath);
            ds.Tables.Remove(dt);
            return flag;
        }

        private static string GetExcelColumnName(int columnIndex)
        {
            if (columnIndex < 0x1a)
            {
                char ch3 = (char)(0x41 + columnIndex);
                return ch3.ToString();
            }
            char ch = (char)((0x41 + (columnIndex / 0x1a)) - 1);
            char ch2 = (char)(0x41 + (columnIndex % 0x1a));
            return string.Format("{0}{1}", ch, ch2);
        }

        private static Type GetNullableType(Type t)
        {
            Type underlyingType = t;
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                underlyingType = Nullable.GetUnderlyingType(t);
            }
            return underlyingType;
        }

        private static bool IsNullableType(Type type)
        {
            return (((type == typeof(string)) || type.IsArray) || (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))));
        }

        public static DataTable ListToDataTable<T>(List<T> list)
        {
            DataTable table = new DataTable();
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                table.Columns.Add(new DataColumn(info.Name, GetNullableType(info.PropertyType)));
            }
            foreach (T local in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo info2 in typeof(T).GetProperties())
                {
                    if (!IsNullableType(info2.PropertyType))
                    {
                        row[info2.Name] = info2.GetValue(local, null);
                    }
                    else
                    {
                        row[info2.Name] = info2.GetValue(local, null) ?? DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }

        private void ReadExcel(string i_ExcelPath, string i_SheetName)
        {
            DataTable dataTable = new DataTable();
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.12.0;",
                DataSource = i_ExcelPath
            };
            if (i_ExcelPath.CompareTo(".xls") == 0)
            {
                builder.Add("Extended Properties", "Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';");
            }
            else
            {
                builder.Add("Extended Properties", "Extended Properties='Excel 12.0;HDR=NO';");
            }
            using (OleDbConnection connection = new OleDbConnection(builder.ConnectionString))
            {
                connection.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + i_SheetName + "]", connection))
                {
                    adapter.Fill(dataTable);
                }
                connection.Close();
            }
        }

        private static void WriteDataTableToExcelWorksheet(DataTable dt, WorksheetPart worksheetPart)
        {
            SheetData firstChild = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            string s = "";
            int count = dt.Columns.Count;
            bool[] flagArray = new bool[count];
            string[] strArray = new string[count];
            for (int i = 0; i < count; i++)
            {
                strArray[i] = GetExcelColumnName(i);
            }
            uint num2 = 1;
            Row excelRow = new Row
            {
                RowIndex = num2
            };
            OpenXmlElement[] newChildren = new OpenXmlElement[] { excelRow };
            firstChild.Append(newChildren);
            for (int j = 0; j < count; j++)
            {
                DataColumn column = dt.Columns[j];
                AppendTextCell(strArray[j] + "1", column.ColumnName, excelRow);
                flagArray[j] = (column.DataType.FullName == "System.Decimal") || (column.DataType.FullName == "System.Int32");
            }
            double result = 0.0;
            foreach (DataRow row2 in dt.Rows)
            {
                num2++;
                Row row3 = new Row
                {
                    RowIndex = num2
                };
                OpenXmlElement[] elementArray2 = new OpenXmlElement[] { row3 };
                firstChild.Append(elementArray2);
                for (int k = 0; k < count; k++)
                {
                    s = row2.ItemArray[k].ToString();
                    if (flagArray[k])
                    {
                        result = 0.0;
                        if (double.TryParse(s, out result))
                        {
                            s = result.ToString();
                            AppendNumericCell(strArray[k] + num2.ToString(), s, row3);
                        }
                    }
                    else
                    {
                        AppendTextCell(strArray[k] + num2.ToString(), s, row3);
                    }
                }
            }
        }

        private static void WriteExcelFile(DataSet ds, SpreadsheetDocument spreadsheet)
        {
            spreadsheet.AddWorkbookPart();
            spreadsheet.WorkbookPart.Workbook = new Workbook();
            OpenXmlElement[] newChildren = new OpenXmlElement[1];
            OpenXmlElement[] childElements = new OpenXmlElement[] { new WorkbookView() };
            newChildren[0] = new BookViews(childElements);
            spreadsheet.WorkbookPart.Workbook.Append(newChildren);
            WorkbookStylesPart part = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>("rIdStyles");
            Stylesheet stylesheet = new Stylesheet();
            part.Stylesheet = stylesheet;
            uint num = 1;
            foreach (DataTable table in ds.Tables)
            {
                string str = "rId" + num.ToString();
                string tableName = table.TableName;
                WorksheetPart worksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                worksheetPart.Worksheet.AppendChild<SheetData>(new SheetData());
                WriteDataTableToExcelWorksheet(table, worksheetPart);
                worksheetPart.Worksheet.Save();
                if (num == 1)
                {
                    spreadsheet.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                }
                Sheet newChild = new Sheet
                {
                    Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = num,
                    Name = table.TableName
                };
                spreadsheet.WorkbookPart.Workbook.GetFirstChild<Sheets>().AppendChild<Sheet>(newChild);
                num++;
            }
            spreadsheet.WorkbookPart.Workbook.Save();
        }
    }

}
