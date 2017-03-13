using System.Web.Mvc;
using System.Web.UI;
using WebMarkupMin.AspNet4.Mvc;

namespace Umc.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [CompressContent]
        [MinifyHtml]
        [OutputCache(Duration = 0, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }
    }
}