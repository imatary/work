using System.Web;
using System.Web.SessionState;

namespace Umc.Web {
    public class ColumnResizingDemoHelper {

        const string ColumnResizingOptionsSessionKey = "339FF557-4B9E-4150-92CB-1F4982EAD4B1";

        public static ColumnResizingDemoOptions Options {
            get {
                if(Session[ColumnResizingOptionsSessionKey] == null)
                    Session[ColumnResizingOptionsSessionKey] = new ColumnResizingDemoOptions();
                return (ColumnResizingDemoOptions)Session[ColumnResizingOptionsSessionKey];
            }
            set { Session[ColumnResizingOptionsSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
