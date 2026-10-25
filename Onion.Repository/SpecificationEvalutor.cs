using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Onion.Core.Entities;
using Onion.Core.Specifications.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Repository
{
    public class SpecificationEvalutor<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec) {
            var Query = inputQuery; // _dbcontext.Set<T>();
            if (spec.Criteria is not null) {
                Query = Query.Where(spec.Criteria);
            }
            Query = spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            return Query;
        }
    }
}
