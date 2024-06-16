using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Repositories
{
    public class BaseSpecification<T> : ISpecification<T> where T: BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public int Skip { get ; set ; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public Expression<Func<T,object>> Reverse { get; set; }
        public Expression<Func<T,int>> Distinct { get; set; }

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> CriteriaExpression)
        {
            Criteria = CriteriaExpression;
        }
        public void ApplyPagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaginationEnabled= true;
        }
        public void ApplyOrderBy(Expression<Func<T,object>> orderByExp)
        {
            OrderBy = orderByExp;
        }
        public void ApplyOrderByDesc(Expression<Func<T, object>> orderByExp)
        {
            OrderByDescending = orderByExp;
        }
        public void ApplyOrderByDescWithReverse(Expression<Func<T,object>> orderByExp, Expression<Func<T, object>> reverse)
        {
            OrderByDescending = orderByExp;
            Reverse = reverse;
        }
        public void DistinctBy( Expression<Func<T,int>> distinct)
        {
            Distinct=distinct;
        }
    }
}
