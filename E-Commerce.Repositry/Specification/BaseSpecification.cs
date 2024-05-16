using E_Commerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        
        public Expression<Func<T, bool>> WhereExpression  {get; }

        public BaseSpecification(Expression<Func<T, bool>> whereExpression)
        {
            WhereExpression = whereExpression;
        }

        public List<Expression<Func<T, object>>> IncludeExpression { get; } = new();

        public Expression<Func<T, object>> OrderBy { get; protected set; }

        public Expression<Func<T, object>> OrderByDesc { get; protected set; }

        public int Skip { get; protected set; }

        public int Take { get; protected set; }

        public bool ISpaginated { get; protected set; }

        protected void ApplayPagination(int pageIndex, int pageSize) 
        {
            ISpaginated  = true;
            Take = pageSize;
            Skip = (pageIndex-1)*pageSize;
        }
    }
}
