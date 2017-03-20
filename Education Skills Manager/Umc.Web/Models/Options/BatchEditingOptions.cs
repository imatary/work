using DevExpress.Web;

namespace Umc.Web
{
    public class BatchEditingDemoOptions {
        public BatchEditingDemoOptions() {
            EditMode = GridViewBatchEditMode.Cell;
            StartEditAction = GridViewBatchStartEditAction.FocusedCellClick;
            HighlightDeletedRows = true;
        }

        public GridViewBatchEditMode EditMode { get; set; }
        public GridViewBatchStartEditAction StartEditAction { get; set; }
        public bool HighlightDeletedRows { get; set; }

        public void Assign(BatchEditingDemoOptions source) {
            EditMode = source.EditMode;
            StartEditAction = source.StartEditAction;
            HighlightDeletedRows = source.HighlightDeletedRows;
        }
    }
}
