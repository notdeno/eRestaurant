using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        [HttpGet]
        [ActionName("items")]
        public ActionResult GetItems()
        {
            var items = _itemsRepo.GetItems();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}