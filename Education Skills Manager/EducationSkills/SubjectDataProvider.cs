using EducationSkills.Data;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace EducationSkills
{
    public static class SubjectDataProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private static EducationSkillsDbContext Context
        {
            get
            {
                return new EducationSkillsDbContext();
            }
        }

        

        //try
        //{
        //    context.Database.ExecuteSqlCommand("EXEC [dbo].[InsertBoMon] @MaBoMon, @TenBoMon", param);

        //    MessageHelper.SuccessMessageBox("Thêm thành công!");
        //    this.Dispose();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PR_Bomon GetSubjectById(string id)
        {
            return Context.PR_Bomon.SingleOrDefault(s => s.MaBoMon == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public static void InsertSubject(string id, string name)
        {
            var subject = new PR_Bomon()
            {
                MaBoMon = id,
                TenBoMon = name,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
            };
            try
            {
                using (var context = new EducationSkillsDbContext())
                {
                    context.PR_Bomon.Add(subject);
                    context.SaveChanges();
                }     
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public static void UpdateSubject(string id, string name)
        {
            var subject = GetSubjectById(id);
            if (subject != null)
            {
                subject.TenBoMon = name;
                try
                {
                    using (var context = new EducationSkillsDbContext())
                    {
                        context.PR_Bomon.Attach(subject);
                        context.Entry(subject).State = EntityState.Modified;
                        context.SaveChanges();
                    }                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteSubjectById(string id)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@MaBoMon", Value = id, SqlDbType = SqlDbType.NChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                Context.Database.ExecuteSqlCommand("EXEC [dbo].[DeleteBoMon] @MaBoMon", param);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
