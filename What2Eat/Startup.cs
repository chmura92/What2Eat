using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(What2Eat.Startup))]
namespace What2Eat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
