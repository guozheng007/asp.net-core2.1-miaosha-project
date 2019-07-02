using AutoMapper;
using System;

namespace Spike.Utility.Mapper
{
    public class ObjectMapperWapper : Profile
    {
        public ObjectMapperWapper()
        {
            //TODO
        }

        private DateTime ConvertTime(long timestamp)
        {
            return timestamp.ConvertTimeByUnix(true);
        }

        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfiles(typeof(ObjectMapperWapper).Assembly));
        }
    }
}
