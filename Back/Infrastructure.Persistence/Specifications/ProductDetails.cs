using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class ProductDetails : Specification<Product>
    {
        public ProductDetails(int Id) : base(product=>product.ID == Id)
        {
            AddInclude(product => product.Product_Images);
            AddInclude(product => product.Comments);
        }

    }
}
