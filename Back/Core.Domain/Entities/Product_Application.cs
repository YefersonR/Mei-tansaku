using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product_Application : AuditableEntity
    {
        public int ProductID { get; set; }
        public string SellerID { get; set; }
        public Product Product { get; set; }
    }
}
