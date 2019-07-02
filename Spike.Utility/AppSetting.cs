namespace Spike.Utility
{
    public static class AppSetting
    {
        public static readonly string AppID = ConfigurationManager.Configuration["section:section0:key:AppID"];
        public static readonly string EncryptKey = ConfigurationManager.Configuration["section:section0:key:EncryptKey"];
    }
}
