using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spike.Utility
{
    public static class AppSetting
    {
        public readonly static string AppID = ConfigurationManager.Configuration["add:AppID:value"];
        public readonly static string EncryptKey = ConfigurationManager.Configuration["add:EncryptKey:value"];
    }
}
