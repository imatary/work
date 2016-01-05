using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateArea : XtraForm
    {
        private readonly AreaService _areaService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        private readonly string _areaId;
        public FormUpdateArea(string areaid)
        {
            InitializeComponent();
            _areaService = new AreaService();
            _areaId = areaid;
            GetAreaById(areaid);
            _logService = new LogService();
            _employeeService = new EmployeeService();
        }

        /// <summary>
        // Lưu lại quá trình hoạt động của người dùng trên hệ thống
        /// </summary>
        private void InsertSysLog(string item)
        {
            string userName = Program.CurrentUser.UserName;
            string employeeName = _employeeService.GetEmployeeById(Program.CurrentUser.EmployeeID).EmployeeName;
            string info = MachineHelper.GetMachineInfo();
            string itemName = string.Format(Resources.ActionUpdate, item);
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleArea, info);
        }

        private void FormUpdateArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!_areaService.IsChangeAreaName(SetDataArea().AreaName))
                {
                    dynamic mboxResult = XtraMessageBox.Show("Dữ liệu chưa được lưu, Bạn có muốn lưu lại không?",
                        @"THÔNG BÁO",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (mboxResult == DialogResult.No)
                    {
                        Dispose();
                    }

                    else if (mboxResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                        SaveArea();
                        Dispose();
                    }
                }
            }
        }

        private Area SetDataArea()
        {
            var area = _areaService.GetAreaById(_areaId);
            if (area != null)
            {
                area.AreaName = txtAreaName.Text;
                area.ModifyDate = DateTime.Now;
                area.Description = string.IsNullOrEmpty(txtDescription.Text)
                    ? string.Format("Khu Vực {0}", txtAreaName.Text)
                    : txtDescription.Text;
            }
            return area;
        }

        private void SaveArea()
        {
            try
            {
                _areaService.Update(SetDataArea());
                InsertSysLog(txtAreaName.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!_areaService.IsChangeAreaName(SetDataArea().AreaName))
            {
                DialogResult dlgresult = XtraMessageBox.Show(@"Dữ liệu chưa được lưu, Bạn có muốn lưu lại không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (dlgresult == DialogResult.Yes)
                {
                    SaveArea();
                    Dispose();
                }
                else
                {
                    Dispose();
                }
            }
            else
            {
                Close();
            } 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAreaName.Text))
            {
                txtAreaName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Khu Vực không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAreaName.Focus();
            }
            else
            {
                try
                {
                    SaveArea();
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        private void GetAreaById(string areaid)
        {
            var area = _areaService.GetAreaById(areaid);
            if (area != null)
            {
                txtAreaID.Text = area.AreaID;
                txtAreaName.Text = area.AreaName;
                txtDescription.Text = area.Description;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtAreaID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtAreaName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtAreaID.SelectAll();}
        }

        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtAreaName.Text = string.Empty;
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDescription.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtAreaName.SelectAll();
                txtAreaName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }

        private void FormUpdateArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSave.PerformClick();
                        break;
                }
            }

            // Đóng form
            if ((Keys)e.KeyValue == Keys.Escape)
                btnClose.PerformClick();
        }

    }
}