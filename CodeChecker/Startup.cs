using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeChecker.Startup))]
namespace CodeChecker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
