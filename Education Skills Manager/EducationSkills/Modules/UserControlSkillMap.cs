using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EducationSkills.Data;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraPrinting;

namespace EducationSkills.Modules
{
    public partial class UserControlSkillMap : UserControl
    {
        private EducationSkillsDbContext context;
        public UserControlSkillMap()
        {
            InitializeComponent();
        }

        private void UserControlSkillMap_Load(object sender, EventArgs e)
        {
            GetDepartments();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string selectDept = null;
            if (txtDept.Text != "")
            {
                selectDept = txtDept.EditValue.ToString();
            }

            GetReportSkillsMap(selectDept);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dept"></param>
        private void GetReportSkillsMap(string dept)
        {
            splashScreenManager1.ShowWaitForm();
            DataTable dt = new DataTable();

            context = new EducationSkillsDbContext();

            SqlParameter parmDept = new SqlParameter() { ParameterName = "@deptCode", Value = dept, SqlDbType = SqlDbType.VarChar };
            if (dept == null)
            {
                parmDept.Value = DBNull.Value;
            }
            try
            {
                var subjects = context.Database.SqlQuery<Subject>("EXEC [dbo].[sp_GetSubjectCodes]").ToList();

                List<Staff> staffs = context.Database.SqlQuery<Staff>("EXEC [dbo].[sp_GetStaffs] @deptCode", parmDept).ToList();

                var data = (from f in staffs
                            group f by new { f.StaffCode, f.FullName, f.DeptCode }
                    into myGroup
                            where myGroup.Count() > 0
                            select new
                            {
                                myGroup.Key.StaffCode,
                                myGroup.Key.FullName,
                                myGroup.Key.DeptCode,
                                SubjectIDs = myGroup.GroupBy(f => f.MaBoMon)
                                .Select
                                (m =>
                                   new
                                   {
                                       Date = m.SingleOrDefault(c => c.StaffCode == myGroup.Key.StaffCode).NgayThamGia
                                   })
                            }).ToList();
                // Add Columns
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("FullName", typeof(string));
                dt.Columns.Add("Dept", typeof(string));
                for (int i = 0; i < subjects.Count; i++)
                {
                    dt.Columns.Add(subjects[i].MaBoMon.Replace(" ", ""), typeof(DateTime));
                }

                // Add Rows
                for (int i = 0; i < data.Count; i++)
                {
                    List<object> rowItem = new List<object>();
                    rowItem.Add(data[i].StaffCode);
                    rowItem.Add(data[i].FullName);
                    rowItem.Add(data[i].DeptCode);

                    var IDs = data[i].SubjectIDs.ToList();
                    if (IDs.Any())
                    {
                        for (int j = 0; j < IDs.Count; j++)
                        {
                            DateTime date;
                            if(IDs[j].Date != null)
                            {
                                date = (DateTime)IDs[j].Date;
                                rowItem.Add(date);
                            }
                            else
                            {
                                rowItem.Add(IDs[j].Date);
                            }
                        }
                    }

                    dt.Rows.Add(rowItem.ToArray<object>());
                }

                gridControl1.DataSource = dt;

                gridView1.Columns[0].Width = 70;
                gridView1.Columns[1].Width = 150;
                gridView1.Columns[2].Width = 70;

                gridView1.Columns[0].Fixed = FixedStyle.Left;
                gridView1.Columns[1].Fixed = FixedStyle.Left;
                gridView1.Columns[2].Fixed = FixedStyle.Left;

                // Tooltip Column Title
                foreach (var item in gridView1.Columns)
                {
                    string columnName = item.ToString();
                    if (columnName.StartsWith("EDU-"))
                    {
                        var SubjectName = context.PR_Bomon.SingleOrDefault(m => m.MaBoMon == columnName).TenBoMon;
                        gridView1.Columns[columnName].ToolTip = SubjectName;
                        gridView1.Columns[columnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridView1.Columns[columnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (gridControl1.DataSource != null)
            {
                btnExportToExel.Enabled = true;
            }
            splashScreenManager1.CloseWaitForm();
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetDepartments()
        {
            context = new EducationSkillsDbContext();
            var dept = new Department { DeptCode = "Tất cả" };
            List<Department> departments = null;

            departments = context.Database.SqlQuery<Department>("EXEC [dbo].[sp_Get_All_Departments]").ToList();
            departments.Add(dept);

            txtDept.Properties.DataSource = departments;
            txtDept.Properties.DisplayMember = "DeptCode";
            txtDept.Properties.ValueMember = "DeptCode";

        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            FormDate.Text = string.Empty;
            txtDept.Text = string.Empty;
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            btnFind.Focus();
            btnExportToExel.Enabled = false;
            GetReportSkillsMap(null);
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = @"Save exel file",
                OverwritePrompt = true,
                FileName = $"Reports-KillsMap{DateTime.Now.ToString("dd-MM-yyyy")}"
            };
            var show = saveFileDialog1.ShowDialog();
            if (show == DialogResult.Cancel)
            {
                saveFileDialog1.Dispose();
            }
            if (show == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    XlsxExportOptions opt = new XlsxExportOptions()
                    {
                        TextExportMode = TextExportMode.Text,
                    };
                    gridView1.ExportToXlsx(saveFileDialog1.FileName, opt);
                }
                Process.Start(saveFileDialog1.FileName);
            } 
        }

        private void txtDept_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDept.Text))
            {
                if (txtDept.Text == "Tất cả")
                {
                    GetReportSkillsMap(null);
                }
                else
                {
                    GetReportSkillsMap(txtDept.EditValue.ToString());
                }
            }
        }
        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //if (e.Column.FieldName.StartsWith("EDU-"))
            //{
            //    RepositoryItemDateEdit edit = new RepositoryItemDateEdit();
            //    edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //    edit.Mask.UseMaskAsDisplayFormat = true;
            //    e.RepositoryItem = edit;
            //}
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view == null)
            //{
            //    return;
            //}
            //string searchText = string.IsNullOrWhiteSpace(view.FindFilterText) ? string.Empty : view.FindFilterText.ToLowerInvariant();
            //if (string.IsNullOrWhiteSpace(searchText))
            //{
            //    return;
            //}
            //foreach (GridColumn col in view.Columns)
            //{
            //    string cellText = string.Empty;
            //    if (view.GetListSourceRowCellValue(e.ListSourceRow, col) != null)
            //    {
            //        cellText = view.GetListSourceRowCellValue(e.ListSourceRow, col).ToString();
            //    }
            //    string subText = cellText.Substring(0, Math.Min(cellText.Length, searchText.Length));
            //    int res = string.Compare(searchText.ToLowerInvariant(), subText.ToLowerInvariant(), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.CompareOptions.IgnoreNonSpace);
            //    if (res == 0)
            //    {
            //        e.Handled = true;
            //        e.Visible = true;
            //        // test active filters...
            //        if (view.ActiveFilterEnabled)
            //        {
            //            BaseGridController dataController = view.DataController;
            //            Exception ex;
            //            ExpressionEvaluator eval = dataController.CreateExpressionEvaluator(dataController.FilterCriteria, true, out ex);
            //            e.Visible = eval.Fit(e.ListSourceRow);
            //        }
            //    }
            //}

        }
        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            //if (e.Column.FieldName == "EDU-01")
            //{
            //    e.Handled = true;
            //    int month1 = Convert.ToDateTime(e.Value1).Month;
            //    int month2 = Convert.ToDateTime(e.Value2).Month;
            //    if (month1 > month2)
            //        e.Result = 1;
            //    else
            //        if (month1 < month2)
            //        e.Result = -1;
            //    else e.Result = System.Collections.Comparer.Default.Compare(Convert.ToDateTime(e.Value1).Day, Convert.ToDateTime(e.Value2).Day);
            //}


