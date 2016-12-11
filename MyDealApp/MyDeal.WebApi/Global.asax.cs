using Autofac;
using Autofac.Integration.WebApi;
using BitlyDotNET.Interfaces;
using BitlyDotNET.Implementations;
using System.Reflection;
using System.Web.Http;
using MyDeal.WebApi.ControllerHelper;

namespace MyDeal.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ControllerHelper.ControllerHelper>().As<IControllerHelper>().InstancePerRequest();
            builder.RegisterType<PassengerService.PassengerLocatorService>().As<PassengerService.IPassengerLocator>().InstancePerRequest();
            builder.RegisterInstance<IBitlyService>(new BitlyService("gautamvbaindur", "R_d4c472a867c340289c4ef651fdb7ed72"));
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
