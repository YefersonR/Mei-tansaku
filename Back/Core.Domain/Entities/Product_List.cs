using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product_List : AuditableEntity
    {
        public int ShoppingListID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public Shopping_List Shopping_List { get; set; }
    }
}
