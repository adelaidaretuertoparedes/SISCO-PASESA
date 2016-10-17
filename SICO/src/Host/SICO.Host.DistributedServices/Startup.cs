using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Autofac;
using SICO.Infrastructure.Data.Main.Contexts;
using SICO.DistributedServices.Main.Controllers;
using SICO.Infrastructure.Data.Core;
using Autofac.Extensions.DependencyInjection;
using System;
using SICO.Infrastructure.CrossCutting.Security;
using SICO.Infrastructure.CrossCutting.Validations;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using SICO.Infrastructure.CrossCutting.ExceptionHandling;

namespace SICO.Host.DistributedServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory logger)
        {
            LoggerFactory = logger;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; private set; }

        /// <summary>
        /// Gets the <see cref="ILoggerFactory"/> instance.
        /// </summary>
        public ILoggerFactory LoggerFactory { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IDataContextAsync), (_) => {
                var mainContext = new MainContext(Configuration.GetConnectionString("DefaultConnection"));
                //mainContext.Database.Log
                mainContext.Database.Log = Console.Write;
                return mainContext;
            });
            

            services.AddMvc(options=> {
                options.Filters.Add(new GlobalExceptionFilter(LoggerFactory));
                options.Filters.Add(new ModelStateValidationFilter());
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            })
            .AddApplicationPart(typeof(TrademarkController).Assembly)
            .AddControllersAsServices();

            
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            //corsBuilder.AllowCredentials();            

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });

            var builder = new ContainerBuilder();
            //Register services module Main of application layer
            builder.RegisterModule<Application.Main.IoC.ApplicationServiceModule>();

            //Register automapper profile on module main of application layer
            builder.RegisterModule<Application.Main.IoC.AutoMapperModule>();

            //Register validator Dtos on module main of application layer
            builder.RegisterModule<Application.Main.IoC.ValidationModule>();

            //Register repositories
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(Repository<>));           
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();

            //Regisater services por current user
            services.AddTransient<IUserIdentity,UserIdentity>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowAll");
            app.UseMvc();
            //app.UseCors("AllowAll");
            

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
