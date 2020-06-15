using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTeknololoji.Startup))]
namespace OnlineTeknololoji
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
