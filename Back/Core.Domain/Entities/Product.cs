using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int StateID { get; set; }
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Availability { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public bool State { get; set; }
        public double Weight { get; set;}
        public int Stock { get; set; }
        public bool Private { get; set; }
    }
}
