using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace SEDC.PracticalAspNet.IoC
{
    public class SedcControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var resolver = DependencyResolver.Current as SEDCDependencyResolver;
            Controller controllerInstance = resolver.GetController(controllerName);
            return controllerInstance;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            
        }
    }
}
