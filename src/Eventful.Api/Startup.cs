using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Eventful.DataAccess.Extensions;
using Eventful.Logic.Extensions;
using System.Net;
using FluentValidation.AspNetCore;
using Eventful.Common.Configurations;

namespace Eventful.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Configurations
            services.Configure<EventfulOptions>(Configuration.GetSection("Eventful"));

            // Add Layers
            services.AddEventfulLogicLayer();
            services.AddEventfulDataAccessLayer();

            // Setup Mappings
            Mappings.Mapping.ConfigureMap();

            // Add framework services.
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            })
            //Add Validations
            .AddFluentValidation(fv =>
             {
                 fv.RegisterValidatorsFromAssemblyContaining<Contract.V1.Validators.SearchEventsRequestValidator>();
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandler(
                appBuilder => appBuilder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync("An error has occurred on the server. Please try again later");
                    })
                );

            app.UseMvc();
        }
    }
}