using System.Web;
using System.Web.Mvc;
using UMCWorkManager.App_Helpers;

namespace UMCWorkManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new HandleAntiforgeryTokenErrorAttribute()
            //{
            //    ExceptionType = typeof(HttpAntiForgeryException)
            //});
        }
    }
}
