using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectDemo.Startup))]
namespace ProjectDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
