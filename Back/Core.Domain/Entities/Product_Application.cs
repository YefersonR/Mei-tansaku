using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product_Application
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string SellerID { get; set; }
    }
}
