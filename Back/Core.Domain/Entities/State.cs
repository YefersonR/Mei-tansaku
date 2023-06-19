using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class State : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        //public ICollection<Purchased> Purchaseds { get; set; }
    }
}
