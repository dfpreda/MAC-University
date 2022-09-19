using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MAC.Data.Repository
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _table = _context.Set<TEntity>();
        }

        #region Get Functions
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _table;
            return query;
        }

        public TEntity SingleOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table;

            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);

            return query.SingleOrDefault();
        }


        public TEntity FirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table;

            if (include != null) query = include(query);
            if (filter != null) query = query.Where(filter);

            return query.FirstOrDefault();
        }

        #endregion

        #region Insert Functions
        public virtual TEntity Insert(TEntity entity)
        {
            return _table.Add(entity).Entity;
        }

        public void Insert(params TEntity[] entities)
        {
            _table.AddRange(entities);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }
        #endregion

        #region Update Functions
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void Update(params TEntity[] entities)
        {
            _table.UpdateRange(entities);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }
        #endregion

        #region Delete Functions
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void Delete(params TEntity[] entities)
        {
            _table.RemoveRange(entities);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }
        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
