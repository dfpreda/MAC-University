using MAC.Data.Abstractions;
using System.Collections.Generic;

namespace MAC.Services.DataService.Interfaces
{
    public interface IBaseCrudDataService<TDto, TEntity> where TDto : class, new()
                                                         where TEntity : class, IGenericIdAbstraction, new()
    {
        void Delete(int itemId);
        IEnumerable<TDto> Get();
        TDto GetById(int itemId);
        TDto Insert(TDto item);
        void Update(TDto item, int itemId);
    }
}