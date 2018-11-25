using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medi_Call.Startup))]
namespace Medi_Call
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
