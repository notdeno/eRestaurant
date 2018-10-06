using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SEDC.PracticalAspNet.IoC
{
    public class SEDCDependencyResolver : IDependencyResolver
    {
        private readonly SedcContainer _container;

        public SEDCDependencyResolver(SedcContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            var type = _container.GetInstance(serviceType);
            return type;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new Exception("got no idea why");
        }
    }
}
