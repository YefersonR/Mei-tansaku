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
    public class Shopping_ListRepository : GenericRepository<Shopping_List>, IShopping_ListRepository

    {
        private readonly DBContext _dbContext;
        public Shopping_ListRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Shopping_List> GetAll(int Id)
        {
            return await _dbContext.Set<Shopping_List>()
                .Include(x => x.Product_Lists)
                .FirstAsync(x => x.ID == Id);
        }

        public async Task<List<Shopping_List>> GetAllByUserID(string Id)
        {
            return await _dbContext.Set<Shopping_List>().Where(x => x.UserID == Id).ToListAsync();
        }
    }
}
