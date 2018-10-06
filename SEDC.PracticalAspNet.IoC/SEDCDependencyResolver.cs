using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace SEDC.PracticalAspNet.IoC
{
    public class SEDCDependencyResolver : IDependencyResolver
    {
        private readonly SedcContainer _container;

        public SEDCDependencyResolver(SedcContainer container)
        {
            _container = container;
            _container.Register<IControllerFactory, SedcControllerFactory>();
            _container.Register<ITempDataProviderFactory, SedcTempDataProviderFactory>();
            _container.Register<IAsyncActionInvokerFactory, EverythigDefault>();
            _container.Register<IActionInvokerFactory, EverythigDefault>();

        }

        public object GetService(Type serviceType)
        {
            var type = _container.GetInstance(serviceType);
            return type;
        }

        internal Controller GetController(string controllerName) => _container.GetController(controllerName);

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object> { };// throw new Exception("got no idea why");
        }
    }
}
