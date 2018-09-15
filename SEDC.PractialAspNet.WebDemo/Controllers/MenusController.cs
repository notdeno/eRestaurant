﻿using SEDC.PracticalAspNet.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEDC.PractialAspNet.WebDemo.Controllers
{
    public class MenusController : Controller
    {
        public MenusController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new List<DtoMenu>() {
                new DtoMenu { Id = 1,
                    RestaurantName = "kikiriki bar",
                    TypeEnum = MenuType.Meals }
            });
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(new DtoMenu
            {
                Id = id,
                RestaurantName = "kikiriki bar",
                TypeEnum = MenuType.Meals
            });
        }
    }
}