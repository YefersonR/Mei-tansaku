using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DBContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;
        public ProductRepository(DBContext dbContext, ICategoryRepository categoryRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
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


        public async Task<(List<Product>, List<Category>)> SearchProduct(string name, List<List<object>> category_attribute)
        {
            var product = ApplySpecification(new ProductByName(name)).ToList();
            var uniqueCategoryIDs = product.Select(p => p.CategoryID).Distinct().ToList();
            var categories = await _categoryRepository.GetAllCategoryById(uniqueCategoryIDs);
            return (product, categories);
        }

    }
}
