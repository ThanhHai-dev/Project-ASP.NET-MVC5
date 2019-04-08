using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBookStore.Startup))]
namespace MVCBookStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
