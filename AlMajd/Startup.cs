using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlMajd.Startup))]
namespace AlMajd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
