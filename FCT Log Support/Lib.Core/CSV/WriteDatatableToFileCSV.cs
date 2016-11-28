using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Lib.Core.Helpers;

namespace Lib.Core
{
    public class WriteDatatableToFileCSV
    {
        // Methods
        private static string QuoteValue(string value)
        {
            return ("\"" + value.Replace("\"", "\"\"") + "\"");
        }

        public static CsvFileReader ReadFile(string filename)
        {
            return new CsvFileReader(filename, EmptyLineBehavior.NoColumns);
        }

        public static DataTable ReadToDataTable(string i_Path)
        {
            char[] chArray3;
            DataTable table = new DataTable();
            string currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory.Remove(currentDirectory.Length - 9);
            string str3 = File.ReadAllText(Path.GetFullPath(i_Path));
            DataTable table2 = new DataTable();
            DataColumn[] columns = new DataColumn[] { new DataColumn("Id", typeof(int)), new DataColumn("A", typeof(string)), new DataColumn("B", typeof(string)), new DataColumn("C", typeof(string)) };
            table2.Columns.AddRange(columns);
            int index = 1;
            Label_014F:
            chArray3 = new char[] { '\n' };
            if (index < str3.Split(chArray3).Length)
            {
                char[] separator = new char[] { '\n' };
                string str4 = str3.Split(separator)[index];
                if (!string.IsNullOrEmpty(str4))
                {
                    table2.Rows.Add(new object[0]);
                    int num2 = 0;
                    char[] chArray2 = new char[] { '\t' };
                    foreach (string str5 in str4.Split(chArray2))
                    {
                        table2.Rows[table2.Rows.Count - 1][num2] = str5.Trim();
                        num2++;
                    }
                }
                index++;
                goto Label_014F;
            }
            return table;
        }

        public static void WriteDataTable(DataTable sourceTable, TextWriter writer, bool includeHeaders)
        {
            if (includeHeaders)
            {
                IEnumerable<string> enumerable2 = from column in sourceTable.Columns.OfType<DataColumn>() select column.ColumnName;
                writer.WriteLine(string.Join(",", enumerable2));
            }
            IEnumerable<string> values = null;
            foreach (DataRow row in sourceTable.Rows)
            {
                values = from o in row.ItemArray select o.ToString();
                writer.WriteLine(string.Join(",", values));
            }
            writer.Flush();
        }
    }
}
