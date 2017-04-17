using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Turner_Developer_Challenge.Startup))]
namespace Turner_Developer_Challenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
