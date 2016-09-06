using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Lib.Core.Helpers;
using Lib.Form.Controls;
using Microsoft.Win32;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace CreateLogFromFileCSV
{
    public partial class FormMain : Form
    {
        private StringBuilder m_Sb;
        private bool m_bDirty;
        private FileSystemWatcher m_Watcher;
        private bool m_bIsWatching;
        private string fileName = null;
        private string modelId = null;
        private string productionId = null;
        private string status = null;
        int count = 1;
        public FormMain()
        {
            InitializeComponent();
            m_Sb = new StringBuilder();
            m_bDirty = false;
            m_bIsWatching = false;
            lblCurentVersion.Text = StringHelper.GetRunningVersion();
            RegisterInStartup(true);
        }

        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            bool isVaild = true;
            if (string.IsNullOrEmpty(txtCurentProcessID.Text))
            {
                ValidationTextBox.CheckNullValue(txtCurentProcessID);
                errorProvider1.SetError(txtCurentProcessID, "Please input a curent process!");
                isVaild = false;
            }
            else if(string.IsNullOrEmpty(txtFile.Text))
            {
                ValidationTextBox.CheckNullValue(txtFile);
                errorProvider1.SetError(btnBrowseFile, "Please select a File or Directory!");
                isVaild = false;
            }
            else if (isVaild)
            {
                if (m_bIsWatching)
                {
                    m_bIsWatching = false;
                    m_Watcher.EnableRaisingEvents = false;
                    m_Watcher.Dispose();
                    btnWatchFile.BackColor = Color.LightSkyBlue;
                    btnWatchFile.Text = "Start Watching";
                    EnableControls(true);
                }
                else
                {
                    m_bIsWatching = true;
                    btnWatchFile.BackColor = Color.Red;
                    btnWatchFile.ForeColor = Color.White;
                    btnWatchFile.Font = new Font(btnWatchFile.Font, FontStyle.Bold);

                    btnWatchFile.Text = "Stop Watching";
                    EnableControls(false);
                    m_Watcher = new FileSystemWatcher();
                    if (rdbDir.Checked)
                    {
                        m_Watcher.Filter = "*.csv";
                        m_Watcher.Path = txtFile.Text + "\\";
                    }
                    else
                    {
                        m_Watcher.Filter = txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);
                        m_Watcher.Path = txtFile.Text.Substring(0, txtFile.Text.Length - m_Watcher.Filter.Length);
                    }

                    if (chkSubFolder.Checked)
                    {
                        m_Watcher.IncludeSubdirectories = true;
                    }

                    m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    m_Watcher.Created += new FileSystemEventHandler(OnChanged);
                    m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                    //m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
                    m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                    m_Watcher.EnableRaisingEvents = true;
                }
                SaveRegistry();
            } 
        }
        
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!m_bDirty)
            {
                fileName = Path.GetFileNameWithoutExtension(e.FullPath);
                //ReadFileCsv(e.FullPath);
                if (e.ChangeType == WatcherChangeTypes.Created)
                {
                    var data = ReadCsv(e.FullPath);
                    foreach (var item in data)
                    {
                        
                    }
                    MessageBox.Show("Complete");
                }
                else if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    var data = ReadCsv(e.FullPath);
                    foreach (var item in data)
                    {

                    }
                    MessageBox.Show("Complete");
                }
                //CreateFileLog(modelId, $"{productionId}_{modelId}", status, txtCurentProcessID.Text.Trim());

                m_bDirty = true;
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!m_bDirty)
            {
                m_Sb.Remove(0, m_Sb.Length);
                m_Sb.Append(e.OldFullPath);
                m_Sb.Append(" - ");
                m_Sb.Append(e.ChangeType.ToString());
                m_Sb.Append(" - ");
                m_Sb.Append("to ");
                m_Sb.Append(e.Name);
                m_Sb.Append(" -   ");
                m_Sb.Append(DateTime.Now.ToString());
                m_bDirty = true;
                if (rdbFile.Checked)
                {
                    m_Watcher.Filter = e.Name;
                    m_Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - m_Watcher.Filter.Length);
                }
            }            
        }

        
        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (m_bDirty)
            {
                ListViewItem listItems = new ListViewItem((count++).ToString());
                listView1.BeginUpdate();
                listItems.SubItems.Add($"{productionId}_{modelId}");
                listItems.SubItems.Add(modelId);
                listItems.SubItems.Add(DateTime.Now.ToLongDateString());
                listItems.SubItems.Add(DateTime.Now.ToLongTimeString());
                listItems.SubItems.Add(status);

                listView1.Items.Add(listItems);
                listView1.EndUpdate();
                m_bDirty = false;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (rdbDir.Checked)
            {
                DialogResult resDialog = dlgOpenDir.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenDir.SelectedPath;
                }
            }
            else
            {
                DialogResult resDialog = dlgOpenFile.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenFile.FileName;
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = dlgSaveFile.ShowDialog();
            if (resDialog.ToString() == "OK")
            {
                FileInfo fi = new FileInfo(dlgSaveFile.FileName);
                StreamWriter sw = fi.CreateText();
                foreach (string sItem in listView1.Items)
                {
                    sw.WriteLine(sItem);
                }
                sw.Close();
            }
        }

        private void rdbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFile.Checked == true)
            {
                chkSubFolder.Enabled = false;
                chkSubFolder.Checked = false;
            }
        }

        private void rdbDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDir.Checked == true)
            {
                chkSubFolder.Enabled = true;
                chkSubFolder.Checked = true;
            }
        }

        /// <summary>
        /// Create Log
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        private static void CreateFileLog(string modelId, string productionId, string status, string process)
        {
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{productionId}.txt";
            string folderRoot = @"C:\LOGPROCESS\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
        }


        private IEnumerable<string[]> ReadCsv(string path)
        {
            char[] separator = new[] { ',' };
            string currentLine;

            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream, Encoding.Default, true, 1024))
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        yield return currentLine.Split(separator, StringSplitOptions.None);
                    }
                    reader.Dispose();
                    reader.Close();
                }
                stream.Dispose();
                stream.Close();
            }
        }

        /// <summary>
        /// Read file Csv
        /// </summary>
        /// <param name="path"></param>
        private static void ReadFileCsv(string path)
        {
            //using (CsvFileReader reader = new CsvFileReader(path))
            //{
            //    CsvRow row = new CsvRow();
            //    while (reader.ReadRow(row))
            //    {
            //        //foreach (string s in row)
            //        //{
            //        //    MessageBox.Show(s);
            //        //}
            //        //Console.WriteLine();
            //        MessageBox.Show("Complete!");
            //    }
            //}
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {

            }
            //var lines = File.ReadAllLines(path).Select(a => a.Split(';'));
            //var csv = (from line in lines
            //           select (
            //                    from col in line
            //                    select col
            //                  ).ToArray() // skip the first column
            //          ).Skip(2).ToArray(); // skip 2 headlines

                //var coltitle = (from line in lines
                //                select line.Skip(1).ToArray() // skip 1st column
                //       ).Skip(1).FirstOrDefault().ToArray(); // take the 2nd row

                //var rowtitle = (from line in lines select line[0] // take 1st column
                //               ).Skip(2).ToArray(); // skip 2 headlines

                //var value = csv.First();

                //try
                //{
                //    if (!File.Exists(path))
                //    {
                //        MessageBox.Show("File Not Found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    var reader = new StreamReader(File.OpenRead(path));

                //    bool first = true;
                //    while (!reader.EndOfStream)
                //    {
                //        var line = reader.ReadLine();
                //        if (first)
                //        {
                //            first = false;
                //            continue;
                //        }
                //        var values = line.Split(',');
                //    }
                //    reader.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Exception:" + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

        }

        //void WriteTest()
        //{
        //    // Write sample data to CSV file
        //    using (CsvFileWriter writer = new CsvFileWriter("WriteTest.csv"))
        //    {
        //        for (int i = 0; i < 100; i++)
        //        {
        //            CsvRow row = new CsvRow();
        //            for (int j = 0; j < 5; j++)
        //                row.Add(String.Format("Column{0}", j));
        //            writer.WriteRow(row);
        //        }
        //    }
        //}

        //void ReadTest()
        //{
        //    // Read sample data from CSV file
        //    using (CsvFileReader reader = new CsvFileReader("ReadTest.csv"))
        //    {
        //        CsvRow row = new CsvRow();
        //        while (reader.ReadRow(row))
        //        {
        //            foreach (string s in row)
        //            {
        //                Console.Write(s);
        //                Console.Write(" ");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadRegistry();
        }

        private void txtCurentProcessID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCurentProcessID.Text))
            {
                errorProvider1.Clear();
            }
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFile.Text))
            {
                errorProvider1.Clear();
            }
        }

        private void SaveRegistry()
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Creation Log from File CSV\ProcessValue", "ProcessName", txtCurentProcessID.Text);
        }

        private void LoadRegistry()
        {
            txtCurentProcessID.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Creation Log from File CSV\ProcessValue", "ProcessName", null);
        }

        private void EnableControls(bool enable)
        {
            rdbFile.Enabled = enable;
            rdbDir.Enabled = enable;
            chkSubFolder.Enabled = enable;
            txtCurentProcessID.Enabled = enable;
            txtFile.Enabled = enable;
            btnBrowseFile.Enabled = enable;
        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }
    }
}