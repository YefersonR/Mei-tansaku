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
    public class Value_AttributesRepository : GenericRepository<Value_Attribute>, IValue_AttributeRepository
    {
        private readonly DBContext _dbContext;
        public Value_AttributesRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Value_Attribute>> GetByAttributeCategoryID(int Id)
        {
            var x = _dbContext.Set<Value_Attribute>()
                .Where(x => x.AttributeCategoryID == Id).ToList();
                return x;
        }
    }
}
