using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IShopping_ListRepository : IGenericRepository<Shopping_List>
    {
        Task<Shopping_List> GetAll (int Id);

    }
}
