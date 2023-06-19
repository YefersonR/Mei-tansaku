using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T:class 
    {
        private readonly DBContext _dbContext;
        public GenericRepository(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public virtual async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<List<T>> GetAllWithInclude(List<string> properties)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext!.Set<T>().FindAsync(id);
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
            _dbContext?.Entry(entity).CurrentValues.SetValues(Type);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task Delete(int id)
        {
            await _dbContext.Set<T>().FindAsync(id);
            await _dbContext.SaveChangesAsync();
        }
    }
}
