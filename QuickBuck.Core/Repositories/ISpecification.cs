using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Repositories
{
    public interface ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>> Criteria { get; set; }
        public List<Expression<Func<T,object>>> Includes { get; set; }
        public Expression<Func<T,object>> OrderBy { get; set; }
        public Expression<Func<T,object>> OrderByDescending { get; set; }
        public Expression<Func<T,object>> Reverse { get; set; }
        public Expression<Func<T,int>> Distinct { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }
    }
}
