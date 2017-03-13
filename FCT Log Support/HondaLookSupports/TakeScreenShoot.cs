using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HondaLookSupports
{
    public partial class TakeScreenShoot : Form
    {
        public TakeScreenShoot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\cuong\Desktop\Record\LOG_20170211.csv";
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                ConfigureCsvReader(csv);
                var myClassMap = new MyClassMap();
                csv.Configuration.RegisterClassMap(myClassMap);

                var testProg = csv.GetRecords<MyClass>().Last(i => i.ColA == "TestProg");
                if (testProg.ColE == "Pass")
                {
                    var subProg = csv.GetRecords<MyClass>().Last(i => i.ColA == "SubProg" && i.ColC == "Cmd");
                    if (subProg.ColF == "Pass")
                    {
                        MessageBox.Show("PASS SubProg");
                    }
                    else if (testProg.ColE == "Fail")
                    {
                        MessageBox.Show("Fail SubProg");
                    }
                }
                else if (testProg.ColE == "Fail")
                {
                    MessageBox.Show("Fail TestProg");
                }
            }
        }

        internal static void ConfigureCsvReader(CsvReader csvReader)
        {
            csvReader.Configuration.AllowComments = false;
            csvReader.Configuration.CountBytes = false;
            csvReader.Configuration.CultureInfo = CultureInfo.CurrentCulture;
            csvReader.Configuration.Delimiter = ",";
            csvReader.Configuration.DetectColumnCountChanges = true;
            csvReader.Configuration.Encoding = Encoding.UTF8;
            csvReader.Configuration.HasExcelSeparator = false;
            csvReader.Configuration.HasHeaderRecord = true;
            csvReader.Configuration.IgnoreBlankLines = true;
            csvReader.Configuration.IgnoreHeaderWhiteSpace = false;
            csvReader.Configuration.IgnorePrivateAccessor = true;
            csvReader.Configuration.IgnoreQuotes = false;
            csvReader.Configuration.IgnoreReadingExceptions = false;
            csvReader.Configuration.IgnoreReferences = true;
            csvReader.Configuration.IsHeaderCaseSensitive = true;
            csvReader.Configuration.SkipEmptyRecords = false;
            csvReader.Configuration.ThrowOnBadData = true;
            csvReader.Configuration.TrimFields = false;
            csvReader.Configuration.TrimHeaders = false;
            csvReader.Configuration.WillThrowOnMissingField = true;
        }
    }
}
