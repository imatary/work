using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UMC.GA
{
    public static class GADataProvider
    {
        const string GADataContextKey = "GADbContext";

        public static GADbContext DB
        {
            get
            {
                if (HttpContext.Current.Items[GADataContextKey] == null)
                    HttpContext.Current.Items[GADataContextKey] = new GADbContext();
                return (GADbContext)HttpContext.Current.Items[GADataContextKey];
            }
        }

        static GADbContext context = new GADbContext();

        /// <summary>
        /// 
        /// </summary>
        public static IList<Staff> GetAllStaff
        {
            get { return context.Database.SqlQuery<Staff>("EXEC [dbo].[sp_Get_All_Staff]").ToList(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static IList<Solder> GetCheckSolders(string action, string searchKey)
        {
            object[] param =
            {
                    new SqlParameter() { ParameterName="@Param1", Value=action, SqlDbType=SqlDbType.NVarChar },
                    new SqlParameter() { ParameterName="@Param2", Value=searchKey, SqlDbType=SqlDbType.NVarChar },


                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };
            try
            {
                return context.Database.SqlQuery<Solder>("EXEC [dbo].[sp_Get_All_Check Solders]").ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<CheckEye> GetCheckEyes()
        {
            
            try
            {
                return context.Database.SqlQuery<CheckEye>("EXEC [dbo].[sp_Get_All_CheckEye]").ToList();
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
