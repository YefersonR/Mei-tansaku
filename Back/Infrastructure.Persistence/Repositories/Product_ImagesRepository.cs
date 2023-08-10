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
    public class Product_ImagesRepository : GenericRepository<Product_Images>, IProduct_ImagesRepository
    {
        private readonly DBContext _dbContext;
        public Product_ImagesRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetFirtImg(int productId)
        {
            var data = await _dbContext.Set<Product_Images>()
                                       .Where(x => x.ProductID == productId)
                                       .FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }

            return data.ImgUri;
        }
    }
}
