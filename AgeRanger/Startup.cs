using System.Web.Http;
using AgeRanger.Cors;
using AgeRanger.Register;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AgeRanger.Startup))]

namespace AgeRanger
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = RegisterIoC.RegisterAutoFac(config);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config
                   .RegisterWebApiRoutesAndHandlersAndFiltersAndFormatters();

            app

                //.RegisterCors()
                .UseWebApi(config);
        }
    }
}