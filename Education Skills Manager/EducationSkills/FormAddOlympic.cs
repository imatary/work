using EducationSkills.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EducationSkills.Models;
using System.Data.Entity;

namespace EducationSkills
{
    public partial class FormAddOlympic : Form
    {
        private EducationSkillsDbContext context;
        public FormAddOlympic()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        private void LoadData(string staffCode)
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();

            SqlParameter parmstaffCode = new SqlParameter() { ParameterName = "@staffCode", SqlDbType = SqlDbType.VarChar };
            if (staffCode == null)
            {
                parmstaffCode.Value = DBNull.Value;
            }
            else
            {
                parmstaffCode.Value = staffCode;
            }
            try
            {
                var employees = context.Database.SqlQuery<Employees>("EXEC [dbo].[sp_GetStaffByCode] @staffCode", parmstaffCode).SingleOrDefault();
                if (employees != null)
                {
                    lblCode.Text = employees.StaffCode;
                    lblFullName.Text = employees.FullName;
                    lblBirthDate.Text = string.Format("{0:dd-MM-yyyy}", employees.BirthDate);
                    lblSex.Text = employees.Sex;
                    lblDeptCode.Text = employees.DeptCode;
                    lblEntryDate.Text = string.Format("{0:MM/dd/yyyy}", employees.EntryDate);
                    lblPosName.Text = employees.PosName;

                    var olympic = context.EDU_Olympics.SingleOrDefault(m => m.StaffCode == staffCode);
                    if (olympic != null)
                    {
                        txtTestContent.EditValue = olympic.TestContent;
                        txtTestNumber.Text = olympic.TestNumber.ToString();
                        txtTestDate.DateTime = olympic.TestDate;
                        txtTestResults.EditValue = olympic.TestResults;
                    }
                    else
                    {
                        txtTestContent.EditValue = null;
                        txtTestContent.ResetText();
                        txtTestNumber.ResetText();
                        txtTestDate.ResetText();
                        txtTestResults.EditValue = null;
                        txtTestResults.ResetText();
                    }

                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.CloseWaitForm();
                    MessageHelper.ErrorMessageBox($"Không tìm thấy nhân viên với code: [{staffCode}]. Vui lòng kiểm tra lại!");
                }
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                MessageHelper.ErrorMessageBox(ex.Message);
            }


        }
        /// <summary>
        /// 
        /// </summary>
        private void ResetTextControls()
        {
            lblCode.Text = "[N/A]";
            lblFullName.Text = "[N/A]";
            lblBirthDate.Text = "[N/A]";
            lblSex.Text = "[N/A]";
            lblDeptCode.Text = "[N/A]";
            lblEntryDate.Text = "[N/A]";
            lblPosName.Text = "[N/A]";


            txtTestContent.EditValue = null;
            txtTestContent.ResetText();

            txtTestNumber.ResetText();
            txtTestDate.ResetText();

            txtTestResults.EditValue = null;
            txtTestResults.ResetText();

            txtSearchKey.ResetText();
            txtSearchKey.Focus();
        }
        private void FormAddOlympic_Load(object sender, EventArgs e)
        {
            //txtTestDate.DateTime = DateTime.Now;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(lblCode.Text == @"[N/A]")
            {
                MessageHelper.ErrorMessageBox("Vui lòng chọn một nhân viên!");
                txtSearchKey.SelectAll();
                txtSearchKey.Focus();
            }
            else
            {
                var olympic = context.EDU_Olympics.SingleOrDefault(m => m.StaffCode == lblCode.Text);
                if(olympic == null)
                {
                    var addOlympic = new EDU_Olympics()
                    {
                        StaffCode = lblCode.Text,
                        TestContent = txtTestContent.Text,
                        TestNumber = int.Parse(txtTestNumber.EditValue.ToString()),
                        TestResults = txtTestResults.Text,
                        TestDate = txtTestDate.DateTime
                    };

                    try
                    {
                        context.EDU_Olympics.Add(addOlympic);
                        context.SaveChanges();
                        MessageHelper.SuccessMessageBox("Lưu thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ErrorMessageBox(ex.Message);
                    }
                }
                else
                {
                    olympic.TestContent = txtTestContent.Text;
                    olympic.TestNumber = int.Parse(txtTestNumber.Text);
                    olympic.TestDate = txtTestDate.DateTime;
                    olympic.TestResults = txtTestResults.Text;

                    try
                    {
                        using (var context = new EducationSkillsDbContext())
                        {
                            context.EDU_Olympics.Attach(olympic);
                            context.Entry(olympic).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        MessageHelper.SuccessMessageBox("Lưu thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ErrorMessageBox(ex.Message);
                    }
                    
                }
                ResetTextControls();
            }
            
        }

        private void txtSearchKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string staffCode = txtSearchKey.Text;
                if (Ultils.IsNull(staffCode))
                {
                    LoadData(staffCode);
                    txtTestContent.Focus();
                }
            }
        }

        private void txtSearchKey_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                string staffCode = txtSearchKey.Text;
                if (Ultils.IsNull(staffCode))
                {
                    LoadData(staffCode);
                    txtTestContent.Focus();
                }
            }
        }
    }
}
