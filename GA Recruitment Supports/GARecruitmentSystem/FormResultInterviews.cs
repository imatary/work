using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lib.Services;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace GARecruitmentSystem
{
    public partial class FormResultInterviews : XtraForm
    {
        private readonly ResultsService _resultService;
        private string _Id = null;
        public FormResultInterviews()
        {
            InitializeComponent();

            _resultService = new ResultsService();
            EnableButtonEditAndDelete(false);
            LoadData();
        }
        private void EnableButtonEditAndDelete(bool enable)
        {
            btnUpdate.Enabled = enable;
            btnDelete.Enabled = enable;
        }
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
            EnableButtonEditAndDelete(false);
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
    }
}