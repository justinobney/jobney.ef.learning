using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Envoc.Mediator;
using Jobney.Core;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Data;
using Module = Autofac.Module;

namespace Jobney.EF.Learning.Configuration
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DataContext>()
                .As<IDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            RegisterGeneric(builder, typeof(ICommandHandler<>));
            RegisterGeneric(builder, typeof(ICommandHandler<,>));
            RegisterGeneric(builder, typeof(IQueryHandler<,>));

            builder.Register(x =>
            {
                var ctx = x.Resolve<IComponentContext>();
                return new Mediator(ctx.Resolve);
            }).As<IMediator>();
        }



        private void RegisterGeneric(ContainerBuilder builder, Type type)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AsClosedTypesOf(type)
                   .AsImplementedInterfaces();
        }
    }
}