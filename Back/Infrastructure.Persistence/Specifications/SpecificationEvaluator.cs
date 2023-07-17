using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQueryable, Specification<T> specification) where T:class
        {
            IQueryable<T> query = inputQueryable;

            if(specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }
            query = specification.IncludeExpressions.Aggregate(
                query, 
                (current,includeExpression) => 
                    current.Include(includeExpression).AsQueryable());

            if(specification.OrderByExpression is not null)
            {
                query= query.OrderBy(specification.OrderByExpression);
            }
            else if(specification.OrderByDescendingExpression is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescendingExpression);
            }

            query = query.Skip((specification.Page - 1) * specification.PageSize)
                .Take(specification.PageSize);

            return query;

        }
    }
}
