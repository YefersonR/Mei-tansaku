using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class Product_RatingRepository : GenericRepository<Product_Rating>, IProduct_RatingRepository
    {
        private readonly DBContext _dbContext;
        public Product_RatingRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> IsRated(int productId, string userId)
        {
            var data = await _dbContext.Set<Product_Rating>()
                                       .Where(x => x.ProductID == productId)
                                       .Where(x => x.UserID == userId)
                                       .FirstOrDefaultAsync();
            if(data == null)
            {
                return 0;
            }
            return data.ID;
        }

        public async Task<int> Rating(int productId)
        {
            int response = 0;
            var data = await _dbContext.Set<Product_Rating>()
                                       .Where(x => x.ProductID == productId).ToListAsync();
            foreach(var i in data)
            {
                response += i.Rating;
            }

            response = response / data.Count();

            return response;
        }
    }
}
