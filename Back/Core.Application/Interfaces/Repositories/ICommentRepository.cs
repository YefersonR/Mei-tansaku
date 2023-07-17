using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetAllCommentByProduct(int productId);
        Task<Comment> GetByID(int Id);
    }
}
