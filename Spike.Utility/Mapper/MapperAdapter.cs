namespace Spike.Utility.Mapper
{
    public class MapperAdapter : IMapProvider
    {
        public TDestination MapTo<TDestination>(object source)
        {
            if (source == null)
            {
                return default;
            }

            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}
