using Microsoft.Extensions.Configuration;

namespace Spike.Utility
{
    public class ConfigurationManager
    {
        public static IConfiguration Configuration => FrameworkExtensions.Configuration;
    }
}
