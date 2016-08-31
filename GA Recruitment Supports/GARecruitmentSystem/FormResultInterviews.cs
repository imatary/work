using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lib.Services;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;
using GARecruitmentSystem.Properties;
using DevExpress.Utils.Menu;

namespace GARecruitmentSystem
{
    public partial class FormResultInterviews : XtraForm
    {
        private readonly ResultsService _resultService;
        private string _Id = null;
        public FormResultInterviews()
        {
            InitializeComponent();
            InitializeMenuItems();

            _resultService = new ResultsService();
            EnableButtonEditAndDelete(false);
            LoadData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonEditAndDelete(bool enable)
        {
            btnUpdate.Enabled = enable;
            btnDelete.Enabled = enable;
            
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            gridControl1.Refresh();
            gridControl1.DataSource = _resultService.GetResults();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var inputResult = new FormInputResultInterview();
            inputResult.ShowDialog();
            LoadData();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            if (string.IsNullOrEmpty(_Id))
            {
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show("Vui lòng chọn một người cần sửa!", "THÔNG BÁO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
            }
            else
            {
                var update = new FormEditResultInterview(_Id);
                update.ShowDialog();
                LoadData();
                EnableButtonEditAndDelete(false);
                splashScreenManager1.CloseWaitForm();
            }
            
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Id))
            {
                var score = _resultService.GetResultById(_Id);
                if (score != null)
                {
                    dynamic mboxResult = XtraMessageBox.Show($"Bạn có thực sự muốn xóa '{score.FullName}' không? \n'Yes' để xóa. \n'No' hủy bỏ.",
                    "THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                    if (mboxResult == DialogResult.Yes)
                    {
                        try
                        {
                            _resultService.Delete(_Id);
                            LoadData();
                            EnableButtonEditAndDelete(false);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn lại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn một người cần sửa!", "THÔNG BÁO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        private void bandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }
        private void bandedGridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _Id = ((GridView)sender).GetRowCellValue(e.RowHandle, "Id").ToString();
                if (_Id != null)
                {
                    EnableButtonEditAndDelete(true);
                }
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_Id))
            {
                XtraMessageBox.Show("Vui lòng chọn một người cần sửa!", "THÔNG BÁO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
            }
            else
            {
                var update = new FormEditResultInterview(_Id);
                update.ShowDialog();
                LoadData();
                EnableButtonEditAndDelete(false);
            }
        }

        private void btnExportExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileExcelFilter,
                Title = Resources.SaveFileExelTitle,
                FileName = DateTime.Now.ToString("dd-MM-yyyy")
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl1.ExportToXls(saveFileDialog1.FileName);
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        DXMenuItem[] menuItems;
        void InitializeMenuItems()
        {
            DXMenuItem itemEdit = new DXMenuItem("Sửa ứng viên", ItemEdit_Click, DXMenuItemPriority.High);
            DXMenuItem itemDelete = new DXMenuItem("Xóa ứng viên", ItemDelete_Click, DXMenuItemPriority.Normal);
            menuItems = new DXMenuItem[] { itemEdit, itemDelete };
        }
        private void bandedGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                foreach (DXMenuItem item in menuItems)
                    e.Menu.Items.Add(item);
            }

        }

        private void ItemEdit_Click(object sender, System.EventArgs e)
        {
            btnUpdate.PerformClick();
        }
        private void ItemDelete_Click(object sender, System.EventArgs e)
        {
            //bandedGridView1.DeleteRow(bandedGridView1.FocusedRowHandle);
            btnDelete.PerformClick();
        }

    }
}