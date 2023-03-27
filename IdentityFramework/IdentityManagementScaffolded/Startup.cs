using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityManagementScaffolded.Startup))]
namespace IdentityManagementScaffolded
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
