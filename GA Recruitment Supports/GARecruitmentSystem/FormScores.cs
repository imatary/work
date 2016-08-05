using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Lib.Services;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GARecruitmentSystem
{
    public partial class FormScores : XtraForm
    {
        private readonly ScoreService _scoreService;
        Guid _Id;
        DateTime _dateCreated;
        public FormScores()
        {
            InitializeComponent();

            _scoreService = new ScoreService();

            EnableButtonEditAndDelete(false);
            LoadData();
        }

        private void barButtonItemAddScores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var inputScore = new FormInputScore();
            inputScore.ShowDialog();

            // Load lại dữ liệu
            LoadData();
        }

        private void LoadData()
        {
            gridControl1.Refresh();
            gridControl1.DataSource = _scoreService.GetScores();
        }

        private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "KetQua")
            {
                string value = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByName("gridColumnKetQua"));
                if (value == "OK")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                    
                }
                else if(value == "NG")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            else if (e.Column.FieldName == "KetQuaPicture")
            {
                string value = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByName("gridColumnKetQuaPicture"));
                if (value == "OK")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;

                }
                else if (value == "NG")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            else if(e.Column.FieldName == "Percent")
            {
                int value = 0;
                string Percent = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByName("gridColumnPercent"));

                if (!int.TryParse(Percent, out value))
                {
                    value = 0;
                }

                if(value >= 97)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            else if (e.Column.FieldName == "PercentPicture")
            {
                int value = 0;
                string PercentPicture = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByName("gridColumnPercentPicture"));

                if (!int.TryParse(PercentPicture, out value))
                {
                    value = 0;
                }

                if (value >= 40)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                else if(value < 40)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            else if (e.Column.FieldName == "Difference")
            {
                int value = 0;
                string Difference = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByName("gridColumnDifference"));

                if (!int.TryParse(Difference, out value))
                {
                    value = 0;
                }

                if (value <= 25)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bandedGridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _Id = (Guid)((GridView)sender).GetRowCellValue(e.RowHandle, "Id");
                _dateCreated = (DateTime)((GridView)sender).GetRowCellValue(e.RowHandle, "DateCreated");
                if (_Id.ToString() != null)
                {
                    EnableButtonEditAndDelete(true);
                }
            }
        }

        private void bandedGridView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(_Id.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn một người cần sửa!", "THÔNG BÁO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
            }
            else
            {
                var update = new FormEditScore(_Id, _dateCreated);
                update.ShowDialog();
                LoadData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Id.ToString()))
            {
                var score = _scoreService.GetScoreById(_Id, _dateCreated);
                if(score!= null)
                {
                    try
                    {
                        _scoreService.Delete(_Id, _dateCreated);
                        MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        EnableButtonEditAndDelete(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_Id.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn một người cần sửa!", "THÔNG BÁO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
            }
            else
            {
                var update = new FormEditScore(_Id, _dateCreated);
                update.ShowDialog();
                LoadData();
                EnableButtonEditAndDelete(false);
            }
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void EnableButtonEditAndDelete(bool enable)
        {
            btnUpdate.Enabled = enable;
            btnDelete.Enabled = enable;
        }
    }
}