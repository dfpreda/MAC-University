using MAC.Data;
using MAC.Data.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using MAC.Data.UnitOfWork;

namespace MAC.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MacContext _context;
        private IDbContextTransaction _transaction;
        private Dictionary<(Type type, string Name), IDisposable> _repositories;

        public UnitOfWork(MacContext context)
        {
            _repositories = new Dictionary<(Type type, string Name), IDisposable>();
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            return (IGenericRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new GenericRepository<TEntity>(_context));
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _context.Database.BeginTransaction();
            }
            else
            {
                throw new Exception("Transaction already in progress");
            }
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("No transaction to commit");
            }

            _transaction.Commit();
            _transaction.Dispose();
        }

        public void RollBackTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("no transaction to rollback");
            }

            _transaction.Rollback();
            _transaction.Dispose();
        }

        private IDisposable GetOrAddRepository(Type type, IDisposable repo)
        {
            var typeName = repo.GetType().FullName;
            if (_repositories.TryGetValue((type, typeName), out var repository))
            {
                return repository;
            }

            _repositories.Add((type, typeName), repo);

            return repo;
        }

        public void Dispose()
        {
            if (_repositories != null)
            {
                foreach (var key in _repositories.Keys)
                {
                    _repositories[key].Dispose();
                }
            }
            _repositories = null;
            _context?.Dispose();
        }
    }
}
