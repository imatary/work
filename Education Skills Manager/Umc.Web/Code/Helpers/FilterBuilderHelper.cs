using System.Web;
using System.Web.SessionState;

namespace Umc.Web {
    public class FilterBuilderDemoHelper {
        const string FilterBuilderOptionsSessionKey = "39E9CEB6-7C2A-4241-B378-E3F3223A7532";

        public static FilterBuilderDemoOptions Options {
            get {
                if(Session[FilterBuilderOptionsSessionKey] == null)
                    Session[FilterBuilderOptionsSessionKey] = new FilterBuilderDemoOptions();
                return (FilterBuilderDemoOptions)Session[FilterBuilderOptionsSessionKey];
            }
            set { Session[FilterBuilderOptionsSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
