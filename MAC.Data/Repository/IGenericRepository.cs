using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MAC.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        void Delete(IEnumerable<TEntity> entities);
        void Delete(params TEntity[] entities);
        void Delete(TEntity entity);
        void Dispose();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        IQueryable<TEntity> GetAll();
        void Insert(IEnumerable<TEntity> entities);
        void Insert(params TEntity[] entities);
        TEntity Insert(TEntity entity);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        void Update(IEnumerable<TEntity> entities);
        void Update(params TEntity[] entities);
        void Update(TEntity entity);
    }
}