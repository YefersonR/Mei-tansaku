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
    public class Attribute_CategoryRepository : GenericRepository<Attribute_Category>, IAttribute_CategoryRepository
    {
        private readonly DBContext _dbContext;
        private readonly IValue_AttributeRepository _value_AttributeRepository;

        public Attribute_CategoryRepository(DBContext dbContext, IValue_AttributeRepository value_AttributeRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _value_AttributeRepository = value_AttributeRepository;
        }

        public async Task<List<Attribute_Category>> GetAttribute(int categoryID, int productId)
        {
            List<Attribute_Category> response = await _dbContext.Set<Attribute_Category>()
                                       .Where(x => x.CategoryID == categoryID).ToListAsync();

            foreach(var i in response)
            {
                i.Value_Attributes = await _value_AttributeRepository.GetAttribute(i.ID, productId);
            }
            return response;
        }
    }
}
