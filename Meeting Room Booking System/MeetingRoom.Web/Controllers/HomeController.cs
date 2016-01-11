using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Controls;
using DHTMLX.Scheduler.Data;
using MeetingRoom.Repositories;
using MeetingRoom.Web.Models;
using Microsoft.AspNet.Identity;

namespace MeetingRoom.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private DHXScheduler _scheduler;
        private IRepository _repository;

        public IRepository Repository
        {
            get { return _repository ?? (_repository = new Repository()); }
        }
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            _scheduler = new DHXScheduler(this)
            {
                Config =
                {
                    first_hour = 5,
                    last_hour = 24,
                    hour_size_px = 88, 
                    time_step = 30,
                    //full_day = true, // Chọn thời gian cho cả ngày
                    separate_short_events = true,
                    wide_form = true,
                    show_loading = true,

                    // show tooltip
                    Tooltip_ClassName = "dhtmlXTooltip tooltip",
                    Tooltip_timeout_to_display = 50,
                    Tooltip_delta_x = 10,
                    Tooltip_delta_y = -20,
                    
                },
                Skin = DHXScheduler.Skins.Flat,
                XY =
                {
                    scroll_width = 0,
                },
                Height = 600,
                //AjaxMode = TransactionModes.REST,
                
                
            };
            // Set language
            //_scheduler.Localization.Directory = "locale";
            //_scheduler.Localization.Set(SchedulerLocalization.Localizations.English, false);

            var evBox = new DHXEventTemplate
            {
                CssClass = _scheduler.Templates.event_class = "my_event",
                //<span class='event_date'>{start_date:date(%H:%i)} - {end_date:date(%H:%i)}</span><br/>

                Template = @"<div class='my_event_body'>
                    <span>by: <strong style='color: red; font-weight: bold; text-decoration: underline; text-transform: uppercase;'>
                                {user_name}</strong></span><br>
                    <% if((ev.end_date - ev.start_date) / 60000 > 60) { %>
                        Begin: <span class='event_date'>{start_date:date(%H:%i)}</span><br/>
                        End: <span class='event_date'>{end_date:date(%H:%i)}</span><br/>
                    <% } else { %>
                        <span class='event_date'>{start_date:date(%H:%i)}</span><br/>
                    <% } %>                  
                    <span>{text}</span><br>
                    <div style=""padding-top:5px;"">
                        Duration: <b><%= (ev.end_date - ev.start_date) / (60 * 60 * 1000) %></b> hours
                    </div>
                  </div>"
            };
            
            _scheduler.Templates.EventBox = evBox;
            _scheduler.Templates.tooltip_text = @"<div class='tootip_date'>
                        <span>by: <strong style='color: red; font-weight: bold; text-decoration: underline; text-transform: uppercase;'>
                                    {user_name}</strong></span><br>
                        <% if((ev.end_date - ev.start_date) / 60000 > 60) { %>
                            Begin: <span class='event_date'>{start_date:date(%H:%i)}</span><br/>
                            End: <span class='event_date'>{end_date:date(%H:%i)}</span><br/>
                        <% } else { %>
                            <span class='event_date'>{start_date:date(%H:%i)}</span><br/>
                        <% } %>                  
                        <strong>{text}</strong><br>
                        <span>{details}</span><br>
                        <span>Room: <strong>{label}</strong></span><br>
                        <% if(ev.laptop_id == null) { %>
                            <span>Laptop: <strong>Not Use</strong></span><br>
                        <% } else { %>
                            <span>Laptop: <strong>{laptop_id}</strong></span><br>
                        <% } %>
                        <% if(ev.projector_id == null) { %>
                            <span>Projector: <strong>Not Use</strong></span><br>
                        <% } else { %>
                            <span>Projector: <strong>{projector_id}</strong></span><br>
                        <% } %> 
                        <div style=""padding-top:5px;"">
                            Duration: <b><%= (ev.end_date - ev.start_date) / (60 * 60 * 1000) %></b> hours
                        </div>
                    </div>";
            
            #region views configuration
            //// Lock Time => 
            //_scheduler.TimeSpans.Add(new DHXMarkTime()
            //{
            //    FullWeek = true,
            //    Day = DayOfWeek.Thursday,
            //    CssClass = "red_section",// apply this css class to the section
            //    HTML = "LockTime", // inner html of the section
            //    Zones = new List<Zone>() { new Zone { Start = 12 * 60, End = 14 * 60 } },
            //    SpanType = DHXTimeSpan.Type.BlockEvents//if specified - user can't create event in this area
            //});
            //// BlockEvents Sunday
            
            //_scheduler.TimeSpans.Add(new DHXMarkTime()
            //{
                
            //    Day = DayOfWeek.Sunday,
            //    CssClass = "green_section",
            //    SpanType = DHXTimeSpan.Type.BlockEvents
            //});
            _scheduler.UpdateFieldsAfterSave();
            _scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Day);
            _scheduler.Extensions.Add(SchedulerExtensions.Extension.Limit);
            _scheduler.Views.Clear(); //removes all views from the scheduler
            _scheduler.Views.Add(new WeekView()); // adds a tab with the week view
            var units = new UnitsView("rooms", "room_id")
            {
                Label = "Rooms",
            }; 
            var rooms = Repository.GetAll<Room>().OrderBy(r=>r.position).ToList();
            var listRooms = new List<object>();

            foreach (var room in rooms)
            {
                listRooms.Add(new
                {
                    key = room.key,
                    label = room.label
                });
            }
            units.AddOptions(rooms); // sets X-Axis items to names of employees  
            _scheduler.Views.Add(units); //adds a tab with the units view
            _scheduler.PreventCache();
            _scheduler.Views.Add(new MonthView()); // adds a tab with the Month view
            _scheduler.InitialView = units.Name; // makes the units view selected initially
            _scheduler.Config.active_link_view = units.Name;
            string viewName = "meetingRoom/Home/LightboxCustomControl";
            //string viewName = "Home/LightboxCustomControl";
            var box = _scheduler.Lightbox.SetExternalLightbox(viewName, 730, 530);
            box.ClassName = "custom_lightbox";
            #endregion


            //#region lightbox configuration

            //_scheduler.Lightbox.Add(new LightboxText("text", "Title") { Height = 28, Focus = true }); // adds the control to the lightbox
            //_scheduler.Lightbox.Add(new LightboxText("details", "Content") { Height = 60 });
            //var selectRoom = new LightboxSelect("room_id", "Select Room");
            //selectRoom.AddOptions(listRooms);
            //_scheduler.Lightbox.Add(selectRoom);

            //AddSelectLaptopAndProject();

            //_scheduler.Lightbox.Add(new LightboxText("other_devices", "Other Devices") { Height = 50 });
            //_scheduler.Lightbox.Add(new LightboxMiniCalendar("time", "Time"));
            //#endregion

            #region data

            // enables dataprocessor
            if (Request.IsAuthenticated)
            {
                _scheduler.EnableDataprocessor = true;
            } 
            else
            {
                _scheduler.Config.isReadonly = true;
                //JavaScript("Please log in!");
                //RedirectToAction("Login", "Account");
            }
            _scheduler.LoadData = true; //'says' to send data request after scheduler initialization 
            _scheduler.Data.DataProcessor.UpdateFieldsAfterSave = true;

            //Responsive
            _scheduler.BeforeInit.Add(string.Format("initResponsive({0})", _scheduler.Name));

            #endregion

            return View(_scheduler);
        }
        /// <summary>
        /// Load Data
        /// </summary>
        /// <returns></returns>
        public ContentResult Data()
        {
            var events = Repository.GetAll<CalendarEvent>()
                .Join(Repository.GetAll<Room>(), ev => ev.room_id, room => room.key,
                    (even, room) => new {Even = even, Room = room})
                .Select(e => new
                {
                    e.Even.id,
                    e.Even.owner_id,
                    e.Even.details,
                    e.Even.end_date,
                    e.Even.start_date,
                    e.Even.text,
                    e.Even.status_id,
                    e.Even.room_id,
                    e.Room.label,
                    e.Even.projector_id,
                    e.Even.laptop_id,
                    e.Even.user_name,
                });

            var data = new SchedulerAjaxData(events);

            return (ContentResult) data;
        }

        public ActionResult LightboxCustomControl(CalendarEvent calendarEvent)
        {
            var calendarEvents = Repository.GetAll<CalendarEvent>().ToList();
            var current = calendarEvents.FirstOrDefault(e => e.id == calendarEvent.id);
            var events = calendarEvents.Where(ev => ev.start_date.Day == DateTime.Now.Day).ToList();
            //if()
            var laptops = Repository.GetAll<Laptop>().Where(l => l.is_empty == false).OrderBy(l => l.position).ToList();
            var projectors = Repository.GetAll<Projector>().Where(p => p.is_empty == false).OrderBy(p => p.position).ToList();
            var phones = Repository.GetAll<Phone>().Where(p => p.is_empty == false).OrderBy(p => p.position).ToList();
            var rooms = Repository.GetAll<Room>().OrderBy(p => p.position).ToList();
            // List laptop
            List<Laptop> listlaptops = (from lap in laptops
                                        where events.All(ev => lap.laptop_id != ev.laptop_id)
                                        select lap).ToList();

            // List projector
            List<Projector> listprojectors = (from project in projectors
                                              where events.All(ev => project.projector_id != ev.projector_id)
                                              select project).ToList();

            // List Phone

            List<Phone> listphones = (from phone in phones
                                      where events.All(ev => phone.phone_id != ev.phone_id)
                                      select phone).ToList();
            if (current == null)
            {
                ViewBag.laptop_id = new SelectList(listlaptops, "laptop_id", "laptop_name");
                ViewBag.phone_id = new SelectList(listphones, "phone_id", "phone_name");
                ViewBag.projector_id = new SelectList(listprojectors, "projector_id", "projector_name");
                ViewBag.room_id = new SelectList(rooms, "key", "label");

                current = calendarEvent;
            }
            else
            {
                ViewBag.laptop_id = new SelectList(laptops, "laptop_id", "laptop_name", current.laptop_id);
                ViewBag.phone_id = new SelectList(phones, "phone_id", "phone_name", current.phone_id);
                ViewBag.projector_id = new SelectList(projectors, "projector_id", "projector_name", current.projector_id);
                ViewBag.room_id = new SelectList(rooms, "key", "label", current.room_id);
            }
            return View(current);
        }

        /// <summary>
        /// Save Action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actionValues"></param>
        /// <returns></returns>
        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            if (Request.IsAuthenticated)
            {
                // an action against particular task (updated/deleted/created) 
                
                var changedEvent = (CalendarEvent) DHXEventsHelper.Bind(typeof (CalendarEvent), actionValues);
                if (action.Type != DataActionTypes.Error)
                {
                    //process resize, d'n'd operations...
                    return NativeSave(changedEvent, actionValues);
                }
                //custom form operation
                return CustomSave(changedEvent, actionValues);
            }
            action.Type = DataActionTypes.Error;
            action.Message = "Please log in!";
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changedEvent"></param>
        /// <param name="actionValues"></param>
        /// <returns></returns>
        public ActionResult CustomSave(CalendarEvent changedEvent, FormCollection actionValues)
        {

            var action = new DataAction(DataActionTypes.Update, changedEvent.id, changedEvent.id);
            string currentUser = HttpContext.User.Identity.Name;
            if (actionValues["actionButton"] != null)
            {
                try
                {
                    string actionButton = actionValues["actionButton"];
                    if (actionButton == "Save")
                    {
                        var eventToUpdate = Repository.GetAll<CalendarEvent>().FirstOrDefault(ev => ev.id == action.SourceId);
                        if (eventToUpdate != null)
                        {
                            if (eventToUpdate.user_name == currentUser)
                            {
                                if (!CheckTimeCurrent(changedEvent.start_date))
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = "Please check start time!";
                                    //return JavaScript("Please check start time!");
                                }
                                try
                                {
                                    if (!Repository.UpdateEvents(changedEvent))
                                    {
                                        action.Type = DataActionTypes.Error;
                                        action.Message = "Update faild!";
                                    }
                                    DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "id" });
                                }
                                catch (Exception ex)
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = ex.Message;
                                }
                            }
                            else
                            {
                                action.Type = DataActionTypes.Error;
                                action.Message = "You can not fix, only the creator can edit!";
                            }

                        }
                        else
                        {
                            action.Type = DataActionTypes.Insert;
                            if (!CheckStartDateAndEndDateInRoom(changedEvent.room_id, changedEvent.start_date, changedEvent.end_date))
                            {
                                action.Type = DataActionTypes.Delete;
                                action.Message = "Please check start time!";
                            }
                            else
                            {
                                if (!CheckTimeCurrent(changedEvent.start_date))
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = "Please check start time!";
                                }
                                try
                                {
                                    if (changedEvent.laptop_id == "NotUse")
                                        changedEvent.laptop_id = null;
                                    if (changedEvent.phone_id == "NotUse")
                                        changedEvent.phone_id = null;
                                    if (changedEvent.projector_id == "NotUse")
                                    {
                                        changedEvent.projector_id = null;
                                    }
                                    else
                                    {
                                        if (!CheckProjectorExitsInRoom(changedEvent.room_id))
                                        {
                                            action.Type = DataActionTypes.Error;
                                            action.Message = "Create faild!";
                                        }
                                    }

                                    changedEvent.user_name = HttpContext.User.Identity.Name;
                                    changedEvent.creator_id = Guid.Parse(HttpContext.User.Identity.GetUserId());
                                    if (!Repository.Insert(changedEvent))
                                    {
                                        action.Type = DataActionTypes.Error;
                                        action.Message = "Create faild!";
                                    }
                                }
                                catch (Exception ex)
                                { 
                                    action.Type = DataActionTypes.Error;
                                    action.Message = ex.Message;
                                }
                            }
                        }
                    }
                    else if (actionButton == "Delete")
                    {
                        action.Type = DataActionTypes.Delete;
                        changedEvent = Repository.GetAll<CalendarEvent>().SingleOrDefault(ev => ev.id == action.SourceId);
                        if (changedEvent != null && changedEvent.user_name == currentUser)
                        {
                            try
                            {
                                if (!Repository.Delete(changedEvent))
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = "Delete faild!";
                                }
                            }
                            catch (Exception ex)
                            {
                                action.Type = DataActionTypes.Error;
                                action.Message = "Delete faild! " + ex.Message;
                            }
                        }
                        else
                        {
                            action.Type = DataActionTypes.Error;
                            action.Message = "You can not delete, only the creator can delete! ";
                        }
                    }
                }

                catch (Exception ex)
                {
                    action.Type = DataActionTypes.Error;
                    action.Message = "Faild! " + ex.Message;
                }
            }
            else
            {
                action.Type = DataActionTypes.Error;
                action.Message = "action notfound! ";
            }


            return (new SchedulerFormResponseScript(action, changedEvent));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changedEvent"></param>
        /// <param name="actionValues"></param>
        /// <returns></returns>
        public ContentResult NativeSave(CalendarEvent changedEvent, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            string currentUser = HttpContext.User.Identity.Name;
            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        if (!CheckStartDateAndEndDateInRoom(changedEvent.room_id, changedEvent.start_date, changedEvent.end_date))
                        {
                            action.Type = DataActionTypes.Delete;
                            action.Message = "Time check faild!";
                        }
                        else
                        {
                            if (!CheckTimeCurrent(changedEvent.start_date))
                            {
                                action.Type = DataActionTypes.Delete;
                                action.Message = "Time check faild!";
                            }
                            else
                            {
                                try
                                {
                                    if (changedEvent.laptop_id == "NotUse")
                                        changedEvent.laptop_id = null;
                                    if (changedEvent.phone_id == "NotUse")
                                        changedEvent.phone_id = null;
                                    if (changedEvent.projector_id == "NotUse")
                                    {
                                        changedEvent.projector_id = null;
                                    }
                                    else
                                    {
                                        if (!CheckProjectorExitsInRoom(changedEvent.room_id))
                                        {
                                            action.Type = DataActionTypes.Error;
                                            action.Message = "Room current is use projector!";
                                        }
                                    }

                                    changedEvent.user_name = HttpContext.User.Identity.Name;
                                    changedEvent.creator_id = Guid.Parse(HttpContext.User.Identity.GetUserId());
                                    if (!Repository.Insert(changedEvent))
                                    {
                                        action.Type = DataActionTypes.Error;
                                        action.Message = "Inrest";
                                    }

                                }
                                catch (Exception ex)
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = ex.Message;
                                }
                            }

                        }
                        break;
                    case DataActionTypes.Delete:
                        changedEvent = Repository.GetAll<CalendarEvent>().SingleOrDefault(ev => ev.id == action.SourceId);
                        if (changedEvent != null)
                        {
                            if (changedEvent.user_name == currentUser)
                            {
                                try
                                {
                                    if (!Repository.Delete(changedEvent))
                                    {
                                        action.Type = DataActionTypes.Error;
                                        action.Message = "Delete";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = ex.Message;
                                }
                            }
                            else
                            {
                                action.Type=DataActionTypes.Error;
                                action.Message = "You can not delete, only the creator can delete!";
                            }
                            
                        }
                        else
                        {
                            action.Type = DataActionTypes.Error;
                            action.Message = "Event id notfound!";
                        }
                        break;
                    default:// "update"                          
                        var eventToUpdate = Repository.GetAll<CalendarEvent>().SingleOrDefault(ev => ev.id == action.SourceId);
                        if (eventToUpdate != null)
                        {
                            if (eventToUpdate.user_name == currentUser)
                            {
                                if (!CheckTimeCurrent(changedEvent.start_date))
                                {
                                    action.Type = DataActionTypes.Error;
                                    action.Message = "Time check!";
                                }
                                else
                                {
                                    try
                                    {
                                        changedEvent.creator_id = Guid.Parse(HttpContext.User.Identity.GetUserId());
                                        changedEvent.user_name = HttpContext.User.Identity.Name;
                                        if (!Repository.UpdateEvents(changedEvent))
                                        {
                                            action.Type = DataActionTypes.Error;
                                            action.Message = "Update";
                                        }
                                        DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "id" });
                                    }
                                    catch (Exception ex)
                                    {
                                        action.Type = DataActionTypes.Error;
                                        action.Message = ex.Message;
                                    }
                                }
                            }
                            else
                            {
                                action.Type = DataActionTypes.Error;
                                action.Message = "You can not fix, only the creator can edit!";
                            }
                        }
                        break;
                }
                if (changedEvent != null)
                    action.TargetId = changedEvent.id;
            }
            catch(Exception ex)
            {
                action.Type = DataActionTypes.Error;
                action.Message = ex.Message;
            }

            return (new AjaxSaveResponse(action));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="room_id">id room</param>
        /// <param name="start_date">thời gian bắt đầu</param>
        /// <param name="end_date">thời gian kết thúc</param>
        /// <returns></returns>
        private bool CheckStartDateAndEndDateInRoom(int room_id, DateTime start_date, DateTime end_date)
        {
            var eventLast = Repository.GetAll<CalendarEvent>().AsEnumerable().LastOrDefault(ev => ev.room_id == room_id && ev.end_date.Day == start_date.Day);
            var timeStartCurent = new TimeSpan(start_date.Hour, start_date.Minute, 0);

            if (eventLast != null)
            {
                var timeEndLast = new TimeSpan(eventLast.end_date.Hour, eventLast.end_date.Minute, 0);
                //var timeStartLast = new TimeSpan(eventLast.start_date.Hour, eventLast.start_date.Minute, 0);
                if (timeStartCurent < timeEndLast)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra
        /// 1. Nếu thời gian bắt đầu mà nhỏ hơn thời gian hiện tại, hệ thống không cho tạo 
        /// 2. Nếu thời gian bắt đầu bằng hoặc lớn hơn thời gian hiện tại, hệ thống thực hiện thêm mới
        /// </summary>
        /// <param name="start_date"></param>
        /// <returns></returns>
        private bool CheckTimeCurrent(DateTime start_date)
        {
            var startTime = new TimeSpan(start_date.Hour, start_date.Minute, 0);
            var currentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);

            // Nếu thời gian là tương lai thì trả về TRUE
            if (start_date >= DateTime.Now)
            {
                // Nếu thời gian là ngày hiện tại thì thực hiện kiểm tra
                // còn lớn hơn thì trả về TRUE
                if (start_date.Day <= DateTime.Now.Day)
                {
                    // Nếu thời gian bắt đầu nhỏ hơn thời gian hiện tại thì trả về FALSE
                    // ngược lại trả về TRUE
                    if (startTime < currentTime)
                    {
                        return false;
                    }
                    return true;
                }
                
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra phòng hiện tại có máy chiếu chưa. Nếu có
        /// thì không cho phép tạo.
        /// </summary>
        /// <param name="room_id">id room</param>
        /// <returns>Thông tin room theo id tương ứng</returns>
        private bool CheckProjectorExitsInRoom(int room_id)
        {
            var room = Repository.GetAll<Room>().AsEnumerable().FirstOrDefault(r => r.key == room_id);
            if (room != null && room.is_projector)
            {
                return false;
            }
            return true;
        }

        public ActionResult TestEvents()
        {
            var events = Repository.GetAll<CalendarEvent>().Where(ev => ev.start_date.Day == DateTime.Now.Day).ToList();
            var laptops = Repository.GetAll<Laptop>().ToList();


            // Danh sách khóa ngoại trong bảng
            //List<Laptop> list = (from lap in laptops
            //        where events.Any(ev => lap.laptop_id == ev.laptop_id)
            //        select lap).ToList();

            // Danh sách laptop mà chưa nằm trong bảng Event
            List<Laptop> list = (from lap in laptops
                where events.All(ev => lap.laptop_id != ev.laptop_id)
                select lap).ToList();

            return View("Events", list);
        }

        public void AddSelectLaptopAndProject()
        {
            var events = Repository.GetAll<CalendarEvent>().Where(ev => ev.start_date.Day == DateTime.Now.Day).ToList();
            var laptops = Repository.GetAll<Laptop>().Where(l => l.is_empty == false).OrderBy(l=>l.position).ToList();
            var projectors = Repository.GetAll<Projector>().Where(p => p.is_empty == false).OrderBy(p => p.position).ToList();
            var phones = Repository.GetAll<Phone>().Where(p => p.is_empty == false).OrderBy(p => p.position).ToList();
            // List laptop
            List<Laptop> listlaptops = (from lap in laptops
                where events.All(ev => lap.laptop_id != ev.laptop_id)
                select lap).ToList();

            // List projector
            List<Projector> listprojectors = (from project in projectors
                where events.All(ev => project.projector_id != ev.projector_id)
                select project).ToList();

            // List Phone

            List<Phone> listphones = (from phone in phones
                where events.All(ev => phone.phone_id != ev.phone_id)
                select phone).ToList();


            // laptop select
            var laptopsSelect = new LightboxSelect("laptop_id", "Laptops");
            if (listlaptops.Count > 0)
            {
                laptopsSelect.AddOptions(listlaptops.Select(s => new
                {
                    key = s.laptop_id,
                    label = s.laptop_name
                }));
            }
            else
            {
                laptopsSelect.AddOptions(Repository.GetAll<Laptop>().Where(p => p.is_empty).ToList().Select(
                    p => new
                    {
                        key = p.laptop_id,
                        label = p.laptop_name,
                    }));
            }
            _scheduler.Lightbox.Add(laptopsSelect);

            // charging
            _scheduler.Lightbox.Add(new LightboxCheckbox("is_charging", "Use charging"));

            // projector
            var projectorsSelect = new LightboxSelect("projector_id", "Projector");
            if (listprojectors.Count > 0)
            {
                projectorsSelect.AddOptions(listprojectors.Select(s => new
                {
                    key = s.projector_id,
                    label = s.projector_name
                }));
            }
            else
            {
                projectorsSelect.AddOptions(Repository.GetAll<Projector>().Where(p => p.is_empty).ToList().Select(
                    p => new
                    {
                        key = p.projector_id,
                        label = p.projector_name,
                    }));
            }

            _scheduler.Lightbox.Add(projectorsSelect);

            // Phone
            var phoneSelect = new LightboxSelect("phone_id", "Phone");
            if (listphones.Count > 0)
            {
                phoneSelect.AddOptions(listphones.Select(
                    p => new
                    {
                        key = p.phone_id,
                        label = p.phone_name,
                    }));
            }
            else
            {
                phoneSelect.AddOptions(Repository.GetAll<Phone>().Where(p => p.is_empty).ToList().Select(
                    p => new
                    {
                        key = p.phone_id,
                        label = p.phone_name,
                    }));
            }
            _scheduler.Lightbox.Add(phoneSelect);

        }

        // InternationalCall
        public ActionResult InternationalCall()
        {
            return View();
        }
    }
}