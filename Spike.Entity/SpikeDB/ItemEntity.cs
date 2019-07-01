using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Entity
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int Sales { get; set; }
        public string Img_Url { get; set; }
    }
}
