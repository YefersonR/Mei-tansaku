using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class ProductByName : Specification<Product>
    {
        public ProductByName(string name, int page = 1, int pageSize = 20)
            : base(category => string.IsNullOrEmpty(name) || category.Name.Contains(name))
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
