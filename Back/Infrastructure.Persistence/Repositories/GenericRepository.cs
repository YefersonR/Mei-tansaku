using Core.Application.Interfaces.Repositories;
using Core.Domain.Common;
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
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly DBContext _dbContext;
        public GenericRepository(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> Add(T type)
        {
            await _dbContext.Set<T>().AddAsync(type);
            await _dbContext.SaveChangesAsync();
            return type;
        }
        public virtual async Task Update(T Type, int id)
        {   
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext!.Entry(entity).CurrentValues.SetValues(Type);
            await _dbContext!.SaveChangesAsync();
        }
        public virtual async Task Delete(int id)
        {
            await _dbContext.Set<T>().FindAsync(id);
            await _dbContext.SaveChangesAsync();
        }
        protected IQueryable<T> ApplySpecification(Specification<T> specifications)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<T>(), specifications);
        }
    }
}
