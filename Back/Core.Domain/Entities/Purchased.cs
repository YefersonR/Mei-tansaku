using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Purchased
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public int ProductName { get; set; }
        public int StateID { get; set; }
        public string PurchaseID { get; set; }
        public DateTime DatePurchase { get; set;}
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
