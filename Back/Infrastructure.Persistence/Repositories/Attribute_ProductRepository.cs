using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class Attribute_ProductRepository : GenericRepository<Attribute_Product>, IAttribute_ProductRepository
    {
        private readonly DBContext _dbContext;
        public Attribute_ProductRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

//        public async Task<List<Attribute_Product>> GetByCategoryID(int Id)
//        {
 //           List<Attribute_Product> response = new();
//
//            response = await _dbContext.Set<Attribute_Product>().Where(x => x.ID == Id).ToListAsync();

//            return response;
 //       }

        public async Task<bool> GetRelations(int valor, int ProductId)
        {
            var product = await _dbContext.Set<Attribute_Product>()
                .Where(x => x.Value_AttributeID == valor)
                .Where(m => m.ProductID == ProductId)
                .FirstOrDefaultAsync();

            return product != null;
        }

    }
}
