using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetPreviewCategories(int quantity);
        Task<Category> GetAllProductsByCategory(int Id, int page, int pageSize);
    }
}
