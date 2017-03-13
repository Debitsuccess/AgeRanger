using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Infrastructure.IRepository;
using Infrastructure.IService;
using Infrastructure.Repository;
using Infrastructure.Service;
using Infrastructure.Service.AgeRanger;
using Utilities.Registration;

namespace AgeRanger.Register
{

    public static class RegisterIoC
    {
        public static IContainer RegisterAutoFac(HttpConfiguration config)
        {
            // Create a builder, register the controllers and other things
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterTypes()
                .RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            return container;
        }

        public static ContainerBuilder RegisterTypes(this ContainerBuilder builder)
        {
            builder
                //
                // EF Context
                //
                .RegisterIpr(t => new AgeRangerContext())
                
                //Repo
                .RegisterAsIpr(typeof(IPersonRepository),
                    t => new PersonRepository(t.Resolve<AgeRangerContext>()))

                .RegisterAsIpr(typeof(IAgeGroupRepository),
                    t => new AgeGroupRepository(t.Resolve<AgeRangerContext>()))
                 // Service
                .RegisterAsIpr(typeof(IPersonService),
                    t => new PersonService(t.Resolve<IPersonRepository>()));

            return builder;
        }
    }
}