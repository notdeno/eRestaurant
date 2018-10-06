using System.Web.Mvc;
using SEDC.PracticalAspNet.TestingServices;

namespace SEDC.PracticalAspNet.IoCWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemsRepo _itemsRepo;
        
        public HomeController(IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }

        public JsonResult Index()
        {
            var items = _itemsRepo.GetItems();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}