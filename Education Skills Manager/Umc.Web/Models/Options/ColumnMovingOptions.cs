using DevExpress.Web;
using System.Web.UI.WebControls;

namespace Umc.Web {
    public class ColumnMovingDemoOptions {
        public ColumnMovingDemoOptions() {
            ProcessColumnMoveOnClient = true;
            ColumnMoveMode = GridColumnMoveMode.AmongSiblings;
        }

        public bool ProcessColumnMoveOnClient { get; set; }
        public GridColumnMoveMode ColumnMoveMode { get; set; }
    }
}
