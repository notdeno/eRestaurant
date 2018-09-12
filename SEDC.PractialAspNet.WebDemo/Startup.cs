using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEDC.PractialAspNet.WebDemo.Startup))]
namespace SEDC.PractialAspNet.WebDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
