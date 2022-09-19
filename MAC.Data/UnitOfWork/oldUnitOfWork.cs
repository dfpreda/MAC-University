using MAC.Data.Entities;
using MAC.Data.Repository;

namespace MAC.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MacContext _context;

        public UnitOfWork(MacContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}