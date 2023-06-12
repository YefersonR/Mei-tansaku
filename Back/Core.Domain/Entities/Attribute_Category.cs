using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Attribute_Category
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
