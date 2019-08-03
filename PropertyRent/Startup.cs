using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PropertyRent.Startup))]
namespace PropertyRent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
