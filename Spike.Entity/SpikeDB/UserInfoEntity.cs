using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Entity
{
    public class UserInfoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public sbyte Gender { get; set; }
        public int Age { get; set; }
        public string Telphone { get; set; }
        public string Register_Mode { get; set; }
        public string Third_Party_Id { get; set; }
    }
}
