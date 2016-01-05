using System.Linq;
using System.Web.Mvc;
using MeetingRoom.Repositories;
using MeetingRoom.Web.Models;
using MeetingRoom.Web.ViewModels;

namespace MeetingRoom.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private IRepository _repository;

        public IRepository Repository
        {
            get { return _repository ?? (_repository = new Repository()); }
        }

        // GET: Manager
        public ActionResult Index()
        {
            //var events = Repository.GetAll<CalendarEvent>()
            //    .Join(Repository.GetAll<Room>(), ev => ev.room_id, room => room.key, (even, room) => new { Even = even, Room = room })
            //    .Select(e => new
            //    {
            //        e.Even.id,
            //        e.Even.owner_id,
            //        e.Even.details,
            //        e.Even.end_date,
            //        e.Even.start_date,
            //        e.Even.text,
            //        e.Even.status_id,
            //        e.Even.room_id,
            //        e.Room.label,
            //        e.Even.projector_id,
            //        e.Even.laptop_id,
            //        e.Even.user_name,
            //    });

            var events = (from ev in Repository.GetAll<CalendarEvent>()
                join r in Repository.GetAll<Room>() on ev.room_id equals r.key
                //let laptop = Repository.GetAll<Laptop>().FirstOrDefault(l => l.laptop_id == ev.laptop_id)
                //let projector = Repository.GetAll<Projector>().FirstOrDefault(l => l.projector_id == ev.projector_id)
                //let phone = Repository.GetAll<Phone>().FirstOrDefault(l => l.phone_id == ev.phone_id)
                //join lap in Repository.GetAll<Laptop>() on ev.laptop_id equals lap.laptop_id
                //join proj in Repository.GetAll<Projector>() on ev.projector_id equals proj.projector_id
                //join phone in Repository.GetAll<Phone>() on ev.phone_id equals phone.phone_id

                select new EventViewModel
                {
                    id = ev.id,
                    title = ev.text,
                    start_date = ev.start_date,
                    end_date = ev.end_date,
                    room_name = r.label,
                    user_id = ev.user_id,
                    user_name = ev.user_name,
                    other_devices = ev.other_devices,
                    is_charging = ev.is_charging,
                    laptop_name = ev.laptop_id ?? "Not Use",
                    projector_name = ev.projector_id ?? "Not Use",
                    phone_name = ev.phone_id ?? "Not Use"
                }).OrderBy(ev => ev.start_date.Day).ToList();

            return View(events);
        }
    }
}