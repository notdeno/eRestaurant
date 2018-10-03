using SEDC.PracticalAspNet.Business.Contracts;
using SEDC.PracticalAspNet.Common.Contracts;
using System.Web.Mvc;

namespace SEDC.PractialAspNet.WebDemo.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("getbycategory")]
        public ActionResult GetItemsByCategory(int categoryId)
        {
            var result = _service.GetForCategory(categoryId);
            if (!result.Success)
                return new HttpStatusCodeResult(400, result.ErrorMessage);
            return Json(result.ListItems, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("create")]
        public ActionResult Create(DtoItem item)
        {
            ServiceResult<DtoItem> result = _service.Add(item);
            if (result.Success)
                return Json(result.Item);
            return new HttpStatusCodeResult(400, result.ErrorMessage);
        }
    }
}