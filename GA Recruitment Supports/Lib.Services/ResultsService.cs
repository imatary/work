using Lib.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Lib.Services
{
    public interface IResultsService
    {
        string GetAge(string strBirthday);

        List<Result> GetResults();
        Result GetResultById(string id);
        Result GetResultByCMT(string cmt);

        void InsertResult(string id,
            string fullName, DateTime birthday,
            string sex, string sdt, string ns, string hktt,
            string dt, string hight, string cmt, DateTime ngaycap,
            string noicap, string experiene, string staffId,
            string staffCode, string dept, string position,
            DateTime ngayPv, string nguoiPv, DateTime ngaydilam,
            string createdBy);

        void UpdateResult(string id,
            string fullName, DateTime birthday,
            string sex, string sdt, string ns, string hktt,
            string dt, string hight, string cmt, DateTime ngaycap,
            string noicap, string experiene, string staffId,
            string staffCode, string dept, string position,
            DateTime ngayPv, string nguoiPv, DateTime ngaydilam,
            string modifyBy);
    }
    public class ResultsService : IResultsService
    {
        private readonly GARecruitmentEntities _context;
        public ResultsService()
        {
            _context = new GARecruitmentEntities();
        }

        /// <summary>
        /// Tính tuổi
        /// </summary>
        /// <param name="strBirthday"></param>
        /// <returns></returns>
        public string GetAge(string strBirthday)
        {
            DateTime birthday;
            if (!DateTime.TryParse(strBirthday, out birthday))
            {
                
            }
            birthday = DateTime.ParseExact(strBirthday, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age.ToString();
        }

        public Result GetResultByCMT(string cmt)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName="@CMT", Value=cmt, SqlDbType=SqlDbType.VarChar },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                return _context.Database.SqlQuery<Result>("EXEC [dbo].[sp_GetResultByCMT] @CMT", param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result GetResultById(string id)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName="@Id", Value=id, SqlDbType=SqlDbType.VarChar },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                return _context.Database.SqlQuery<Result>("EXEC [dbo].[sp_GetResultById] @Id", param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Result> GetResults()
        {
            try
            {
                return _context.Database.SqlQuery<Result>("EXEC [dbo].[sp_GetResults]").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertResult(string id, string fullName, 
            DateTime birthday, string sex, string sdt, string ns, string hktt, 
            string dt, string hight, string cmt, DateTime ngaycap,
            string noicap, string experiene, string staffId, string staffCode, 
            string dept, string position, DateTime ngayPv, string nguoiPv,
            DateTime ngaydilam, string createdBy)
        {
            object[] param =
            {
                new SqlParameter() {ParameterName="@Id",            Value=id,               SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@FullName",      Value=fullName,         SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@Birthday",      Value=birthday.Date,    SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@Sex",           Value=sex,              SqlDbType=SqlDbType.Char },
                new SqlParameter() {ParameterName="@PhoneNumber",   Value=sdt,              SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@NS",            Value=ns,               SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@HKTT",          Value=hktt,             SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@DT",            Value=dt,               SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@Hight",         Value=hight,            SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@CMT",           Value=cmt,              SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@NgayCap",       Value=ngaycap.Date,     SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@NoiCap",        Value=noicap,           SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@Experiene",     Value=experiene,        SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@StaffID",       Value=staffId,          SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@StaffCode",     Value=staffCode,        SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@Dept",          Value=dept,             SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@Position",      Value=position,         SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@NgayPV",        Value=ngayPv.Date,      SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@NguoiPV",       Value=nguoiPv,          SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@NgayDiLam",     Value=ngaydilam.Date,   SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@CreatedBy",     Value=createdBy,        SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@CreatedDate",   Value=DateTime.Now.Date, SqlDbType=SqlDbType.Date },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_Insert_Results] @Id,@FullName,@Birthday,@Sex,@PhoneNumber,@NS,@HKTT,@DT,@Hight,@CMT,@NgayCap,@NoiCap,@Experiene,@StaffID,@StaffCode,@Dept,@Position,@NgayPV,@NguoiPV,@NgayDiLam,@CreatedBy,@CreatedDate", param);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateResult(string id, string fullName, DateTime birthday, 
            string sex, string sdt, string ns, string hktt, string dt,
            string hight, string cmt, DateTime ngaycap, string noicap, 
            string experiene, string staffId, string staffCode, string dept, 
            string position, DateTime ngayPv, string nguoiPv, 
            DateTime ngaydilam, string modifyBy)
        {
            object[] param =
            {
                new SqlParameter() {ParameterName="@Id",            Value=id,               SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@FullName",      Value=fullName,         SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@Birthday",      Value=birthday.Date,    SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@Sex",           Value=id,               SqlDbType=SqlDbType.Char },
                new SqlParameter() {ParameterName="@PhoneNumber",   Value=sdt,              SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@NS",            Value=ns,               SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@HKTT",          Value=hktt,             SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@DT",            Value=dt,               SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@Hight",         Value=hight,            SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@CMT",           Value=cmt,              SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@NgayCap",       Value=ngaycap,          SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@NoiCap",        Value=noicap,           SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@Experiene",     Value=experiene,        SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@StaffID",       Value=staffId,          SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@StaffCode",     Value=staffCode,        SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@Dept",          Value=dept,             SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@Position",      Value=position,         SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@NgayPV",        Value=ngayPv,           SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@NguoiPV",       Value=nguoiPv,          SqlDbType=SqlDbType.NVarChar },
                new SqlParameter() {ParameterName="@NgayDiLam",     Value=ngaydilam,        SqlDbType=SqlDbType.Date },
                new SqlParameter() {ParameterName="@ModifyBy",      Value=modifyBy,         SqlDbType=SqlDbType.VarChar },
                new SqlParameter() {ParameterName="@ModifyDate",    Value=DateTime.Now.Date, SqlDbType=SqlDbType.Date },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_Update_Results] @Id,@FullName,@Birthday,@Sex,@PhoneNumber,@NS,@HKTT,@DT,@Hight,@CMT,@NgayCap,@NoiCap,@Experiene,@StaffID,@StaffCode,@Dept,@Position,@NgayPV,@NguoiPV,@NgayDiLam,@ModifyBy,@ModifyDate", param);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
