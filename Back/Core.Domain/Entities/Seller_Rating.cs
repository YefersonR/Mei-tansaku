using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Seller_Rating
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string SellerID { get; set; }
        public int Rating { get; set; }
    }
}
