using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Entity
{
    public class PromoEntity
    {
        public int Id { get; set; }
        public string Promo_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public int Item_Id { get; set; }
        public double Promo_Item_Price { get; set; }
        public DateTime End_Date { get; set; }
    }
}
