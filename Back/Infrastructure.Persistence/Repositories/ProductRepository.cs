
using Azure;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DBContext _dbContext;
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductDetails(int id, int commentsPage, int commentsPageSize=10)
        {
            var product =  await ApplySpecification(new ProductDetails(id)).FirstAsync();
            if(product is not null)
            {
                var commentQuery = _dbContext.Entry(product)
                .Collection(comment => comment.Comments)
                .Query()
                .Include(comment=>comment.Helpfuls)
                .OrderBy(comment=>comment.LastUpdatedDate)
                .Skip((commentsPage - 1) * commentsPageSize)
                .Take(commentsPageSize);

                product.Comments = await commentQuery.ToListAsync();

            }
            return product;
        }

        public async Task<Product> GetProductByName(string name) =>
            await ApplySpecification(new ProductByName(name)).FirstAsync();
    }
}
