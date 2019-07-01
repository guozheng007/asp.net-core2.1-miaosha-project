using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Utility.Mapper
{
    public interface IMapProvider
    {
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TDestination MapTo<TDestination>(object source);

    }
}
