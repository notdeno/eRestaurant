using Microsoft.Owin;
using Owin;
using SEDC.PractialAspNet.WebDemo;

[assembly: OwinStartup(typeof(Startup))]
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
