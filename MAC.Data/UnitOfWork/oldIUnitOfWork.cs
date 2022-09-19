using MAC.Data.Repository;

namespace MAC.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
