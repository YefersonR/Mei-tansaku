using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Attribute_Category : AuditableEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

        public ICollection<Value_Attribute> Value_Attributes { get; set; }
    }
}
