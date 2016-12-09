using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMCWorkManager.Controllers
{
    public partial class SheduleController : DevExController
    {
        // GET: Shedule
            public ActionResult Editing()
            {
                return DemoView("Editing", SchedulerDataHelper.EditableDataObject);
            }
            public ActionResult EditingPartial()
            {
                return PartialView("EditingPartial", SchedulerDataHelper.EditableDataObject);
            }
            public ActionResult EditingPartialEditAppointment()
            {
                try
                {
                    SchedulerDataHelper.UpdateEditableDataObject();
                }
                catch (Exception e)
                {
                    ViewData["SchedulerErrorText"] = e.Message;
                }
                return PartialView("EditingPartial", SchedulerDataHelper.EditableDataObject);
            }
    }

    //public partial class FeaturesController : DemoController
    //{
    //    public ActionResult Editing()
    //    {
    //        return DemoView("Editing", SchedulerDataHelper.EditableDataObject);
    //    }
    //    public ActionResult EditingPartial()
    //    {
    //        return PartialView("EditingPartial", SchedulerDataHelper.EditableDataObject);
    //    }
    //    public ActionResult EditingPartialEditAppointment()
    //    {
    //        try
    //        {
    //            SchedulerDataHelper.UpdateEditableDataObject();
    //        }
    //        catch (Exception e)
    //        {
    //            ViewData["SchedulerErrorText"] = e.Message;
    //        }
    //        return PartialView("EditingPartial", SchedulerDataHelper.EditableDataObject);
    //    }
    //}

}