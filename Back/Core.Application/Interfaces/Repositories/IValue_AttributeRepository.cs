using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IValue_AttributeRepository : IGenericRepository<Value_Attribute>
    {
        Task<List<Value_Attribute>> GetByAttributeCategoryID(int Id);
        Task<List<Value_Attribute>> GetAttribute(int CategoryId, int ProductId);
    }
}
