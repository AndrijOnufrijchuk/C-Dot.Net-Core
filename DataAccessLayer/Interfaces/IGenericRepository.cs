using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TId Id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TId id);
    }
}
