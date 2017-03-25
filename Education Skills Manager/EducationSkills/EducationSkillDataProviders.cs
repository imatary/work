using EducationSkills.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void UpdateSolder(string staffCode, string levelI, string dateLevelI, string levelII, string dateLevelII, string levelIII, string dateLevelIII, string dateConfirm)
        {
            var solder = GetSolderByID(staffCode);
            if (solder != null)
            {
                solder.CapDoHan = levelI;
                solder.NangCapDo = levelII;
                solder.CNNguoiDaoTao = levelIII;

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
        public static void InsertEye(string staffCode)
        {

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
        public static void UpdateEye(string staffCode, string levelI, string dateLevelI, string levelII, string dateLevelII, string levelIII, string dateLevelIII, string dateConfirm)
        {
            var eye = GetEyeByID(staffCode);
            if (eye != null)
            {

                eye.CapDo = levelI;
                eye.NangCap = levelII;
                eye.CNNguoiDaoTao = levelIII;
                
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
                }else
                {

                }
                if(Ultils.IsNull(dateConfirm))
                {
                    eye.NgayThi = DateTime.Parse(dateConfirm);
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
