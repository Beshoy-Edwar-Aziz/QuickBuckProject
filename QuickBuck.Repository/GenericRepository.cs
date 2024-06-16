using Microsoft.EntityFrameworkCore;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly QuickBuckContext _dbContext;

        public GenericRepository(QuickBuckContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(T Item)
        {
            await _dbContext.Set<T>().AddAsync(Item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithAsync()
        {
            if (typeof(T) == typeof(JobSeeker))
            {
                return (IReadOnlyList<T>) await _dbContext.JobSeekers.Include(j => j.Skills).Include(j=>j.AppUser).ToListAsync();
            }
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec)
        {
            return await GetSpec(Spec).ToListAsync();
        }

        public async Task<T> GetByIdWithAsync(int id)
        {
            return await _dbContext.Set<T>().Where(s=>s.Id==id).FirstOrDefaultAsync();
        }

        public async Task<T> GetWithSpecByIdAsync(ISpecification<T> Spec)
        {
            return await GetSpec(Spec).FirstOrDefaultAsync();
        }

        public async Task Update(T Item)
        {
            _dbContext.Update(Item);
           await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> GetSpec(ISpecification<T> Spec)
        {
           return SpecificationEvaluator<T>.SpecBuilder(_dbContext.Set<T>(), Spec);
        }
    }
}
