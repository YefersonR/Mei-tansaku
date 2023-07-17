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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly DBContext _dbContext;
        public CommentRepository(DBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Comment>> GetAllCommentByProduct(int productId) =>
            await ApplySpecification(new GetCommentsByProduct(productId)).ToListAsync();
        

        public async Task<Comment> GetByID(int Id)
        {
            return await _dbContext.Set<Comment>()
                .Include(comment=>comment.Helpfuls)
                .FirstAsync(comment=>comment.ID == Id);
        }
    }
}
