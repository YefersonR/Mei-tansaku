using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Purchased : AuditableEntity
    {
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public int ProductName { get; set; }
        //public int StateID { get; set; }
        public string PurchaseID { get; set; }
        public DateTime DatePurchase { get; set;}
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product Product { get; set; }
        //public State State { get; set; }
    }
}
