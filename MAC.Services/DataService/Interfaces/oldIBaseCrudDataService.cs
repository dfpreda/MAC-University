using System.Collections.Generic;

namespace MAC.Services.DataService.Interfaces
{
    public interface IBaseCrudDataService<TDto, TEntity> where TEntity : class
                                                         where TDto : class
    {
        void Delete(int itemId);
        IEnumerable<TDto> Get();
        TDto GetById(int itemId);
        TDto Insert(TDto item);
        void Update(TDto item, int itemId);
    }
}