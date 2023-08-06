using Azure.Core;
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
        private readonly IAttribute_ProductRepository _attribute_ProductRepository;

        public ProductRepository(DBContext dbContext, ICategoryRepository categoryRepository, IAttribute_ProductRepository attribute_ProductRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
            _attribute_ProductRepository = attribute_ProductRepository;
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


        public async Task<(List<Product>, List<Category>)> SearchProduct(string name, List<int> category_attribute)
        {
            var product = ApplySpecification(new ProductByName(name)).ToList();
            for (int i = category_attribute.Count - 1; i >= 0; i--)
            {
                for (int x = product.Count - 1; x >= 0; x--)
                {
                    if (await _attribute_ProductRepository.GetRelations(category_attribute[i], product[x].ID) == false)
                    {
                        product.RemoveAt(x);
                    }
                }
            }

            var uniqueCategoryIDs = product.Select(p => p.CategoryID).Distinct().ToList();
            var categories = await _categoryRepository.GetAllCategoryById(uniqueCategoryIDs);
            return (product, categories);
        }

        public async Task<Product> GetProductInfo(int id)
        {
            return await _dbContext.Set<Product>().Where(x => x.ID == id).FirstAsync();
        }

    }
}
