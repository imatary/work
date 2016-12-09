using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using DevExpress.XtraScheduler;
using System.Web.UI.WebControls;

namespace Lib.Schedule.Core
{
    public class SchedulerDemoHelper {
        public const string ImageQueryKey = "DXImage";

        public static string GetCarImageRouteUrl() {
            return DevExpressHelper.GetUrl(new { Controller = "Customization", Action = "CarImage" });
        }

        static MVCxAppointmentStorage defaultAppointmentStorage;
        public static MVCxAppointmentStorage DefaultAppointmentStorage {
            get {
                if(defaultAppointmentStorage == null)
                    defaultAppointmentStorage = CreateDefaultAppointmentStorage();
                return defaultAppointmentStorage;
            }
        }

        static MVCxAppointmentStorage CreateDefaultAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
            appointmentStorage.Mappings.AppointmentId = "ID";
            appointmentStorage.Mappings.Start = "StartTime";
            appointmentStorage.Mappings.End = "EndTime";
            appointmentStorage.Mappings.Subject = "Subject";
            appointmentStorage.Mappings.Description = "Description";
            appointmentStorage.Mappings.Location = "Location";
            appointmentStorage.Mappings.AllDay = "AllDay";
            appointmentStorage.Mappings.Type = "EventType";
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo";
            appointmentStorage.Mappings.Label = "Label";
            appointmentStorage.Mappings.Status = "Status";
            appointmentStorage.Mappings.ResourceId = "CarId";
            return appointmentStorage;
        }

        static MVCxResourceStorage defaultResourceStorage;
        public static MVCxResourceStorage DefaultResourceStorage {
            get {
                if(defaultResourceStorage == null)
                    defaultResourceStorage = CreateDefaultResourceStorage();
                return defaultResourceStorage;
            }
        }
        static MVCxResourceStorage CreateDefaultResourceStorage() {
            MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
            resourceStorage.Mappings.ResourceId = "ID";
            resourceStorage.Mappings.Caption = "Model";
            return resourceStorage;
        }

