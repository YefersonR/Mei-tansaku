using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IModifyRepository<T> where T : class
    {
        Task<T> Add(T type);
        Task Update(T Type, int id);
        Task Delete(int id);

    }
}
