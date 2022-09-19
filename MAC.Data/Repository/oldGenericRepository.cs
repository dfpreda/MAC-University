using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MAC.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MacContext _context;
        private DbSet<T> table;

        public GenericRepository(MacContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Delete(object Id)
        {
            T exists = table.Find(Id);
            table.Remove(exists);
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T GetById(object Id)
        {
            return table.Find(Id);
        }

        public T Insert(T obj)
        {
            var result = table.Add(obj);
            return result.Entity;
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
