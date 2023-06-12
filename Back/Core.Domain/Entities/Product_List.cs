using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product_List
    {
        public int ID { get; set; }
        public int ShoppingListID { get; set; }
        public int ProductID { get; set; }
    }
}
