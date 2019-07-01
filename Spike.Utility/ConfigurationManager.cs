using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Utility
{
    public class ConfigurationManager
    {
        public static IConfiguration Configuration => FrameworkExtensions.Configuration;
    }
}
