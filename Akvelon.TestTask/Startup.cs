
using System;
using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.Infrastructure.DependenciesModules;
using Akvelon.TestTask.Infrastructure.MappingProfiles;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Akvelon.TestTask
{
    /// <summary>
    /// Application configure class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            
            // CORS configuration
            services.AddCors(o =>
                o.AddPolicy("MyPolicy", newBuilder =>
                {
                    newBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                }));

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });

            // Automapper configuration
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductsConfig());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Entity framework context configuration
            var connection = Configuration.GetConnectionString(@"AdventureWorks2014Connection");
            services.AddDbContext<AdventureWorks2014Context>(options => options.UseSqlServer(connection));

            // Autofac configuration
            var builder = new ContainerBuilder();

            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<DataAccessLayerModule>();

            builder.Populate(services);
            var container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseCors("MyPolicy");
        }
    }
}
