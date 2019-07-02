namespace Spike.Utility.Mapper
{
    public class NullMapProvider : IMapProvider
    {
        public TDestination MapTo<TDestination>(object source)
        {
            return default;
        }
    }
}
