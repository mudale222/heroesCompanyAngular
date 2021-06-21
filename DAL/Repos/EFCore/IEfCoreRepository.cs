using heroesCompany.Models.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompany.Data {
    public interface IEfCoreRepository<T> where T : class, Ientity {
        IQueryable<T> entities { get; }
        Task AddAsync(T entity);
        IQueryable<T> GetAsync(Guid id);
        Task<List<T>> GetAllAsync();
        void Remove(T entity);
        IEnumerable<T> Find(T entity);
    }
}
