using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DBContext _dbContext;
        private readonly IAttribute_ProductRepository _attribute_ProductRepository;

        public CategoryRepository(DBContext dbContext, IAttribute_ProductRepository attribute_ProductRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _attribute_ProductRepository = attribute_ProductRepository;
        }
        public async Task<List<Category>> GetAll() =>
            await _dbContext.Set<Category>().ToListAsync();

        public async Task<List<Category>> GetPreviewCategories(int quantity) =>
            await ApplySpecification(new CategoryPreview(quantity)).ToListAsync();

        public async Task<Category> GetAllProductsByCategory(int Id, int page, int pageSize, List<int> Values)
        {
            var category  = await ApplySpecification(new GetProductByCategory(Id)).FirstAsync();


            if(category is not null)
            {
                var productQuery =  _dbContext.Entry(category)
                    .Collection(category=>category.Products)
                    .Query()
                    .Skip((page - 1) * pageSize)
                .Take(pageSize);

                var products = await productQuery.ToListAsync();


                for (int i = Values.Count - 1; i >= 0; i--)
                {
                    for (int x = products.Count - 1; x >= 0; x--)
                    {
                        if (await _attribute_ProductRepository.GetRelations(Values[i], products[x].ID) == false)
                        {
                            products.RemoveAt(x);
                        }
                    }
                }

                category.Products = products;

            }
            return category;
        }

        public async Task<List<Category>> GetAllCategoryById(List<int> list)
        {
            List<Category> Categories = new List<Category>();
            foreach(var id in list)
            {
                Categories.Add(await ApplySpecification(new CategoryById(id)).FirstAsync());
            }
            return Categories;
        }
    }
}
