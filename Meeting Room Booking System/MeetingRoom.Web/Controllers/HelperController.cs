using System.Linq;
using System.Web.Mvc;
using MeetingRoom.Repositories;
using MeetingRoom.Web.Models;

namespace MeetingRoom.Web.Controllers
{
    public class HelperController : Controller
    {

        private IRepository _repository;

        public IRepository Repository
        {
            get { return _repository ?? (_repository = new Repository()); }
        }

        // GET: Helper

        [ChildActionOnly]
        public PartialViewResult PhoneInRooms()
        {
            return PartialView(Repository.GetAll<Room>().OrderBy(r=>r.position).ToList());
        }
    }
}