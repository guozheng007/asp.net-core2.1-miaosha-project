using Microsoft.Extensions.DependencyInjection;


using Spike.DataContracts;
using Spike.MySQLDB.SpikeDB;

namespace Spike.MySQLDB
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddMySQLRepository(this IServiceCollection services)
        {
            services.AddSingleton<ISpikeDBCMDRepository, SpikeDBCMD>();
            services.AddSingleton<ISpikeDBQueryRepository, SpikeDBQuery>();
            services.AddSingleton<SpikeDBFacade, SpikeDBFacade>();

            return services;
        }
    }
}
