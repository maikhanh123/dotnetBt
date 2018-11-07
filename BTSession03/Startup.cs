using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTSession03.Startup))]
namespace BTSession03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
