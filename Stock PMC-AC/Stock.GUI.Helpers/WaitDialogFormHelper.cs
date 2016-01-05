namespace Stock.GUI.Helpers
{
    public class WaitDialogFormHelper
    {
        private DevExpress.Utils.WaitDialogForm _dlg;
        /// <summary>
        /// Tạo WaitDialog
        /// </summary>
        public void CreateWaitDialog()
        {
            _dlg = new DevExpress.Utils.WaitDialogForm("Xin vui lòng chờ đợi");
        }

        
        /// <summary>
        /// Tạo Caption cho WaitDialog
        /// </summary>
        /// <param name="fCaption"></param>
        public void SetWaitDialogCaption(string fCaption)
        {
            if (_dlg != null)
            {
                _dlg.SetCaption(fCaption);_dlg.Caption = fCaption;
            }
        }
        /// <summary>
        /// Đóng WaitDialog
        /// </summary>
        public void CloseWait()
        {
            _dlg.Close();
        } 
    }
}