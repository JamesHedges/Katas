using System.Linq;

namespace DDD.Core.Repository
{
    public interface IRepository<TEntity, TIdType>
        where TEntity : class
    {
        //void Insert(TEntity entity);
        //void Update(TEntity entity);
        void Save(TEntity entity);
        void Delete(TIdType id);
        TEntity Get(TIdType id);
        IQueryable<TEntity> Get();
    }
}
