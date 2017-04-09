using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcroGARC.Startup))]
namespace AcroGARC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
