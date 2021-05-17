using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibMan.Startup))]
namespace LibMan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
