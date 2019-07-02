using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spike.Utility.Mapper;
using System;

namespace Spike.Utility
{
    public static class FrameworkExtensions
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static ILoggerFactory LoggerFactory { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        /// <summary>
        /// 注册各种框架
        /// </summary>
        /// <param name="services"></param>
        /// <param name="customConfiguration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFramework(this IServiceCollection services, IConfiguration customConfiguration)
        {
            services.AddSingleton(customConfiguration);
            services.AddSingleton<IMapProvider, MapperAdapter>();
            services.AddLogging(logBuilder =>
            {

                logBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
            });

            return services;
        }

        /// <summary>
        /// 配置框架
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void ConfigFramework(this IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            serviceProvider.GetService<IMapProvider>().UseMapProvider();
            LoggerFactory = serviceProvider.GetService<ILoggerFactory>();

            Configuration = serviceProvider.GetService<IConfiguration>();

            IApplicationBuilder applicationBuilder = serviceProvider.GetService<IApplicationBuilder>();
            //TODO：如果想注入管道的话，可以在这里注入，但是一定要注意注入的顺序
        }

        /// <summary>
        /// 使用默认web启动项[web应用使用]
        /// </summary>
        /// <param name="webHostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseDefaultWebPreStart(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                configBuilder.SetBasePath(AppContext.BaseDirectory)
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                             .AddXmlFile("Config/Database.Dev.config", optional: false, reloadOnChange: true)
                             .AddXmlFile("Config/AppSetting.Dev.config", optional: false, reloadOnChange: true)
                             .AddEnvironmentVariables();


                hostContext.Configuration = configBuilder.Build();

                Configuration = configBuilder.Build();
            })
            .ConfigureServices(services =>
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            });

            return webHostBuilder;
        }
    }
}
