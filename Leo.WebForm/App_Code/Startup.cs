using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Leo.WebForm.Startup))]
namespace Leo.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
