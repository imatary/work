using CsvHelper;
using EducationSkills.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class Certificates : Form
    {
        public Certificates()
        {
            InitializeComponent();
        }

        private void Certificates_Load(object sender, EventArgs e)
        {
            GetCertificates();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetCertificates()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Data\Certificates.csv";
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                ConfigureCsvReader(csv);
                var models = csv.GetRecords<Certificate>().OrderBy(i => i.ValueMember);
                
                gridControl1.DataSource = models.ToList();
            }
        }

        /// <summary>
        /// Cấu hình CSV Helper
        /// </summary>
        /// <param name="csvReader"></param>
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                List<Certificate> lists = new List<Certificate>();
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\Data\Certificates.csv";
                using (var stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader))
                {
                    ConfigureCsvReader(csv);
                    var model = new Certificate()
                    {
                        ValueMember = txtValue.Text,
                        DisplayMember = txtValue.Text
                    };
                    lists.Add(model);
                    bool datontai = false;
                    var models = csv.GetRecords<Certificate>().OrderBy(i => i.ValueMember).ToList();
                    foreach (var item in models)
                    {
                        if (item.ValueMember == model.ValueMember)
                        {
                            MessageBox.Show("Đã có rồi. Vui lòng kiểm tra lại!");
                            datontai = true;
                            break;
                        }
                    }
                    if (datontai == false)
                    {
                        using (TextWriter writer = new StreamWriter(stream))
                        {
                            foreach (var item in lists)
                            {
                                var csvWriter = new CsvWriter(writer);
                                csvWriter.WriteRecord(item);
                            }
                            MessageBox.Show("Insert success!");
                        }
                    }
                }

                GetCertificates();
                txtValue.ResetText();
            }
            else
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập vào đầy đủ thông tin!");
                return;
            }

        }
    }
}
