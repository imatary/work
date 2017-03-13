using System.Web.Mvc;

namespace Umc.Web.Areas.oqc
{
    public class oqcAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "oqc";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "oqc_default",
                "oqc/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}