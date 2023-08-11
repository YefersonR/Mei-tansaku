using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IProduct_ImagesRepository : IGenericRepository<Product_Images>
    {
        Task<string> GetFirtImg(int productId);
        Task<List<string>> GetImgByProductID(int productId);
    }
}
