using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PrintLabel.App
{
    public static class Ultils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void Write(string path, string content)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write)) { 
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(content);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="line_del"></param>
        public static void RemoveLine(string path, string line_del)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != line_del)
                        sw.WriteLine(line);
                }
            }
            File.Delete(path);
            File.Move(tempFile, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public static void CreateFolder(string path, string fileName)
        {
            bool exists = Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
                string fullPath = $@"{path}\{fileName}.txt";
                if (!File.Exists(fileName))
                    File.Create(fullPath).Dispose();
            }
            else
            {
                string fullPath = $@"{path}\{fileName}.txt";
                if (!File.Exists(fileName))
                    File.Create(fullPath).Dispose();
            }
        }

        public static List<string> ReadAllLines(string path, Encoding encoding)
        {
            List<string> lines = new List<string>();
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lines.Add(line);
                }
                reader.Close();
                
            }
            return lines;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="newline"></param>
        /// <returns></returns>
        public static string ReadLastLine(string path, Encoding encoding, string newline)
        {
            string line = null;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (reader.Peek() == -1)
                    {
                        return line;
                    }
                }
                reader.Close();
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int CountLine(string path)
        {
            int count = 0;
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(file))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
                reader.Close();
                return count;
            }
        }
        public static string GetLine(string path, int line)
        {
            string value;
            using (var sr = new StreamReader(path))
            {
                for (int i = 1; i < line; i++)
                {
                    sr.ReadLine();
                }
                value = sr.ReadLine();
                sr.Dispose();
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridIn"></param>
        /// <param name="outputFile"></param>
        public static void WriteCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile, true, Encoding.ASCII);

                ////write header rows to csv
                //for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                //{
                //    if (i > 0)
                //    {
                //        swOut.Write(",");
                //    }
                //    swOut.Write(gridIn.Columns[i].HeaderText);
                //}

                //swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");
                        swOut.Write(value);
                    } 
                }
                swOut.WriteLine();
                swOut.Close();
            }
        }

        public static void WriteAppendCSV(DataGridView gridIn, bool append, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                // FileMode.Create => ghi đè
                // FileMode.Append => ghi tiếp dòng tiếp theo
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (StreamWriter swOut = new StreamWriter(fs))
                {
                    //write DataGridView rows to csv
                    for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                    {
                        if (j > 0)
                        {
                            swOut.WriteLine();
                        }

                        dr = gridIn.Rows[j];

                        for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                swOut.Write(",");
                            }

                            value = dr.Cells[i].Value.ToString();
                            //replace comma's with spaces
                            value = value.Replace(',', ' ');
                            //replace embedded newlines with spaces
                            value = value.Replace(Environment.NewLine, " ");
                            swOut.Write(value);
                        }
                    }
                    swOut.WriteLine();
                    swOut.Close();
                }
            }
        }
        public static void WriteTxtFromDataGridView(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile, false, Encoding.ASCII);
                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }
                    dr = gridIn.Rows[j];
                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");
                        swOut.Write(value);
                    }
                }
                swOut.WriteLine();
                swOut.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string rootKey, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{rootKey}");
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                key.SetValue(keyName, content);
                key.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistryArray(string rootKey,string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{rootKey}");
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                string exitsValue = GetValueRegistryKey(rootKey,keyName);
                if (exitsValue != null)
                {
                    exitsValue += content + ";";
                    key.SetValue(keyName, exitsValue);
                }
                else
                {
                    key.SetValue(keyName, content + ";");
                }
                key.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueRegistryKey(string rootKey, string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{rootKey}");
            string value = null;
            if (key != null)
            {
                if (key.GetValue(keyName) != null)
                {
                    value = key.GetValue(keyName).ToString();
                    key.Close();
                    return value;
                }
            }

            return null;
        }
    }
}
