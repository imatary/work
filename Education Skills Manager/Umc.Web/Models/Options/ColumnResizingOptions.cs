using DevExpress.Web;
using System.Web.UI.WebControls;

namespace Umc.Web {
    public class ColumnResizingDemoOptions {
        public ColumnResizingDemoOptions() {
            ColumnResizeMode = ColumnResizeMode.NextColumn;
            Visualization = ResizingMode.Live;
        }

        public ColumnResizeMode ColumnResizeMode { get; set; }
        public ResizingMode Visualization { get; set; }
    }
}
