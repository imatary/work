using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Data;
using DevExpress.Web.Mvc;
using DevExpress.XtraPrinting;
using DevExpress.Web;

namespace Umc.Web {
    public enum GridViewExportFormat { None, Pdf, Xls, Xlsx, Rtf, Csv }
    public delegate ActionResult GridViewExportMethod(GridViewSettings settings, object dataObject);

    public class GridViewExportDemoHelper {
        static string ExcelDataAwareGridViewSettingsKey = "51172A18-2073-426B-A5CB-136347B3A79F";
        static string FormatConditionsExportGridViewSettingsKey = "14634B6F-E1DC-484A-9728-F9608615B628";

        static Dictionary<GridViewExportFormat, GridViewExportMethod> exportFormatsInfo;
        public static Dictionary<GridViewExportFormat, GridViewExportMethod> ExportFormatsInfo {
            get {
                if(exportFormatsInfo == null)
                    exportFormatsInfo = CreateExportFormatsInfo();
                return exportFormatsInfo;
            }
        }

        static IDictionary Context { get { return System.Web.HttpContext.Current.Items; } }

        static Dictionary<GridViewExportFormat, GridViewExportMethod> CreateExportFormatsInfo() {
            return new Dictionary<GridViewExportFormat, GridViewExportMethod> {
                { GridViewExportFormat.Pdf, GridViewExtension.ExportToPdf },
                {
                    GridViewExportFormat.Xls,
                    (settings, data) => GridViewExtension.ExportToXls(settings, data, new XlsExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG })
                },
                { 
                    GridViewExportFormat.Xlsx,
                    (settings, data) => GridViewExtension.ExportToXlsx(settings, data, new XlsxExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG })
                },
                { GridViewExportFormat.Rtf, GridViewExtension.ExportToRtf },
                {
                    GridViewExportFormat.Csv,
                    (settings, data) => GridViewExtension.ExportToCsv(settings, data, new CsvExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG })
                }
            };
        }

        static Dictionary<GridViewExportFormat, GridViewExportMethod> dataAwareExportFormatsInfo;
        public static Dictionary<GridViewExportFormat, GridViewExportMethod> DataAwareExportFormatsInfo {
            get {
                if(dataAwareExportFormatsInfo == null)
                    dataAwareExportFormatsInfo = CreateDataAwareExportFormatsInfo();
                return dataAwareExportFormatsInfo;
            }
        }
        static Dictionary<GridViewExportFormat, GridViewExportMethod> CreateDataAwareExportFormatsInfo() {
            return new Dictionary<GridViewExportFormat, GridViewExportMethod> {
                { GridViewExportFormat.Xls, GridViewExtension.ExportToXls },
                { GridViewExportFormat.Xlsx, GridViewExtension.ExportToXlsx },
                { GridViewExportFormat.Csv, GridViewExtension.ExportToCsv }
            };
        }

        static Dictionary<GridViewExportFormat, GridViewExportMethod> formatConditionsExportFormatsInfo;
        public static Dictionary<GridViewExportFormat, GridViewExportMethod> FormatConditionsExportFormatsInfo {
            get {
                if(formatConditionsExportFormatsInfo == null)
                    formatConditionsExportFormatsInfo = CreateFormatConditionsExportFormatsInfo();
                return formatConditionsExportFormatsInfo;
            }
        }
        static Dictionary<GridViewExportFormat, GridViewExportMethod> CreateFormatConditionsExportFormatsInfo() {
            return new Dictionary<GridViewExportFormat, GridViewExportMethod> {
                { GridViewExportFormat.Pdf, GridViewExtension.ExportToPdf},
                { GridViewExportFormat.Xls, (settings, data) => GridViewExtension.ExportToXls(settings, data) },
                { GridViewExportFormat.Xlsx,
                    (settings, data) => GridViewExtension.ExportToXlsx(settings, data, new XlsxExportOptionsEx {ExportType = DevExpress.Export.ExportType.WYSIWYG})
                },
                { GridViewExportFormat.Rtf, GridViewExtension.ExportToRtf }
            };
        }

        static Dictionary<GridViewExportFormat, GridViewExportMethod> advancedBandsExportFormatsInfo;
        public static Dictionary<GridViewExportFormat, GridViewExportMethod> AdvancedBandsExportFormatsInfo {
            get {
                if(advancedBandsExportFormatsInfo == null)
                    advancedBandsExportFormatsInfo = CreateAdvancedBandsExportFormatsInfo();
                return advancedBandsExportFormatsInfo;
            }
        }
        static Dictionary<GridViewExportFormat, GridViewExportMethod> CreateAdvancedBandsExportFormatsInfo() {
            return new Dictionary<GridViewExportFormat, GridViewExportMethod> {
                { GridViewExportFormat.Pdf, GridViewExtension.ExportToPdf },
                { GridViewExportFormat.Xls, (settings, data) => GridViewExtension.ExportToXls(settings, data, new XlsExportOptionsEx {ExportType = DevExpress.Export.ExportType.WYSIWYG}) },
                { GridViewExportFormat.Xlsx, (settings, data) => GridViewExtension.ExportToXlsx(settings, data, new XlsxExportOptionsEx {ExportType = DevExpress.Export.ExportType.WYSIWYG}) },
                { GridViewExportFormat.Rtf, GridViewExtension.ExportToRtf }
            };
        }

        public static string GetExportButtonTitle(GridViewExportFormat format) {
            if(format == GridViewExportFormat.None)
                return string.Empty;
            return string.Format("Export to {0}", format.ToString().ToUpper());
        }

        public static GridViewSettings CreateGeneralMasterGridSettings() {
            return CreateGeneralMasterGridSettings(GridViewDetailExportMode.None);
        }
        public static GridViewSettings CreateGeneralMasterGridSettings(GridViewDetailExportMode exportMode) {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "masterGrid";
            settings.Width = Unit.Percentage(100);

            settings.KeyFieldName = "CategoryID";
            settings.Columns.Add("CategoryID");
            settings.Columns.Add("CategoryName");
            settings.Columns.Add("Description");
            settings.Columns.Add(c => {
                c.FieldName = "Picture";
                c.ColumnType = MVCxGridViewColumnType.BinaryImage;
                BinaryImageEditProperties properties = (BinaryImageEditProperties)c.PropertiesEdit;
                properties.ImageWidth = 120;
                properties.ImageHeight = 80;
                properties.ExportImageSettings.Width = 90;
                properties.ExportImageSettings.Height = 60;
            });

            settings.SettingsDetail.ShowDetailRow = true;
            settings.SettingsDetail.ExportMode = exportMode;

            settings.SettingsExport.GetExportDetailGridViews = (s, e) => {
                int categoryID = (int)DataBinder.Eval(e.DataItem, "CategoryID");
                GridViewExtension grid = new GridViewExtension(CreateGeneralDetailGridSettings(categoryID));
                //grid.Bind(NorthwindDataProvider.GetProducts(categoryID));
                e.DetailGridViews.Add(grid);
            };

            return settings;
        }

        public static GridViewSettings CreateGeneralDetailGridSettings(int uniqueKey) {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "detailGrid" + uniqueKey;
            settings.Width = Unit.Percentage(100);

            settings.KeyFieldName = "ProductID";
            settings.Columns.Add("ProductID");
            settings.Columns.Add("ProductName");
            settings.Columns.Add("UnitPrice");
            settings.Columns.Add("QuantityPerUnit");

            settings.SettingsDetail.MasterGridName = "masterGrid";

            return settings;
        }

        static GridViewSettings exportGridViewSettings;
        public static GridViewSettings ExportGridViewSettings {
            get {
                if(exportGridViewSettings == null)
                    exportGridViewSettings = CreateExportGridViewSettings();
                return exportGridViewSettings;
            }
        }
        static GridViewSettings CreateExportGridViewSettings() {
            GridViewSettings settings = new GridViewSettings();

            settings.Name = "gvExport";
            settings.CallbackRouteValues = new { Controller = "Exporting", Action = "ExportPartial" };
            settings.Width = Unit.Percentage(100);

            settings.Columns.Add("CompanyName");
            settings.Columns.Add("City").GroupIndex = 1;
            settings.Columns.Add("Country").GroupIndex = 0;
            settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
            settings.Columns.Add("Quantity");

            MVCxGridViewColumn column = settings.Columns.Add("Total");
            column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            column.PropertiesEdit.DisplayFormatString = "c";
            settings.CustomUnboundColumnData = (sender, e) => {
                if(e.Column.FieldName == "Total") {
                    decimal price = (decimal)e.GetListSourceFieldValue("UnitPrice");
                    int quantity = Convert.ToInt32(e.GetListSourceFieldValue("Quantity"));
                    e.Value = price * quantity;
                }
            };

            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "CompanyName");
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            settings.Settings.ShowFooter = true;
            settings.SettingsExport.RenderBrick = (sender, e) => {
                if(e.RowType == GridViewRowType.Data && e.VisibleIndex % 2 == 0)
                    e.BrickStyle.BackColor = System.Drawing.Color.FromArgb(0xEE, 0xEE, 0xEE);
            };

            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "CompanyName");
            settings.Settings.ShowGroupPanel = true;
            return settings;
        }

        public static GridViewSettings ExcelDataAwareExportGridViewSettings {
            get {
                GridViewSettings settings = Context[ExcelDataAwareGridViewSettingsKey] as GridViewSettings;
                if(settings == null)
                    Context[ExcelDataAwareGridViewSettingsKey] = settings = CreateExcelDataAwareExportGridViewSettings();
                return settings;
            }
        }
        static GridViewSettings CreateExcelDataAwareExportGridViewSettings() {
            GridViewSettings settings = new GridViewSettings();

            settings.Name = "grid";
            settings.CallbackRouteValues = new { Action = "ExcelDataAwarePartial", Controller = "Exporting" };
            settings.Width = Unit.Percentage(100);

            settings.KeyFieldName = "ProductID";
            settings.CommandColumn.Visible = true;
            settings.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.Page;
            settings.CommandColumn.ShowSelectCheckbox = true;
            settings.Columns.Add(c => {
                c.FieldName = "CategoryID";
                c.Caption = "Category Name";
                c.GroupIndex = 0;
                c.Width = 150;
        
                c.ColumnType = MVCxGridViewColumnType.ComboBox;
                var properties = (ComboBoxProperties)c.PropertiesEdit;
                properties.ValueType = typeof(int);
                properties.ValueField = "CategoryID";
                properties.TextField = "CategoryName";
                //properties.DataSource = NorthwindDataProvider.GetCategories();
            });
            settings.Columns.Add("ProductName");
            settings.Columns.Add("QuantityPerUnit");
            settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
            settings.Columns.Add("UnitsInStock");
            settings.Columns.Add(c => {
                c.FieldName = "Total";
                c.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                c.UnboundExpression = "UnitPrice * UnitsInStock";
                c.PropertiesEdit.DisplayFormatString = "c";
            });
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "ProductName");
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "ProductName").ShowInGroupFooterColumn = "ProductName";
            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total").ShowInGroupFooterColumn = "Total";
            settings.SettingsPager.PageSize = 15;
            settings.Settings.ShowGroupPanel = true;
            settings.Settings.ShowFooter = true;
            settings.Settings.ShowGroupFooter = GridViewGroupFooterMode.VisibleAlways;
    
            settings.PreRender = (sender, e) => {
                var grid = sender as MVCxGridView;
                if(grid != null)
                    grid.ExpandRow(0);
            };
            return settings;
        }

        public static GridViewSettings FormatConditionsExportGridViewSettings {
            get {
                var settings = Context[FormatConditionsExportGridViewSettingsKey] as GridViewSettings;
                if(settings == null)
                    Context[FormatConditionsExportGridViewSettingsKey] = settings = CreateFormatConditionsExportGridViewSettings();
                return settings;
            }
        }
        static GridViewSettings CreateFormatConditionsExportGridViewSettings() {
            var settings = new GridViewSettings();
            settings.Name = "grid";
            settings.CallbackRouteValues = new { Controller = "Exporting", Action = "ExportWithFormatConditionsPartial" };
            settings.KeyFieldName = "OrderID;ProductID";
            settings.EnableRowsCache = false;
            settings.Width = Unit.Percentage(100);
            settings.Columns.Add(column => {
                column.FieldName = "CustomerName";
                column.Width = 260;
            });
            settings.Columns.Add(column => {
                column.FieldName = "Freight";
                column.SortOrder = ColumnSortOrder.Descending;
            });
            settings.Columns.Add(column => {
                column.FieldName = "UnitPrice";
                column.ColumnType = MVCxGridViewColumnType.TextBox;
                column.PropertiesEdit.DisplayFormatString = "c";
            });
            settings.Columns.Add(column => {
                column.FieldName = "Discount";
                column.ColumnType = MVCxGridViewColumnType.SpinEdit;
                column.PropertiesEdit.DisplayFormatString = "p0";
            });
            settings.Columns.Add("Quantity");
            settings.Columns.Add(column => {
                column.FieldName = "Total";
                column.UnboundType = UnboundColumnType.Decimal;
                column.UnboundExpression = "UnitPrice * Quantity * (1 - Discount)";
                column.PropertiesEdit.DisplayFormatString = "c";
            });
            settings.FormatConditions.AddTopBottom("UnitPrice", GridTopBottomRule.AboveAverage, GridConditionHighlightFormat.ItalicText);
            settings.FormatConditions.AddTopBottom("UnitPrice", GridTopBottomRule.AboveAverage, GridConditionHighlightFormat.RedText);
            settings.FormatConditions.AddHighlight("Discount", "[Discount] > 0", GridConditionHighlightFormat.GreenFillWithDarkGreenText);
            settings.FormatConditions.AddTopBottom(formatCondition => {
                formatCondition.FieldName = "Discount";
                formatCondition.Rule = GridTopBottomRule.TopItems;
                formatCondition.Threshold = 15;
                formatCondition.Format = GridConditionHighlightFormat.BoldText;
            });
            settings.FormatConditions.AddColorScale("Quantity", GridConditionColorScaleFormat.GreenWhite);
            settings.FormatConditions.AddIconSet("Quantity", GridConditionIconSetFormat.Ratings4);
            settings.FormatConditions.AddTopBottom(formatCondition => {
                formatCondition.FieldName = "Total";
                formatCondition.Rule = GridTopBottomRule.TopPercent;
                formatCondition.Threshold = 20;
                formatCondition.Format = GridConditionHighlightFormat.Custom;
                formatCondition.CellStyle.Font.Bold = true;
                formatCondition.CellStyle.ForeColor = Color.FromArgb(0x9c, 0, 0x6);
            });
            return settings;
        }


        public static GridViewSettings AdvancedBandsExportGridViewSettings {
            get {
                var settings = Context[FormatConditionsExportGridViewSettingsKey] as GridViewSettings;
                if(settings == null)
                    Context[FormatConditionsExportGridViewSettingsKey] = settings = CreateFormatAdvancedBandGridViewSettings();
                return settings;
            }
        }
        static GridViewSettings CreateFormatAdvancedBandGridViewSettings() {
            var settings = new GridViewSettings();
            settings.Name = "grid";
            settings.CallbackRouteValues = new { Controller = "Exporting", Action = "ExportWithDataCellBandsPartial" };
            settings.EnableRowsCache = false;
            settings.Width = Unit.Percentage(100);
            settings.SettingsPager.PageSize = 3;
            settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center;

            settings.Columns.Add(column => {
                column.ColumnType = MVCxGridViewColumnType.SpinEdit;
                column.FieldName = "Price";
                column.PropertiesEdit.DisplayFormatString = "c0";
            });
            var addressColumn = new GridViewDataColumn("Address");
            settings.Columns.Add(addressColumn);
            addressColumn.CellStyle.CssClass = "address-cell";
            var featuresColumn = new GridViewDataColumn("Features");
            addressColumn.Columns.Add(featuresColumn);
            featuresColumn.Columns.AddRange(
                new GridViewDataColumn("Beds") { ExportWidth = 80 },
                new GridViewDataColumn("Baths") { ExportWidth = 80 },
                new GridViewDataColumn("HouseSize") { ExportWidth = 80 });
            var yearBuiltColumn = new GridViewDataColumn("YearBuilt") { ExportWidth = 80 };
            yearBuiltColumn.CellStyle.HorizontalAlign = HorizontalAlign.Right;
            featuresColumn.Columns.Add(yearBuiltColumn);
            settings.Columns.Add(column => {
                column.ColumnType = MVCxGridViewColumnType.Image;
                var imageProperties = (ImageEditProperties)column.PropertiesEdit;
                column.FieldName = "PhotoUrl";
                column.Caption = "Photo";
                column.CellStyle.CssClass = "photo-cell";
                imageProperties.ImageWidth = 200;
            });

            settings.SettingsExport.RenderBrick += (s, e) => {
                if(e.RowType != GridViewRowType.Data)
                    return;
                var dataColumn = (GridViewDataColumn)e.Column;
                if(dataColumn.FieldName == "PhotoUrl") {
                    var path = HostingEnvironment.MapPath(e.Value.ToString());
                    if(File.Exists(path))
                        e.ImageValue = File.ReadAllBytes(path);
                }
            };

            return settings;
        }
    }
}
