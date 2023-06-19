using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IGetRepository<T>, IModifyRepository<T> where T : class
    {

    }
}
