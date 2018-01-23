using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SudisIm.Startup))]
namespace SudisIm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
