using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using OverTime.Services;

namespace OverTime.Controllers
{
    public class ExportsController : Controller
    {
        private readonly IBioStarService _bioStarService;
        public ExportsController(IBioStarService bioStarService)
        {
            _bioStarService = bioStarService;
        }

        // GET: Exports
        public async Task<ActionResult> Index()
        {
            var items = await _bioStarService.GetExportsUserInfoAsync();
            return View(items.Take(100));
        }

        public ActionResult RetrieveImage(byte[] imgage)
        {
            byte[] cover = imgage;
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            return null;
        }
        //public byte[] GetImageFromDataBase(int Id)
        //{
        //    var q = from temp in db.Contents where temp.ID == Id select temp.Image;
        //    byte[] cover = q.First();
        //    return cover;
        //}
    }
}