using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicManagementMVC.Startup))]
namespace ClinicManagementMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
