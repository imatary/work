using System.Collections;
using System.Linq;
using System.Web;

namespace Umc.Web.Areas.Education.Models
{
    public static class EduDataProvider
    {
        const string EduDataContextKey = "EduDataContext";

        public static EduDataContext DB
        {
            get
            {
                if (HttpContext.Current.Items[EduDataContextKey] == null)
                    HttpContext.Current.Items[EduDataContextKey] = new EduDataContext();
                return (EduDataContext)HttpContext.Current.Items[EduDataContextKey];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IQueryable<PR_Bomon> GetSubjects
        {
           get { return DB.PR_Bomon; }
        }
    }
}