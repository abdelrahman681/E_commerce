using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Specification
{
    public class SpecificationEvaluator<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> QueryBuild(IQueryable<TEntity> inquery,ISpecification<TEntity> specification)
        {
            var query = inquery;
            
            if(specification.WhereExpression is not null) 

              query=query.Where(specification.WhereExpression);

                if(specification.OrderBy is  not null)
                    query=query.OrderBy(specification.OrderBy);
                if(specification.OrderByDesc is not null)
                    query=query.OrderByDescending(specification.OrderByDesc);

                if (specification.ISpaginated )
                {
                    query=query.Take(specification.Take).Skip(specification.Skip);
                }

               if(specification.IncludeExpression.Any())
                    foreach (var item in specification.IncludeExpression)
                        query = query.Include(item);

                //query =specification.IncludeExpression.Aggregate(query, (currentquery, expression) => currentquery.Include(expression));
            return query;
        }
    }
}
