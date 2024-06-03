using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetAllWithAsync();
        public Task<T> GetByIdWithAsync(int id);
        public Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec);
        public Task<T> GetWithSpecByIdAsync(ISpecification<T> Spec);
        public Task<int> Add(T Item);
    }
}
