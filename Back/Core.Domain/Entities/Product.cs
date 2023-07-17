using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int CategoryID { get; set; }
        public int StateID { get; set; }
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Availability { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public double Weight { get; set;}
        public int Stock { get; set; }
        public bool Private { get; set; }
        public Category Category { get; set; }
        public State State { get; set; }
        public ICollection<Product_Rating> Product_Ratings { get; set; }
        public ICollection<Tickets> Tickets{ get; set; }
        public ICollection<Product_List> Product_Lists{ get; set; }
        public ICollection<Comment> Comments { get; set;}
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Purchased> Purchaseds{ get; set;}
        public ICollection<Product_Application> Product_Applications { get; set; }
        public ICollection<Product_Images> Product_Images { get; set; }
        
    }
}
