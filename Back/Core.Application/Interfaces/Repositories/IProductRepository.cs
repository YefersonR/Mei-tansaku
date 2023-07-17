using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductDetails(int id, int commentsPage, int commentsPageSize = 10);
        Task<Product> GetProductByName(string name);
    }
}
