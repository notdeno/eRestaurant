using SEDC.PracticalAspNet.IoC;
using SEDC.PracticalAspNet.TestingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SEDC.PracticalAspNet.IoCWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = InitializeContainer();
            DependencyResolver.SetResolver(new SEDCDependencyResolver(container));
        }

        private SedcContainer InitializeContainer()
        {
            var container = new SedcContainer();
            container.Register<IItemsRepo, ItemsRepo>();
            return container;
        }
    }
}
