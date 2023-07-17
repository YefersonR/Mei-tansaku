using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public class GetCommentsByProduct: Specification<Comment>
    {
        public GetCommentsByProduct(int productId):
            base(comment=>comment.ProductID == productId)
        {
            AddInclude(comment => comment.Product);
            AddInclude(comment => comment.Helpfuls);
            AddOrderBy(comment => comment.LastUpdatedBy);
        }
    }
}
