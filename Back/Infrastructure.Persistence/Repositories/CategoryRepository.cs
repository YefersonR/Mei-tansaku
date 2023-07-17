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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DBContext _dbContext;
        public CategoryRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Category>> GetAll() =>
            await _dbContext.Set<Category>().ToListAsync();

        public async Task<List<Category>> GetPreviewCategories(int quantity) =>
            await ApplySpecification(new CategoryPreview(quantity)).ToListAsync();

        public async Task<Category> GetAllProductsByCategory(int Id, int page, int pageSize)
        {
            var category  = await ApplySpecification(new GetProductByCategory(Id)).FirstAsync();

            if(category is not null)
            {
                var productQuery =  _dbContext.Entry(category)
                    .Collection(category=>category.Products)
                    .Query()
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

                category.Products = await productQuery.ToListAsync();

            }
            return category;
        }
    }
}
