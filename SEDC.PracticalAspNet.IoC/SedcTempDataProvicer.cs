﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace SEDC.PracticalAspNet.IoC
{
    public class SedcTempDataProvicer : ITempDataProvider
    {
        public IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            return new Dictionary<string, object>();
        }

        public void SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
        }
    }
}
