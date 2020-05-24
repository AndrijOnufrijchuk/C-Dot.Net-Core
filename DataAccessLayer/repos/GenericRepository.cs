
using DataAccessLayer.DbContext1;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.repos
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly MyDbContext _dbcontext;

        public GenericRepository(MyDbContext dbcontext)
        { _dbcontext = dbcontext; }

        public async Task<IEnumerable<TEntity>> GetAll()
        { return await _dbcontext.Set<TEntity>().ToListAsync(); }

        public async Task<TEntity> Get(TId id)
        { return await _dbcontext.Set<TEntity>().FindAsync(id); }

        public async Task Add(TEntity entity)
        {
            _dbcontext.Add(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(TId Id)
        {
            _dbcontext.Remove(_dbcontext.Set<TEntity>().Find(Id));
            await _dbcontext.SaveChangesAsync();
        }
    }
}
