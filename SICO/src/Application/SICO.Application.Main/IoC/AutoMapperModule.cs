using Autofac;
using AutoMapper;
using SICO.Application.Core;
using System.Reflection;

namespace SICO.Application.Main.IoC
{
    public class AutoMapperModule : AutoMapperBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).GetTypeInfo().Assembly)
                  .Where(t => t.IsAssignableTo<Profile>())
                  .Where(t => !t.GetTypeInfo().IsAbstract)
                  .As<Profile>()
                  .AsSelf();

            base.Load(builder);

        }
    }
}
