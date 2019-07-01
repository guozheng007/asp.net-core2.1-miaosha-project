using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Entity
{
    public class UserPasswordEntity
    {
        public int Id { get; set; }
        public string Encrpt_Password { get; set; }
        public int User_Id { get; set; }
    }
}
