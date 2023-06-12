using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Value_Attribute
    {
        public int ID { get; set; }
        public int AttributeCategoryID{ get; set; }
        public string Value { get; set; }
    }
}