        static MVCxAppointmentStorage customAppointmentStorage;
        public static MVCxAppointmentStorage CustomAppointmentStorage {
            get {
                if(customAppointmentStorage == null)
                    customAppointmentStorage = CreateCustomAppointmentStorage();
                return customAppointmentStorage;
            }
        }
        static MVCxAppointmentStorage CreateCustomAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = CreateDefaultAppointmentStorage();
            appointmentStorage.CustomFieldMappings.Add("Price", "Price");
            appointmentStorage.CustomFieldMappings.Add("ContactInfo", "ContactInfo");
            return appointmentStorage;
        }

        static SchedulerSettings exportSchedulerSettings;
        public static SchedulerSettings ExportSchedulerSettings {
            get {
                if(exportSchedulerSettings == null)
                    exportSchedulerSettings = CreateExportSchedulerSettings();
                return exportSchedulerSettings;
            }
        }
        static SchedulerSettings CreateExportSchedulerSettings() {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "schedulerExport";
            settings.CallbackRouteValues = new { Controller = "Features", Action = "ICalendarPartial" };
            settings.ActiveViewType = SchedulerViewType.WorkWeek;
            settings.Start = new DateTime(2014, 5, 23);
            settings.Views.DayView.Styles.ScrollAreaHeight = Unit.Pixel(200);
            settings.Views.WorkWeekView.Styles.ScrollAreaHeight = Unit.Pixel(200);
            settings.Views.WeekView.Enabled = false;
            settings.Views.FullWeekView.Enabled = true;
            settings.Storage.EnableReminders = false;

            settings.Storage.Appointments.Assign(DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(DefaultResourceStorage);
            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
            return settings;
        }

        public static SchedulerReportTemplatesDemoOptions ReportTemplatesOptions {
            get {
                const string key = "DXReportTemplatesScheduler";
                var reportTemplatesOptions = HttpContext.Current.Session[key] as SchedulerReportTemplatesDemoOptions;
                if(reportTemplatesOptions == null) {
                    reportTemplatesOptions = new SchedulerReportTemplatesDemoOptions()
                    {
                        ReportTemplateFileName = ReportTemplateFileNames.First(),
                        StartDate = new DateTime(2014, 5, 23),
                        EndDate = new DateTime(2014, 5, 30)
                    };
                    HttpContext.Current.Session[key] = reportTemplatesOptions;
                }
                return reportTemplatesOptions;
            }
        }

        static IEnumerable<string> reportTemplateFileNames;
        public static IEnumerable<string> ReportTemplateFileNames {
            get {
                if(reportTemplateFileNames == null)
                    reportTemplateFileNames = CreateReportTemplateFileNames();
                return reportTemplateFileNames;
            }
        }
        static IEnumerable<string> CreateReportTemplateFileNames() {
            return new List<string>() { "TrifoldStandard.schrepx", "TrifoldResource.schrepx", "TimetableStyle.schrepx",
                "DailyStyleFitToPage.schrepx", "DailyStyleFixedCellHeight.schrepx", "MonthlyStyle.schrepx"};
        }

        static SchedulerSettings reportTemplatesSchedulerSettings;
        public static SchedulerSettings ReportTemplatesSchedulerSettings {
            get {
                if(reportTemplatesSchedulerSettings == null)
                    reportTemplatesSchedulerSettings = CreateReportTemplatesSchedulerSettings();
                return reportTemplatesSchedulerSettings;
            }
        }
        static SchedulerSettings CreateReportTemplatesSchedulerSettings() {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Reporting", Action = "ReportTemplatesPartial" };
            settings.ActiveViewType = SchedulerViewType.Week;
            settings.GroupType = SchedulerGroupType.Resource;
            settings.Start = new DateTime(2014, 5, 23);
            settings.Width = Unit.Percentage(100);

            settings.Views.DayView.ResourcesPerPage = 3;
            settings.Views.DayView.Styles.ScrollAreaHeight = Unit.Pixel(300);
            settings.Views.WorkWeekView.ResourcesPerPage = 3;
            settings.Views.WorkWeekView.Styles.ScrollAreaHeight = Unit.Pixel(300);
            settings.Views.FullWeekView.ResourcesPerPage = 3;
            settings.Views.WeekView.Enabled = false;
            settings.Views.FullWeekView.Enabled = true;
            settings.Views.MonthView.ResourcesPerPage = 3;
            settings.Views.TimelineView.ResourcesPerPage = 3;

            settings.Storage.EnableReminders = false;
            settings.Storage.Appointments.Assign(SchedulerDemoHelper.DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(SchedulerDemoHelper.DefaultResourceStorage);
            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
            return settings;
        }

        static SchedulerSettings dateNavigatorSchedulerSettings;
        public static SchedulerSettings DateNavigatorSchedulerSettings {
            get {
                if(dateNavigatorSchedulerSettings == null)
                    dateNavigatorSchedulerSettings = CreateDateNavigatorSchedulerSettings();
                return dateNavigatorSchedulerSettings;
            }
        }
        static SchedulerSettings CreateDateNavigatorSchedulerSettings() {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "CalendarFeatures", Action = "DateNavigatorPartial" };
            settings.Start = new DateTime(2014, 5, 23);
            settings.Width = Unit.Pixel(580);
            settings.Views.DayView.ResourcesPerPage = 2;
            settings.Views.DayView.Styles.ScrollAreaHeight = Unit.Pixel(400);
            settings.Views.WeekView.Enabled = false;
            settings.Views.FullWeekView.Enabled = true;
            settings.OptionsBehavior.ShowViewNavigator = false;
            settings.OptionsBehavior.ShowViewSelector = false;            

            settings.Storage.EnableReminders = false;
            settings.Storage.Resources.Assign(SchedulerDemoHelper.DefaultResourceStorage);
            settings.Storage.Appointments.Assign(SchedulerDemoHelper.DefaultAppointmentStorage);
            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;

            settings.DateNavigatorExtensionSettings.Name = "dateNavigator";
            settings.DateNavigatorExtensionSettings.Width = 220;
            settings.DateNavigatorExtensionSettings.Properties.Rows = 2;
            settings.DateNavigatorExtensionSettings.Properties.DayNameFormat = DayNameFormat.FirstLetter;
            settings.DateNavigatorExtensionSettings.Properties.BoldAppointmentDates = true;
            return settings;
        }
    }
}
