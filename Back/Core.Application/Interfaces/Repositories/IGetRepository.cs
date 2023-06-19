using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IGetRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllWithInclude(List<string> propierties);
        Task<T> GetById(int id);
    }
}
