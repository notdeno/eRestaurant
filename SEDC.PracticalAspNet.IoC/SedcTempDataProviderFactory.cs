using System.Web.Mvc;

namespace SEDC.PracticalAspNet.IoC
{
    public class SedcTempDataProviderFactory : ITempDataProviderFactory
    {
        public ITempDataProvider CreateInstance()
        {
            return new SedcTempDataProvicer();
        }
    }
}
