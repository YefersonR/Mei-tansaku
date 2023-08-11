using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IProduct_RatingRepository : IGenericRepository<Product_Rating>
    {
        Task<int> IsRated(int productId, string userId);
        Task<int> Rating(int productId);
    }
}
