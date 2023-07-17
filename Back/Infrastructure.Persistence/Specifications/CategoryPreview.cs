using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class CategoryPreview : Specification<Category>
    {
        public CategoryPreview(int quantity) : base(category => !string.IsNullOrEmpty(category.Name))
        {
            Random random = new Random();
            Page = random.Next(1, 5);
            PageSize = quantity;

        }
    }
}
