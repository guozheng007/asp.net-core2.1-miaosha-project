using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Utility.Mapper
{
    public class NullMapProvider : IMapProvider
    {
        public TDestination MapTo<TDestination>(object source)
        {
            return default(TDestination);
        }
    }
}
