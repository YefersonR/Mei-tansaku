using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Specifications
{
    public abstract class Specification<T> where T:class
    {
        protected Specification(Expression<Func<T,bool>>? criteria)=>
            Criteria = criteria;
        public int Page { get; protected set; } = 1;
        public int PageSize { get; protected set; } = 20;
        public Expression<Func<T,bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();
        public Expression<Func<T,object>>? OrderByExpression { get; private set; }
        public Expression<Func<T,object>>? OrderByDescendingExpression { get; private set; }

        protected void AddInclude(Expression<Func<T,object>> includeExpression) =>
            IncludeExpressions.Add(includeExpression);
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) =>
            OrderByExpression = orderByExpression;
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) =>
            OrderByDescendingExpression = orderByDescendingExpression;
    }
}
