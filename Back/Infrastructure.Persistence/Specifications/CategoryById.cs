using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class CategoryById : Specification<Category>
    {
        public CategoryById(int id) :
            base(category => category.ID == id)
        {
            AddInclude(categoty => categoty.Attribute_Categories);
        }
    }

}
