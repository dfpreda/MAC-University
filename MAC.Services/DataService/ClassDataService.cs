using AutoMapper;
using MAC.Data.DTO;
using MAC.Data.Entities;
using MAC.Data.UnitOfWork;
using MAC.Services.DataService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC.Services.DataService
{
    public class ClassDataService : BaseCrudDataService<ClassDTO, Class>, IClassDataService
    {
        public ClassDataService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public override void Update(ClassDTO item, int itemId)
        {
            var _class = _unitOfWork.GetRepository<Class>().SingleOrDefault(include: i => i.Include(c => c.ClassGroups), filter: x => x.Id == itemId);
            var ClassIds = item.ClassGroups.Select(s => s.GroupId);
            var GroupsToBeRemoved = _class.ClassGroups.Where(c => !ClassIds.Contains(c.GroupId));
            foreach (var group in GroupsToBeRemoved)
            {
                _class.ClassGroups.Remove(group);
            }
            _mapper.Map(item, _class);
            _unitOfWork.GetRepository<Class>().Update(_class);
            _unitOfWork.SaveChanges();
        }
    }
}
