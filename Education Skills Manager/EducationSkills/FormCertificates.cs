using EducationSkills.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class Certificates : Form
    {
        private EducationSkillsDbContext context;
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
            context = new EducationSkillsDbContext();
            var certificates = context.EDU_Certificates.ToList();
            gridControl1.DataSource = certificates;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                var item = new EDU_Certificates
                {
                    DisplayMember = txtValue.Text
                };

                context = new EducationSkillsDbContext();
                try
                {
                    context.EDU_Certificates.Add(item);
                    context.SaveChanges();

                    GetCertificates();
                    txtValue.ResetText();
                }
                catch (Exception ex)
                {
                    MessageHelper.ErrorMessageBox(ex.Message);
                }

                
            }
            else
            {
                MessageHelper.ErrorMessageBox("Vui lòng nhập vào đầy đủ thông tin!");
                return;
            }

        }
    }
}
