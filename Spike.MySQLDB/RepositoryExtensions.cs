using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.MySQLDB
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddMySQLRepository(this IServiceCollection services)
        {
            //services.AddSingleton<ISqlExampleRepository, MySqlExampleRepository>(); //示例
            //services.AddSingleton<INoSqlExampleRepository, MongoDbExampleRepository>(); //示例

            return services;
        }
    }
}
