using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;


using Newtonsoft.Json.Serialization;
using Spike.Business;
using Spike.MySQLDB;
using Spike.RedisDB;
using Spike.Utility;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Spike.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFramework(Configuration)
                    .AddMySQLRepository()
                    .AddRedisRepository()
                    .AddBusinessServices();

            services.AddMvc(options=> {
                    options.Conventions.Insert(0, new NameSpaceVersionRoutingConvention());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options=> {

                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });


            AddSwaggerService(services);
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IApplicationLifetime lifetime, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ConfigSwagger(app);
            IServiceProvider serviceProvider = app.ApplicationServices;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();//启用静态资源
            app.UseMvc();

            serviceProvider.ConfigFramework();
        }

        /// <summary>
        /// 注入的实现ISwaggerProvider使用默认设置
        /// </summary>
        /// <param name="services"></param>
        private void AddSwaggerService(IServiceCollection services)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string xmlPath = $"{PlatformServices.Default.Application.ApplicationBasePath}{assemblyName}.xml";
            if (File.Exists(xmlPath))
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = assemblyName, Version = "v1" });

                    c.IncludeXmlComments(xmlPath);
                });
            }
        }

        private void ConfigSwagger(IApplicationBuilder app)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string xmlPath = $"{PlatformServices.Default.Application.ApplicationBasePath}{assemblyName}.xml";
            if (File.Exists(xmlPath))
            {
                app.UseSwagger(); 
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spike Contacts API V1"); });
            }
        }
    }
}
