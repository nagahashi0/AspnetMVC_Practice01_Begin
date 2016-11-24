using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice01_Begin.Startup))]
namespace Practice01_Begin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
