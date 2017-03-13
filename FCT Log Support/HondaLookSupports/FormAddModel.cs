using CsvHelper;
using Lib.Form.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HondaLookSupports
{
    public partial class FormAddModel : Form
    {
        public FormAddModel()
        {
            InitializeComponent();
            GetModels();
            txtModelName.Focus();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtModelName))
            {
                CheckTextBoxNullValue.ValidationTextEditNullValueWidthErrorProvider(dxErrorProvider1, txtModelName, "Nhập vào tên Model!");
            }
            else
            {
                List<Model> lists = new List<Model>();
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\Data\HondaLookModel.csv";
                using (var stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader))
                {
                    ConfigureCsvReader(csv);
                    var myClassMap = new MyClassMap();
                    csv.Configuration.RegisterClassMap(myClassMap);
                    var model = new Model()
                    {
                        ModelCode = txtModelCode.Text,
                        ModelName = txtModelName.Text
                    };
                    lists.Add(model);
                    bool datontai = false;
                    var models = csv.GetRecords<Model>().OrderBy(i => i.ModelCode).ToList();
                    foreach (var item in models)
                    {
                        if (item.ModelCode == model.ModelCode)
                        {
                            MessageBox.Show("Model đã có rồi!");
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
                GetModels();
                txtModelName.ResetText();
                txtModelName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetModels()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Data\HondaLookModel.csv";
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                ConfigureCsvReader(csv);
                var myClassMap = new MyClassMap();
                csv.Configuration.RegisterClassMap(myClassMap);

                var models = csv.GetRecords<Model>().OrderBy(i => i.ModelCode);
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

        private void txtModelName_EditValueChanged(object sender, EventArgs e)
        {
            txtModelCode.Text = txtModelName.Text;

            if (!string.IsNullOrEmpty(txtModelName.Text))
            {
                CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtModelName);
            }
        }
    }
}
