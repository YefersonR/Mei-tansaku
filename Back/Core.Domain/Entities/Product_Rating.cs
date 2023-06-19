using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product_Rating : AuditableEntity
    {
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public int Rating { get; set; }
        public Product Product { get; set; }

    }
}
