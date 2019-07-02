using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.RedisDB
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRedisRepository(this IServiceCollection services)
        {
            

            return services;
        }
    }
}
