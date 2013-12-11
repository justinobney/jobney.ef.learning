using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace Jobney.EF.Learning.Configuration
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            RegisterModules(builder);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<WebModule>();
        }
    }
}