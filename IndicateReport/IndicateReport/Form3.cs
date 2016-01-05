using System;
using System.IO;
using System.Windows.Forms;

namespace IndicateReport
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string filePath = "\\umc-c357\\New folder\\INDICATE_REPORT.txt";
        private void Form3_Load(object sender, EventArgs e)
        {
            bool isFileInUse = FileInUse(filePath);

            // Then you can do some checking
            if (isFileInUse)
                MessageBox.Show("File is in use");
            else
                MessageBox.Show("File is not in use");
        }

        //public bool IsFileInUse(string path)
        //{
        //    if (string.IsNullOrEmpty(path))
        //        throw new ArgumentException("'path' cannot be null or empty.", "path");

        //    try
        //    {
        //        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        //        {
                    
        //        }
        //    }
        //    catch (IOException)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //protected virtual bool IsFileinUse(FileInfo file)
        //{
        //    FileStream stream = null;

        //    try
        //    {
        //        stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        //    }
        //    catch (IOException)
        //    {
        //        //the file is unavailable because it is:
        //        //still being written to
        //        //or being processed by another thread
        //        //or does not exist (has already been processed)
        //        return true;
        //    }
        //    finally
        //    {
        //        if (stream != null)
        //            stream.Close();
        //    }
        //    return false;
        //}


        public bool FileInUse(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    bool canRead = fs.CanRead;
                    bool canSeek = fs.CanSeek;
                }

                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isFileInUse = FileInUse(filePath);

            // Then you can do some checking
            if (isFileInUse)
                MessageBox.Show("File is in use");
            else
                MessageBox.Show("File is not in use");
        }

    }
}
