using Microsoft.EntityFrameworkCore;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository
{
    public static class SpecificationEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> SpecBuilder(IQueryable<T> StartQuery, ISpecification<T> Spec)
        {
            var Query = StartQuery;
            if (Spec.Criteria is not null)
            {
                Query = Query.Where(Spec.Criteria);
            }
            if (Spec.IsPaginationEnabled == true)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }
            Query = Spec.Includes.Aggregate(Query,(CurrentQuery,IncludeExpress)=>CurrentQuery.Include(IncludeExpress));
            return Query;
        }
    }
}
