using AutoMapper;
using MAC.Data.Abstractions;
using MAC.Data.Repository;
using MAC.Data.UnitOfWork;
using MAC.Services.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC.Services.DataService
{
    public class BaseCrudDataService<TDto, TEntity> : IBaseCrudDataService<TDto, TEntity> where TDto : class, new()
                                                                                          where TEntity : class, IGenericIdAbstraction, new()
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public BaseCrudDataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<TDto> Get()
        {
            var result = _unitOfWork.GetRepository<TEntity>().GetAll();
            return result.Select(x => _mapper.Map<TDto>(x));
        }

        public TDto GetById(int itemId)
        {
            var result = _unitOfWork.GetRepository<TEntity>().FirstOrDefault(filter: x => x.Id == itemId);
            return _mapper.Map<TDto>(result);
        }

        public virtual TDto Insert(TDto item)
        {
            TEntity entity = _mapper.Map<TEntity>(item);
            TEntity result = _unitOfWork.GetRepository<TEntity>().Insert(entity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<TDto>(result);
        }

        public virtual void Update(TDto item, int itemId)
        {
            TEntity entity = _unitOfWork.GetRepository<TEntity>().FirstOrDefault();
            _mapper.Map(item, entity);
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int itemId)
        {
            var entity = _unitOfWork.GetRepository<TEntity>().FirstOrDefault(filter: x => x.Id ==itemId);
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
            _unitOfWork.SaveChanges();
        }
        protected IGenericRepository<TEntity> GetRepository()
        {
            return _unitOfWork.GetRepository<TEntity>();
        }
    }
}
