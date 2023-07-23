using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IAttribute_ProductRepository : IGenericRepository<Attribute_Product>
    {
        Task<bool> GetRelations(int valor, int Id);
    }
}
