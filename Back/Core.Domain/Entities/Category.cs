using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public ICollection<Attribute_Category> Attribute_Categories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
