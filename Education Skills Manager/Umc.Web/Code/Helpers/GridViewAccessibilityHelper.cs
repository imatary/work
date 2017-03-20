using DevExpress.Web;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Umc.Web {
    public class GridViewAccessibilityDemoHelper {

        const string EditingModeSessionKey = "C5276393-F7EE-469E-A9A8-CB152CCFA485";

        public static List<SelectListItem> GetLanguages() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "English", Value = "en", Selected = true },
                new SelectListItem() { Text = "Русский", Value = "ru" },
                new SelectListItem() { Text = "Deutsch", Value = "de" }
            };
        }
        public static void ApplyCurrentCulture() {
            if(Session["CurrentCulture"] != null) {
                CultureInfo ci = (CultureInfo)Session["CurrentCulture"];
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }

        public static GridViewEditingMode EditMode {
            get {
                if(Session[EditingModeSessionKey] == null)
                    Session[EditingModeSessionKey] = GridViewEditingMode.Batch;
                return (GridViewEditingMode)Session[EditingModeSessionKey];
            }
            set { HttpContext.Current.Session[EditingModeSessionKey] = value; }
        }
        public static bool IsBatchEditing {
            get { return EditMode == GridViewEditingMode.Batch; }
        }

        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
