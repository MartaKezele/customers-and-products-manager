using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RWAProject.Startup))]
namespace RWAProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
