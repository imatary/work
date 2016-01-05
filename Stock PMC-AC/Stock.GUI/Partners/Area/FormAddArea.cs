using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormAddArea : XtraForm
    {
        private readonly AreaService _areaService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormAddArea()
        {
            InitializeComponent();
            _areaService = new AreaService();
            _logService = new LogService();
            _employeeService = new EmployeeService();
        }

        private void FormAddArea_Load(object sender, EventArgs e)
        {
            txtAreaID.Text = _areaService.NextId();
        }

        /// <summary>
        // Lưu lại quá trình hoạt động của người dùng trên hệ thống
        /// </summary>
        private void InsertSysLog(string item)
        {
            string userName = Program.CurrentUser.UserName;
            string employeeName = _employeeService.GetEmployeeById(Program.CurrentUser.EmployeeID).EmployeeName;
            string info = MachineHelper.GetMachineInfo();
            string itemName = string.Format(Resources.ActionAdd, item);
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleArea, info);
        }

        private Area SetDataArea()
        {
            var area = new Area
            {
                AreaID = txtAreaID.Text,
                AreaName = txtAreaName.Text,
                CreatedDate = DateTime.Now,
                CreatedBy = Program.CurrentUser.UserName,
                Description = string.IsNullOrEmpty(txtDescription.Text)
                    ? string.Format("Khu Vực {0}", txtAreaName.Text)
                    : txtDescription.Text,
            };
            return area;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveArea()
        {
            try
            {
                _areaService.Add(SetDataArea());
                InsertSysLog(txtAreaName.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Đóng Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!string.IsNullOrEmpty(SetDataArea().AreaName))
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

        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SetDataArea().AreaName))
            {
                DialogResult dlgresult = XtraMessageBox.Show(@"Dữ liệu chưa được lưu, Bạn có muốn lưu lại không?", @"THÔNG BÁO",
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
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAreaID.Text))
            {
                txtAreaID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Khu Vực không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAreaID.Focus();
            }
            else if (string.IsNullOrEmpty(txtAreaName.Text))
            {
                txtAreaName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Khu Vực không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAreaName.Focus();
            }
            else
            {
                SaveArea();
                if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Khu vực nữa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ResetControls();
                }
                else
                {
                    DialogResult = DialogResult.No;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetControls()
        {
            txtAreaName.Focus();
            txtAreaID.Text = _areaService.NextId();
            txtAreaName.Text = "";
            txtDescription.Text = "";
            if (txtAreaID.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtAreaID.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (txtAreaName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtAreaName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        private void txtAreaID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtAreaName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtAreaID.Text = _areaService.NextId();
            }
        }

        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtAreaName.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtDescription.Focus();
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

        private void FormAddArea_KeyDown(object sender, KeyEventArgs e)
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