using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using System.Collections;
using DevExpress.XtraScheduler;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;

namespace Lib.Schedule.Core {
    public class AppointmentHelper {
        //public static IEnumerable GetData() {
        //    CarsDBContext DB = new CarsDBContext();
        //    return DB.CarSchedulings.ToList();
        //}
        public static MVCxAppointmentStorage CreateStorage() {
            MVCxAppointmentStorage appStorage = new MVCxAppointmentStorage();
            appStorage.Mappings.AppointmentId = "ID";
            appStorage.Mappings.Start = "StartTime";
            appStorage.Mappings.End = "EndTime";
            appStorage.Mappings.Subject = "Subject";
            appStorage.Mappings.Description = "Description";
            appStorage.Mappings.Type = "EventType";
            appStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
            appStorage.Mappings.Label = "Label";
            appStorage.Mappings.Status = "Status";
            return appStorage;
        }  
    }
}
