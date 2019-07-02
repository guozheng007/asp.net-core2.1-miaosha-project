namespace Spike.Utility.Mapper
{
    public static class MapExtensions
    {
        private static IMapProvider autoMapProvider = new NullMapProvider();

        public static void UseMapProvider(this IMapProvider provider)
        {
            autoMapProvider = provider;
        }

        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            if (source is null)
            {
                return default;
            }
            return autoMapProvider.MapTo<TDestination>(source);
        }
    }
}
