using Core.Application.Interfaces;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T:class 
    {
        private readonly DBContext _dbContext;
        public GenericRepository(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
