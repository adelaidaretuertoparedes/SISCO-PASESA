using Autofac;
using AutoMapper;
using System.Collections.Generic;

namespace SICO.Application.Core
{
    public abstract  class AutoMapperBaseModule : Module
    { 
        protected override void Load(ContainerBuilder builder)
        {           

            builder.Register(context =>
            {
                var profiles = context.Resolve<IEnumerable<Profile>>();

                var config = new MapperConfiguration(x =>
                {
                    // Load in all our AutoMapper profiles that have been registered
                    foreach (var profile in profiles)
                    {
                        x.AddProfile(profile);
                    }
                });

                return config;
            }).SingleInstance() // We only need one instance
            .AutoActivate() // Create it on ContainerBuilder.Build()
            .AsSelf(); // Bind it to its own type

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper(ctx.Resolve))
                .As<IMapper>()
                .SingleInstance();         

            base.Load(builder);
        }
    }
}
