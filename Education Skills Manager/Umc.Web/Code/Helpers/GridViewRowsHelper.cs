using DevExpress.Web.Mvc;

namespace Umc.Web {
    public class GridViewRowsDemosHelper {
        public const string ImageQueryKey = "DXImage";

        public static string GetEmployeeImageRouteUrl() {
            return DevExpressHelper.GetUrl(new {
                Controller = "Rows",
                Action = "EmployeeImage"
            });
        }
    }
}
