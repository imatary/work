using System.Web;

namespace Umc.Web {
    public class GridViewTemplatesDemoHelper {
        const string PageSizeSessionKey = "ed5e843d-cff7-47a7-815e-832923f7fb09";

        public static int PageSize {
            get {
                if(HttpContext.Current.Session[PageSizeSessionKey] == null)
                    return 2;
                return (int)HttpContext.Current.Session[PageSizeSessionKey];
            }
            set { HttpContext.Current.Session[PageSizeSessionKey] = value; }
        }
    }
}
