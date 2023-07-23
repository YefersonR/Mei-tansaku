using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class Attribute_ProductById : Specification<Attribute_Product>
    {
        public Attribute_ProductById(int id) :
            base(x => x.Value_AttributeID == id)
        {
        }
    }

}
