using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DABAssignment3.Repository
{
    interface IRepository<Tentity> where Tentity : class
    {
        Task<Tentity> GetAsync(int id);
        Task<IEnumerable<Tentity>> GetAllAsync();
        IEnumerable<Tentity> Find(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(Tentity entity);
        Task AddRangeAsync(IEnumerable<Tentity> entities);

        void Remove(int id);
        void RemoveRange(IEnumerable<Tentity> entities);

        void Update(Tentity entity);

        Task SaveChangesasync();
        void SaveChanges();
    }
}
