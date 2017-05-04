using EducationSkills.Data;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace EducationSkills
{
    public static class EducationSkillDataProviders
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

        #region Kiểm tra hàn
        public static PR_Han GetSolderByID(string staffCode)
        {
            return Context.PR_Han.SingleOrDefault(e => e.StaffCode == staffCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="levelI"></param>
        /// <param name="dateLevelI"></param>
        /// <param name="levelII"></param>
        /// <param name="dateLevelII"></param>
        /// <param name="levelIII"></param>
        /// <param name="dateLevelIII"></param>
        /// <param name="dateConfirm"></param>
        /// <param name="dateTestActual"></param>
        public static void UpdateSolder(string staffCode, string levelI, string dateLevelI, string levelII, string dateLevelII, string levelIII, string dateLevelIII, string dateConfirm, string dateTestActual)
        {
            var solder = GetSolderByID(staffCode);
            if (solder != null)
            {
                if (Ultils.IsNull(levelI))
                {
                    solder.CapDoHan = levelI;
                }
                if (Ultils.IsNull(levelII))
                {
                    solder.NangCapDo = levelII;
                }
                if (Ultils.IsNull(levelIII))
                {
                    solder.CNNguoiDaoTao = levelIII;
                }

                if (Ultils.IsNull(dateLevelI))
                {
                    solder.NgayCap = DateTime.Parse(dateLevelI);
                }
                if (Ultils.IsNull(dateLevelII))
                {
                    solder.NgayNangCap = DateTime.Parse(dateLevelII);
                }
                if (Ultils.IsNull(dateLevelIII))
                {
                    solder.NgayCNNguoiDaoTao = DateTime.Parse(dateLevelIII);
                }
                if (Ultils.IsNull(dateConfirm))
                {
                    solder.NgayThiXacNhan = DateTime.Parse(dateConfirm);
                }
                if (Ultils.IsNull(dateTestActual))
                {
                    solder.NgayThiThucTe = DateTime.Parse(dateTestActual);
                }
                try
                {
                    using (var context = new EducationSkillsDbContext())
                    {
                        context.PR_Han.Attach(solder);
                        context.Entry(solder).State = EntityState.Modified;
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
        /// <param name="staffCode"></param>
        /// <param name="level"></param>
        /// <param name="testDate"></param>
        /// <param name="dateConfirmed"></param>
        /// <param name="solanthi"></param>
        public static void InsertSolder(int index, string staffCode, string level, DateTime testDate, DateTime dateConfirmed, int solanthi)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Level", Value = index, SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@CapDoHan", Value = level, SqlDbType = SqlDbType.NVarChar },
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
                Context.Database.ExecuteSqlCommand("EXEC [dbo].[InsertKTHan] @Level, @StaffCode, @CapDoHan, @NgayCap, @NgayThiXacNhan, @Solanthi", param);
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
        public static void DeleteSolder(string staffCode)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                using (var context = new EducationSkillsDbContext())
                {
                    context.Database.ExecuteSqlCommand("EXEC [dbo].[DeleteHan] @StaffCode", param);
                }

            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
                return;
            }
        }

        #endregion

        #region Kiểm tra mắt
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        public static PR_Mat GetEyeByID(string staffCode)
        {
            return Context.PR_Mat.SingleOrDefault(e => e.StaffCode == staffCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffCode"></param>
        /// <param name="level"></param>
        /// <param name="testDate"></param>
        /// <param name="dateConfirmed"></param>
        /// <param name="solanthi"></param>
        public static void InsertEye(int index, string staffCode, string level, DateTime testDate, DateTime dateConfirmed, int solanthi)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@Level", Value = index, SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@CapDo", Value = level, SqlDbType = SqlDbType.NVarChar },
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
                using(var context = new EducationSkillsDbContext())
                {
                    context.Database.ExecuteSqlCommand("EXEC [dbo].[InSertKTMat] @Level, @StaffCode, @CapDo, @NgayCap, @NgayThiXacNhan, @Solanthi", param);
                }
                
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Xóa KTV mắt
        /// </summary>
        /// <param name="staffCode"></param>
        public static void DeleteEye(string staffCode)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@StaffCode", Value = staffCode, SqlDbType = SqlDbType.VarChar },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                using (var context = new EducationSkillsDbContext())
                {
                    context.Database.ExecuteSqlCommand("EXEC [dbo].[DeleteMat] @StaffCode", param);
                }

            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Xóa Olympic
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteOlympic(string id)
        {
            try
            {
                using (var context = new EducationSkillsDbContext())
                {
                    context.Database.ExecuteSqlCommand($"DELETE  FROM [GA_UMC].[dbo].[EDU_Olympics] WHERE ID={id}");
                }

            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessageBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Xóa chứng chỉ
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteManagerCertificates(string id)
        {
            try
            {
                using (var context = new EducationSkillsDbContext())
                {
                    context.Database.ExecuteSqlCommand($"DELETE  FROM [GA_UMC].[dbo].[EDU_ManageCertificates] WHERE ID={id}");
                }

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
        /// <param name="levelI"></param>
        /// <param name="dateLevelI"></param>
        /// <param name="levelII"></param>
        /// <param name="dateLevelII"></param>
        /// <param name="levelIII"></param>
        /// <param name="dateLevelIII"></param>
        /// <param name="dateConfirm"></param>
        public static void UpdateEye(string staffCode, string levelI, string dateLevelI, string levelII, string dateLevelII, string levelIII, string dateLevelIII, string dateConfirm, string dateTestActual)
        {
            var eye = GetEyeByID(staffCode);
            if (eye != null)
            {
                if (Ultils.IsNull(levelI))
                {
                    eye.CapDo = levelI;
                }
                if (Ultils.IsNull(levelII))
                {
                    eye.NangCap = levelII;
                };
                if (Ultils.IsNull(levelIII))
                {
                    eye.CNNguoiDaoTao = levelIII;
                };
                if (Ultils.IsNull(dateLevelI))
                {
                    eye.NgayCap = DateTime.Parse(dateLevelI);
                }
                if (Ultils.IsNull(dateLevelII))
                {
                    eye.NgayNangCap = DateTime.Parse(dateLevelII);
                }
                if (Ultils.IsNull(dateLevelIII))
                {
                    eye.NgayCNNguoiDaoTao = DateTime.Parse(dateLevelIII);
                }
                if(Ultils.IsNull(dateConfirm))
                {
                    eye.NgayThi = DateTime.Parse(dateConfirm);
                }
                if (Ultils.IsNull(dateTestActual))
                {
                    eye.NgayThiThucTe = DateTime.Parse(dateTestActual);
                }
                try
                {
                    using (var context = new EducationSkillsDbContext())
                    {
                        context.PR_Mat.Attach(eye);
                        context.Entry(eye).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                

            }
        }

        #endregion
    }
}
