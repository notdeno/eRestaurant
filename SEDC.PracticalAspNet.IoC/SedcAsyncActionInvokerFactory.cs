using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace SEDC.PracticalAspNet.IoC
{
    public class EverythigDefault : IAsyncActionInvokerFactory, IActionInvokerFactory//, //IViewPageActivator
    {
        
        public IAsyncActionInvoker CreateInstance()
        {
            return new AsyncControllerActionInvoker();
        }

        IActionInvoker IActionInvokerFactory.CreateInstance()
        {
            return new ControllerActionInvoker();
        }
    }
}