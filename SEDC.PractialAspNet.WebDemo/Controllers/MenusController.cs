using SEDC.PracticalAspNet.Business.Model;
using SEDC.PracticalAspNet.Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEDC.PractialAspNet.WebDemo.Controllers
{
    public class MenusController : Controller
    {
        MenuService _menuService;

        public MenusController()
        {
            _menuService = new MenuService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new List<DtoMenu>() {
                new DtoMenu { Id = 1,
                    MenuName = "kikiriki bar",
                    TypeEnum = MenuType.Meals }
            });
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(new DtoMenu
            {
                Id = id,
                MenuName = "kikiriki bar",
                TypeEnum = MenuType.Meals
            });
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(DtoMenu request, string nextView)
        {
            ServiceResult<DtoMenu> result = _menuService.Add(request);
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View(request);
            }
            switch (nextView)
            {
                case "Create":
                    return RedirectToAction("Create");
                case "Index":
                    return RedirectToAction("Index");
                default:
                    return RedirectToAction("Details", new { id = result.Item.Id });
            }
        }
    }
}