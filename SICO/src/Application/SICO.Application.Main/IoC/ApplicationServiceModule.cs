using Autofac;
using SICO.Application.Core;
using System.Reflection;

namespace SICO.Application.Main.IoC
{
    public class ApplicationServiceModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationServiceModule).GetTypeInfo().Assembly)
                    .Where(t=>t.GetTypeInfo().IsSubclassOf(typeof(ApplicationServiceBase)))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
