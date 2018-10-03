using SEDC.PracticalAspNet.Business.Contracts;
using SEDC.PracticalAspNet.Common.Contracts;
using System.Web.Mvc;

namespace SEDC.PractialAspNet.WebDemo.Controllers
{
    public class MenusController : Controller
    {
        IMenuService _service;

        public MenusController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var menusResult = _service.LoadAll();
            return View(menusResult.ListItems);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id < 1)
                return RedirectToAction("Index");

            var serviceResult = _service.Load(new DtoMenu { Id = id });
            if (serviceResult == null)
                return RedirectToAction("Index");
            return View(serviceResult.Item);
        }

        [HttpPost]
        public ActionResult Edit(int id, DtoMenu item)
        {
            if (id > 0 && (item?.Id ?? 0) > 0 && id == item.Id)
            {
                var dbItem = _service.Edit(item);
                if (dbItem.Success)
                    return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menuResult = _service.Load(new DtoMenu { Id = id });
            if (menuResult.Success)
                return View(menuResult.Item);
            else return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(DtoMenu request, string nextView)
        {
            ServiceResult<DtoMenu> result = _service.Add(request);
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