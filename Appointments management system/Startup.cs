using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Appointments_management_system.Startup))]
namespace Appointments_management_system
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
