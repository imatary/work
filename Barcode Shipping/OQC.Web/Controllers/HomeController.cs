using OQC.Web.Models;
using OQC.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OverTime.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SearchService _searchService; 
        public HomeController()
        {
            _searchService = new SearchService();
        }

        public async Task<ActionResult> Index(
            string productionId, 
            string macAddress, 
            string boxId,
            string operatorCode,
            string operationDate, 
            string modelId, 
            int? lineId)
        {
            IEnumerable<SearchLogModel> searchLogs = null;

            if (!string.IsNullOrEmpty(productionId))
            {
                searchLogs = await _searchService.SearchLogByProductionID(productionId);
            }
            else if (!string.IsNullOrEmpty(boxId))
            {
                searchLogs = await _searchService.SearchLogByBoxID(boxId);
            }
            else if (!string.IsNullOrEmpty(macAddress))
            {
                searchLogs = await _searchService.SearchLogByMacAddress(macAddress);
            }
            else if (!string.IsNullOrEmpty(operationDate))
            {
                searchLogs = await _searchService.SearchLogByOperationDate(operationDate);
            }
            else if (!string.IsNullOrEmpty(modelId))
            {
                searchLogs = await _searchService.SearchLogByModelID(modelId);
            }
            else if (!string.IsNullOrEmpty(operatorCode))
            {
                searchLogs = await _searchService.SearchLogByOperatorCode(operatorCode);
            }
            else if(lineId > 0)
            {
                searchLogs = await _searchService.SearchLogByLineID(lineId);
            }
            else
            {
                searchLogs = await _searchService.SearchLogsTop();
            }

            return View(searchLogs.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}