using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;


using Spike.Utility;

namespace Spike.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => {

                    logging.AddFilter("System", LogLevel.Warning);
                    logging.AddFilter("Microsoft", LogLevel.Warning);
                    logging.AddLog4Net(@"Config\log4net.config");
                })
                .UseDefaultWebPreStart()
                .UseStartup<Startup>();
    }
}
