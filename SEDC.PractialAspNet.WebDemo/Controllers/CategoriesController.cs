using SEDC.PracticalAspNet.Business.Contracts;
using SEDC.PracticalAspNet.Business.Service;
using SEDC.PracticalAspNet.Common.Contracts;
using System.Web.Mvc;

namespace SEDC.PractialAspNet.WebDemo.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoriesService;

        public CategoriesController(ICategoryService service)
        {
            _categoriesService = service;
        }

        [HttpGet]
        [ActionName("getbymenu")]
        public ActionResult GetAllCategories(int menuId)
        {
            ServiceResult<DtoCategory> result = _categoriesService.LoadForMenu(menuId);
            if (result.Success)
                return Json(result.ListItems, JsonRequestBehavior.AllowGet);
            return new HttpStatusCodeResult(400, result.ErrorMessage);
        }

        [HttpPost]
        [ActionName("create")]
        public ActionResult CreateCategory(DtoCategory request)
        {
            ServiceResult<DtoCategory> result = _categoriesService.Add(request);
            if (result.Success)
                return Json(result.Item);
            return new HttpStatusCodeResult(400, result.ErrorMessage);
        }
    }
}