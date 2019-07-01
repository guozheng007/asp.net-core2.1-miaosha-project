using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Utility.Mapper
{
    public class ObjectMapperWapper: Profile
    {
        public ObjectMapperWapper()
        {
           
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
