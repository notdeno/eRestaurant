﻿using SEDC.PracticalAspNet.Business.Model;
using SEDC.PracticalAspNet.Business.Service;
using System.Web.Mvc;

namespace SEDC.PractialAspNet.WebDemo.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryService _categoriesService;
        public CategoriesController()
        {
            _categoriesService = new CategoryService();
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