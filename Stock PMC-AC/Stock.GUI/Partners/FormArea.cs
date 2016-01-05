using System;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormArea : XtraForm
    {
        private readonly AreaService _areaService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public string AreaId;
        public FormArea()
        {
            InitializeComponent();
            _areaService = new AreaService();
            _logService = new LogService();
            _employeeService = new EmployeeService();
            InsertSysLog();
        }

        /// <summary>
        /// danh sách khu vực
        /// </summary>
        public void LoadAreas()
        {
            gridControl1.DataSource = _areaService.GetAreas();
        }

        private void InsertSysLog()
        {
            string userName = Program.CurrentUser.UserName;
            string employeeName = _employeeService.GetEmployeeById(Program.CurrentUser.EmployeeID).EmployeeName;
            string info = MachineHelper.GetMachineInfo();

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleArea, info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public static void CloseCurrentForm(Control parent)
        {
            var tabPage = parent as DevExpress.XtraTab.XtraTabPage;
            if (tabPage != null)
            {
                var tabControl = tabPage.Parent as DevExpress.XtraTab.XtraTabControl;
                if (tabControl != null)
                    tabControl.TabPages.Remove(tabPage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonUpdateAndDelete(bool enable)
        {
            barButtonItemUpdate.Enabled = enable;
            barButtonItemDelete.Enabled = enable;
        }
        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var addArea=new FormAddArea();
            addArea.ShowDialog();
            LoadAreas();
        }

        private void barButtonItemPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void barButtonItemExportToExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileDialogFilterExel, 
                Title = Resources.SaveFileDialogTitle
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl1.ExportToXls(saveFileDialog1.FileName);
            }
        }

        private void barButtonItemRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadAreas();
        }

        private void FormArea_Load(object sender, EventArgs e)
        {
            LoadAreas();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                AreaId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "AreaID");
                if (!string.IsNullOrEmpty(AreaId))
                {
                    EnableButtonUpdateAndDelete(true);
                }
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    var areaId = gridView1.GetRowCellValue(rowHandle, "AreaID");
                    if (areaId != null)
                    {
                        Data.Area area = _areaService.GetAreaById(areaId.ToString());
                        if (area != null)
                        {
                            try
                            {
                                _areaService.Delete(areaId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadAreas();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
            

            //if (!string.IsNullOrEmpty(AreaId))
            //{
            //    Data.Area area = _areaService.GetAreaById(AreaId);
            //    if (area != null)
            //    {
            //        DialogResult result =
            //            XtraMessageBox.Show(
            //                "Bạn có chắc muốn xóa thông tin Đơn Vị Tính : " + area.AreaName + " không?", "THÔNG BÁO",
            //                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                _areaService.Delete(AreaId);
            //                LoadAreas();
            //            }
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            EnableButtonUpdateAndDelete(false);
            //        }
            //    }
            //}
            //else
            //{
            
                
            //}
                
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AreaId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Khu vực cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var updateArea = new FormUpdateArea(AreaId);
                updateArea.ShowDialog();
                LoadAreas();
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void barButtonItemUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(AreaId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Khu vực cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var updateArea = new FormUpdateArea(AreaId);
                updateArea.ShowDialog();
                LoadAreas();
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            // Check whether a row is right-clicked.
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();
                // Add a submenu with a single menu item.
                e.Menu.Items.Add(CreateRowSubMenu(view, rowHandle));
                // Add a check menu item.
                DXMenuItem item = CreateMergingEnabledMenuItem(view, rowHandle);
                item.BeginGroup = true;
                e.Menu.Items.Add(item);
            }
        }

        // Create a submenu with a single DeleteRow item.
        DXMenuItem CreateRowSubMenu(GridView view, int rowHandle)
        {
            var subMenu = new DXSubMenuItem("Chọn");
            var menuItemEditRow = new DXMenuItem("&Sửa", new EventHandler(OnDeleteRowClick), imageCollection1.Images[58]) {Tag = new RowInfo(view, rowHandle)};
            var menuItemDeleteRow = new DXMenuItem("&Xóa", new EventHandler(OnDeleteRowClick), imageCollection1.Images[36]) { Tag = new RowInfo(view, rowHandle) };
            subMenu.Items.Add(menuItemEditRow);
            subMenu.Items.Add(menuItemDeleteRow);
            return subMenu;
        }

        // Create a check menu item that triggers the Boolean AllowCellMerge option.
        DXMenuCheckItem CreateMergingEnabledMenuItem(GridView view, int rowHandle)
        {
            var checkItem = new DXMenuCheckItem("&Merging Enabled",
              view.OptionsView.AllowCellMerge, null, new EventHandler(OnMergingEnabledClick))
            {
                Tag = new RowInfo(view, rowHandle)
            };
            return checkItem;
        }

        //The handler for the DeleteRow menu item
        void OnDeleteRowClick(object sender, EventArgs e)
        {
            var item = sender as DXMenuItem;
            if (item != null)
            {
                var info = item.Tag as RowInfo;
                if (info != null) 
                    info.View.DeleteRow(info.RowHandle);
            }
        }

        //The handler for the MergingEnabled menu item
        void OnMergingEnabledClick(object sender, EventArgs e)
        {
            var item = sender as DXMenuCheckItem;
            if (item != null)
            {
                var info = item.Tag as RowInfo;
                if (info != null) 
                    info.View.OptionsView.AllowCellMerge = item.Checked;
            }
        }

        /// <summary>
        /// Nhập Khu Vực bằng file Exel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemImportAreaFormExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var importFormExel = new FormImportAreaFormExel();
            importFormExel.ShowDialog();
            LoadAreas();
        }

        private void FormArea_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                        // Add New
                        case Keys.N:
                        barButtonItemAdd.PerformClick();
                        break;

                        // Import
                        case Keys.I:
                        barButtonItemImportAreaFormExel.PerformClick();
                        break;

                        // Update
                        case Keys.U:
                        barButtonItemUpdate.PerformClick();
                        break;

                        // Delete
                        case Keys.D:
                        barButtonItemDelete.PerformClick();
                        break;

                        // Refesh
                        case Keys.F5:
                        barButtonItemRefesh.PerformClick();
                        break;

                        // Printer
                        case Keys.P:
                        barButtonItemPrint.PerformClick();
                        break;

                        // Export
                        case Keys.X:
                        barButtonItemRefesh.PerformClick();
                        break;

                        // Close
                        case Keys.C:
                        barButtonItemClose.PerformClick();
                        break;
                }
            }
        }

    }

    //The class that stores menu specific information
    class RowInfo
    {
        public RowInfo(GridView view, int rowHandle)
        {
            this.RowHandle = rowHandle;
            this.View = view;
        }
        public GridView View;
        public int RowHandle;
    }
}