            //if (e.Column.FieldName.StartsWith("EDU-"))
            //{
            //    e.Column.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            //    ////object val1 = Convert.ToDateTime(e.ListSourceRowIndex1);
            //    ////object val2 = Convert.ToDateTime(e.ListSourceRowIndex2);
            //    ////e.Handled = true;
            //    ////e.Result = System.Collections.Comparer.Default.Compare(val1, val2);

            //    //e.Result = Comparer.Default.Compare(e.Value1, e.Value2);
            //    //if (e.Result == 0)
            //    //    e.Result = Comparer.Default.Compare((e.RowObject1 as DataObject), (e.RowObject2 as DataObject));
            //    //e.Handled = true;

            //    if (e.Column.FieldName.StartsWith("EDU-"))
            //    {
            //        if (e.Value1 == null || e.Value2 == null)
            //            return;
            //        e.Handled = true;
            //        DateTime d1 = Convert.ToDateTime("1 " + e.Value1.ToString() + " 1900");
            //        DateTime d2 = Convert.ToDateTime("1 " + e.Value2.ToString() + " 1900");
            //        if (d1 > d2)
            //            e.Result = 1;
            //        else if (d1 == d2)
            //            e.Result = 0;
            //        else
            //            e.Result = -1;
            //    }
            //}
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName.StartsWith("EDU-"))
            {
                DateTime time = DateTime.MinValue;
                if (e.Value != DBNull.Value)
                {
                    if (Convert.ToDateTime(e.Value) == time)
                    {
                        e.DisplayText = "";
                    }
                }
                
            }
        }
    }
}
