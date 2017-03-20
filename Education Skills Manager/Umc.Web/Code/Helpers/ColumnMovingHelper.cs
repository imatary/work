using System.Web;
using System.Web.SessionState;

namespace Umc.Web {
    public class ColumnMovingDemoHelper {

        const string ColumnMovingOptionsSessionKey = "D4B75DAC-BC90-41E6-807A-C60EFC1E3AFD";

        public static ColumnMovingDemoOptions Options {
            get {
                if(Session[ColumnMovingOptionsSessionKey] == null)
                    Session[ColumnMovingOptionsSessionKey] = new ColumnMovingDemoOptions();
                return (ColumnMovingDemoOptions)Session[ColumnMovingOptionsSessionKey];
            }
            set { Session[ColumnMovingOptionsSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
