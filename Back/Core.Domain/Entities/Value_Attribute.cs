using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Value_Attribute : AuditableEntity
    {
        public int AttributeCategoryID{ get; set; }
        public string Value { get; set; }
        public Attribute_Category Attribute_Category { get; set; }
    }
}
