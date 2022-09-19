using MAC.Data.Repository;

namespace MAC.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void CommitTransaction();
        void Dispose();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();
        void RollBackTransaction();
        int SaveChanges();
    }
}