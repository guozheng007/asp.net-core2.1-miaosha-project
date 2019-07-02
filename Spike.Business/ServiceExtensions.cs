using Microsoft.Extensions.DependencyInjection;
using Spike.Utility.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Business
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //注入service
            services.AddSingleton<BusinessFacade, BusinessFacade>();

            ObjectMapperWapper.Initialize();

            return services;
        }
    }
}
