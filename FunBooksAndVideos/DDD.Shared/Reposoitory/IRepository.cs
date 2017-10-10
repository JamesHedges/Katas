namespace DDD.Shared.Repository
{
    public interface IRepository<T, I>
        where T: class
    {
        void Save(T entity);
        void Delete(I entityId);
    }
}
