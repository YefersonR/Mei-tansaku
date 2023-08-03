using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Application.Dtos
{
    public class Product_ListDTO
    {
        public int ShoppingListID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        //public Shopping_List Shopping_List { get; set; }
    }
}
