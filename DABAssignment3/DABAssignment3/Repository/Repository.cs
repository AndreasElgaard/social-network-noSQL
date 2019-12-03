using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DABAssignment3.Repository
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        //private readonly MongodbClient

        public Repository()
        {

        }

        public Task<Tentity> GetAsync(int id)
        {
            
        }

        public Task<IEnumerable<Tentity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tentity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Tentity> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Tentity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesasync()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
