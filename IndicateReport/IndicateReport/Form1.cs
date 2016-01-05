using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace IndicateReport
{
    public partial class Form1 : Form
    {
        //const string FilePathWip22 = @"\\wip22\SHARE_MASTER\";
        //const string FilePathWip21 = @"\\wip21\SHARE_MASTER\";
        //const string FilePathWip23 = @"\\wip23\SHARE_MASTER\";
        const string FilePathWip22 = @"C:\Share\2\";
        const string FilePathWip21 = @"C:\Share\1\";
        const string FilePathWip23 = @"C:\Share\3\";
        public Form1()
        {
            InitializeComponent();
            ReaderFileWip22();
            ReaderFileWip23();
            ReaderFileWip21();
        }

        private void timerRunAuto_Tick(object sender, EventArgs e)
        {
            //ResetControlWip22();
            ReaderFileWip22();
            ReaderFileWip23();
            ReaderFileWip21();
        }

        public void CreateFileWatcher(string path)
        {
            // Create a new FileSystemWatcher and set its properties.
            var watcher = new FileSystemWatcher
            {
                Path = path,
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                               | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.txt"
            };
            /* Watch for changes in LastAccess and LastWrite times, and 
               the renaming of files or directories. */
            // Only watch text files.

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }
        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            ReaderFileWip22();
            ReaderFileWip23();
            ReaderFileWip21();

        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {

            // Specify what is done when a file is renamed.
            ReaderFileWip22();
            ReaderFileWip23();
            ReaderFileWip21();
        }

        /// <summary>
        /// WIP21
        /// </summary>
        private void ReaderFileWip21()
        {
            const string fileName = FilePathWip21 + "INDICATE_REPORT.txt";
            if (File.Exists(fileName))
            {
                StreamReader streamReader = File.OpenText(fileName);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] strSpit = line.Split('|');
                    lblOperatorWip21.Text = @"Operator:" + strSpit[0];
                    lblProcessWip21.Text = strSpit[1];
                    string model = strSpit[2];
                    lblTotalWip21.Text = strSpit[3];
                    lblPassWip21.Text = strSpit[4];
                    int notgood = Convert.ToInt32(lblTotalWip21.Text) - Convert.ToInt32(lblPassWip21.Text);
                    lblNotGoodWip21.Text = Math.Abs(notgood).ToString(CultureInfo.InvariantCulture);

                    float ng = (float.Parse(lblNotGoodWip21.Text) / float.Parse(lblTotalWip21.Text)) * 100;

                    if (ng > 0)
                    {
                        lblTotalNGWip21.Text = string.Format("{0:0.0} %", Math.Round(ng, 3));
                    }
                }
                streamReader.Close();
            }
            //else
            //{
            //    MessageBox.Show("File not found!");
            //}
        }

        /// <summary>
        /// WIP 23
        /// </summary>
        private void ReaderFileWip23()
        {
            const string fileName = FilePathWip23 + "INDICATE_REPORT.txt";
            if (File.Exists(fileName))
            {
                StreamReader streamReader = File.OpenText(fileName);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] strSpit = line.Split('|');
                    lblOperatorWip23.Text = @"Operator:" + strSpit[0];
                    lblProcessWip23.Text = strSpit[1];
                    string model = strSpit[2];
                    lblTotalWip23.Text = strSpit[3];
                    lblPassWip23.Text = strSpit[4];
                    int notgood = Convert.ToInt32(lblTotalWip23.Text) - Convert.ToInt32(lblPassWip23.Text);
                    lblNotGoodWip23.Text = Math.Abs(notgood).ToString(CultureInfo.InvariantCulture);

                    float ng = (float.Parse(lblNotGoodWip23.Text) / float.Parse(lblTotalWip23.Text)) * 100;

                    if (ng > 0)
                    {
                        lblTotalNGWip23.Text = string.Format("{0:0.0} %", Math.Round(ng, 3));
                    }
                }
                streamReader.Close();
            }
            //else
            //{
            //    MessageBox.Show("File not found!");
            //}
        }

        /// <summary>
        /// WIP 22
        /// </summary>

        List<ItemData> items = new List<ItemData>();
        private void ReaderFileWip22()
        {
            const string fileName = FilePathWip22 + "INDICATE_REPORT.txt";
            const string writerFile = @"C:\SHARE_MASTER\INDICATE_REPORT.txt";
            if (File.Exists(fileName))
            {
                var streamReader = new StreamReader(fileName);
                //File.OpenText(fileName);
                string strOperator = null;
                string strProcess = null;
                string strPass = null;
                string strTotal = null;
                string actual = null;
                int notgood = 0;
                string line;
                string strWriter = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] strSpit = line.Split('|');

                    strOperator = @"Operator:" + strSpit[0];
                    strProcess = strSpit[1];
                    string model = strSpit[2];
                    strTotal = strSpit[3];
                    strPass = strSpit[4];
                    actual = strSpit[4];
                    strWriter = string.Format("{0}|{1}", strOperator, strProcess);
                    using (var fs = new FileStream(writerFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (var streamWriter = new StreamWriter(fs))
                        {
                            streamWriter.WriteLine(strWriter);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                    }
                }

                lblOperatorWip22.Text = strOperator;
                lblProcessWip22.Text = strProcess;
                lblTotalWip22.Text = strTotal;
                lblPassWip22.Text = strPass;
                lblActual.Text = actual;

                notgood = Convert.ToInt32(strTotal) - Convert.ToInt32(strPass);
                lblNotGoodWip22.Text = Math.Abs(notgood).ToString(CultureInfo.InvariantCulture);
                int value = Convert.ToInt32(strPass);
                if (value >= 900)
                {
                    progressBar1.Value = 900;
                    lblBalenced.ForeColor = Color.Green;
                    labelBalenced.ForeColor = Color.Green;
                }
                else
                {
                    progressBar1.Value = value;
                    lblBalenced.ForeColor = Color.Red;
                    labelBalenced.ForeColor = Color.Red;
                }

                int setplan = Convert.ToInt32(lblSetPlan.Text);
                int pass = Convert.ToInt32(strPass);
                int balenced = setplan - pass;
                
                if (pass > setplan)
                {
                    lblBalenced.Text = Math.Abs(balenced).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    lblBalenced.Text = @"- " + balenced.ToString(CultureInfo.InvariantCulture);
                }

                float ng = (float.Parse(lblNotGoodWip22.Text) / float.Parse(strTotal)) * 100;
                if (ng > 0)
                {
                    lblTotalNGWip22.Text = string.Format("{0:0.0} %", Math.Round(ng, 3));
                }
                streamReader.Close();
                streamReader.Dispose();
                
            }
        }
    }

    public class ItemData
    {
        public string CodeOper { get; set; }

        public string Process { get; set; }

        public string Model { get; set; }

        public string Total { get; set; }

        public string Pass { get; set; }

    }
}
