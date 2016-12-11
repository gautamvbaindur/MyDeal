using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyDeal.Web.Startup))]
namespace MyDeal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
