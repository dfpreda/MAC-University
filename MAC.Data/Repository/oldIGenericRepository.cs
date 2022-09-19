using System.Collections.Generic;

namespace MAC.Data.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        T Insert(T obj);
        void Update(T obj);
        void Delete(object Id);
    }
}
