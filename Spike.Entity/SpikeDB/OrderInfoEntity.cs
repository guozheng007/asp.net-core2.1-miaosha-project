using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Entity
{
    public class OrderInfoEntity
    {
        public string Id { get; set; }
        public int User_Id { get; set; }
        public int ItemId { get; set; }
        public double Item_Price { get; set; }
        public int Amount { get; set; }

        public double Order_Price { get; set; }
        public int Promo_Id { get; set; }
    }
}
