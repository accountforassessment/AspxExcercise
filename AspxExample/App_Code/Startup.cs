using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspxExample.Startup))]
namespace AspxExample
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
