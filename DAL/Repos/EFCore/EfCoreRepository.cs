using heroesCompany.Models.HelperModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompany.Data.EFCore {
    public class EfCoreRepository<T> : IEfCoreRepository<T> where T : class, Ientity {
        protected DbContext _context;
        public EfCoreRepository(DbContext context) {
            _context = context;
        }

        public IQueryable<T> entities => _context.Set<T>();

        public async Task AddAsync(T entity) {
            await _context.Set<T>().AddAsync(entity);
        }

        public IEnumerable<T> Find(T entityToFind) {
            return entities.Where<T>(entity => entity == entityToFind);
        }

        public async Task<List<T>> GetAllAsync() {
            return await entities.ToListAsync();
        }

        public IQueryable<T> GetAsync(Guid id) {
            return entities.Where(entity => entity.Id == id);
        }

        public void Remove(T entity) {
            _context.Remove(entity);
        }
    }
}
