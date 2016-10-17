using System.Linq;
using System.Reflection;
using Autofac;
using FluentValidation;

namespace SICO.Application.Main.IoC
{
    public class ValidationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Trademarks.Validators.CreateTrademarkValidator>()
            //    .As<IValidator<Trademarks.CreateTrademarkDto>>()
            //    .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(ValidationModule).GetTypeInfo().Assembly)
                    .Where(t => t.GetInterfaces()
                        .Any(i => i.IsAssignableFrom(typeof(IValidator<>))))
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

            base.Load(builder);
        }
    }
}
