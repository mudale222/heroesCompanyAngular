using Md_exercise.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.Data {
    public interface IEfCoreRepository<T> where T : class,Ientity {
        IQueryable<T> entities { get; }
        Task AddAsync(T entity);
        IQueryable<T> GetAsync(Guid id);
        Task<List<T>> GetAllAsync();
        void Remove(T entity);
        IEnumerable<T> Find(T entity);
    }
}
