using Onion.Core.Entities;
using Onion.Core.Specifications.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /*
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        */
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec);
        Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec);

        int Add(T obj);
        int Update(T obj);
        int Delete(T obj);
    }
}
