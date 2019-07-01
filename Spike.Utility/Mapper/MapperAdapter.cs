using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Utility.Mapper
{
    public class MapperAdapter : IMapProvider
    {
        public TDestination MapTo<TDestination>(object source)
        {
            if (source == null)
            {
                return default(TDestination);
            }

            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}
