using CsvHelper;
using EducationSkills.Data;
using EducationSkills.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class FormImports : Form
    {
        private EducationSkillsDbContext context;
        List<string> items = new List<string>();
        public FormImports(List<string> staffCodes)
        {
            InitializeComponent();
           
            items = staffCodes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            context = new EducationSkillsDbContext();

            if(checkEditEye.Checked==false && checkEditSolder.Checked == false)
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập đầy đủ thông tin!");
            }
            else if (string.IsNullOrEmpty(txtCertificate.Text))
            {
                MessageHelper.ErrorMessageBox("Vui lòng chọn một chứng chỉ!");
            }
            else if (string.IsNullOrEmpty(dateEditTestDate.Text) || string.IsNullOrEmpty(dateEditDateConfirmed.Text))
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                foreach (var item in items)
                {
                    // Hàn = check
                    // Mắt = no check
                    if (checkEditSolder.CheckState == CheckState.Checked && checkEditEye.CheckState == CheckState.Unchecked)
                    {
                        InsertSolder(item, txtCertificate.EditValue.ToString(), (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);
                    }
                    // Hàn = no check
                    // Mắt = check
                    else if (checkEditSolder.CheckState == CheckState.Unchecked && checkEditEye.CheckState == CheckState.Checked)
                    {
                        InsertEye(item, txtCertificate.EditValue.ToString(), (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);
                    }
                    // Cả hai cùng Check
                    else if (checkEditSolder.CheckState == CheckState.Checked && checkEditEye.CheckState == CheckState.Checked)
                    {
                        // Hàn
                        InsertSolder(item, txtCertificate.EditValue.ToString(), (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);

                        // Mắt
                        InsertEye(item, txtCertificate.EditValue.ToString(), (DateTime)dateEditTestDate.EditValue, (DateTime)dateEditDateConfirmed.EditValue, 1);

                    }
                }

                MessageHelper.SuccessMessageBox("Lưu thành công!");
                this.Close();
            }
        }

        private void checkEditEye_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormImports_Load(object sender, EventArgs e)
        {
            dateEditDateConfirmed.DateTime = DateTime.Now;
            dateEditTestDate.DateTime = DateTime.Now;
            GetCertificates();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="level"></param>
        /// <param name="testDate"></param>
        /// <param name="dateConfirmed"></param>
        /// <param name="solanthi"></param>
        private void InsertEye(string staffCode, string level, DateTime testDate, DateTime dateConfirmed, int solanthi)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@CapDo", Value = level, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@NgayCap", Value = testDate, SqlDbType = SqlDbType.DateTime },
                new SqlParameter() { ParameterName = "@NgayThiXacNhan", Value = dateConfirmed, SqlDbType = SqlDbType.DateTime },
                new SqlParameter() { ParameterName = "@Solanthi", Value = solanthi, SqlDbType = SqlDbType.Int },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                context.Database.ExecuteSqlCommand("EXEC [dbo].[InSertKTMat] @StaffCode, @CapDo, @NgayCap, @NgayThiXacNhan, @Solanthi", param);
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="level"></param>
        /// <param name="testDate"></param>
        /// <param name="dateConfirmed"></param>
        /// <param name="solanthi"></param>
        private void InsertSolder(string staffCode, string level, DateTime testDate, DateTime dateConfirmed, int solanthi)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@CapDoHan", Value = level, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@NgayCap", Value = testDate, SqlDbType = SqlDbType.DateTime },
                new SqlParameter() { ParameterName = "@NgayThiXacNhan", Value = dateConfirmed, SqlDbType = SqlDbType.DateTime },
                new SqlParameter() { ParameterName = "@Solanthi", Value = solanthi, SqlDbType = SqlDbType.Int },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                context.Database.ExecuteSqlCommand("EXEC [dbo].[InsertKTHan] @StaffCode, @CapDoHan, @NgayCap, @NgayThiXacNhan, @Solanthi", param);
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
                return;
            }
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
                txtCertificate.Properties.DisplayMember = "DisplayMember";
                txtCertificate.Properties.ValueMember = "ValueMember";
                txtCertificate.Properties.DataSource = models.ToList();
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

        private void txtCertificate_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                new Certificates().ShowDialog();
                GetCertificates();
            }
        }
    }
}
