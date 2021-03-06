﻿using EducationSkills.Data;
using EducationSkills.Subjects;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills.Modules
{
    public partial class UserControlSubjects : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlSubjects()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormAddSubject("").ShowDialog();
            LoadSubjects();
        }

        private void btlRefesh_Click(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void UserControlSubjects_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void LoadSubjects()
        {
            splashScreenManager1.ShowWaitForm();
            context = new EducationSkillsDbContext();
            string type = "Đào tạo toàn công ty";
            object[] param =
            {
                new SqlParameter() { ParameterName = "@type", Value = type, SqlDbType = SqlDbType.NVarChar},
                new SqlParameter() { ParameterName = "@dept", Value = DBNull.Value, SqlDbType = SqlDbType.NVarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            try
            {
                var subjects = context.Database.SqlQuery<PR_Bomon>("EXEC [dbo].[ShowBoMon] @type, @dept", param).ToList();

                gridControl1.DataSource = subjects;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
            }


            splashScreenManager1.CloseWaitForm();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks >= 1)
            {
                string subjectId = (string)gridView1.GetRowCellValue(e.RowHandle, "MaBoMon");
                new FormAddSubject(subjectId).ShowDialog();
                LoadSubjects();
            }
        }
    }
}
