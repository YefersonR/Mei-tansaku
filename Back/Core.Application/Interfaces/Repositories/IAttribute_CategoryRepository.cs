using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IAttribute_CategoryRepository : IGenericRepository<Attribute_Category>
    {
        Task<List<Attribute_Category>> GetAttribute(int categoryID, int productId);
    }
}
