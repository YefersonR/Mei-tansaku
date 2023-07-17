using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class GetProductByCategory : Specification<Category>
    {
        public GetProductByCategory(int id) : 
            base(category=> category.ID == id)
        {
            AddInclude(categoty => categoty.Products);
        }
    }
}
