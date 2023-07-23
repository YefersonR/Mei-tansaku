using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Attribute_Product : AuditableEntity
    {
        public int Value_AttributeID { get; set; }
        public int ProductID { get; set; }


        public Value_Attribute Value_Attribute { get; set; }
        public Product Product { get; set; }
    }
}
