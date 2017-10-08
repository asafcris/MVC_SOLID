using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aula_MVC.Web.Startup))]
namespace Aula_MVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
