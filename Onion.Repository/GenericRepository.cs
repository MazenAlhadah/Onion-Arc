using Microsoft.EntityFrameworkCore;
using Onion.Core.Entities;
using Onion.Core.Repositories;
using Onion.Core.Specifications.Specifications;
using Onion.Repository;
using Onion.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly OnionContext _dbContext;
        public GenericRepository(OnionContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Product))
                return (IEnumerable <T>) await _dbContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
            else 
                return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);
        /*

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec)
        {
            return await SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec)
        {
            return await SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec).FirstOrDefaultAsync();
        }
        */
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec)
        {
            return await  ApplySpecification(Spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec)
        {
            return await ApplySpecification(Spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> Spec) {
            return SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }

        public int Update(T obj)
        {
            _dbContext.Update(obj);
            return _dbContext.SaveChanges();
        }

        public int Add(T obj)
        {
            _dbContext.Add(obj);
            return _dbContext.SaveChanges();
        }

        public int Delete(T obj)
        {
            _dbContext.Remove(obj);
            return _dbContext.SaveChanges();
        }

    }
}




