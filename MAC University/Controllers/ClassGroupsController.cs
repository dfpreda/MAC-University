using MAC.Data.DTO;
using MAC.Data.Entities;
using MAC.Services.DataService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassGroupsController : ControllerBase
    {
        readonly IBaseCrudDataService<ClassGroupDTO, ClassGroup> _dataService;

        public ClassGroupsController(IBaseCrudDataService<ClassGroupDTO, ClassGroup> dataService)
        {
            _dataService = dataService;
        }
        // GET: api/<ClassGroupsController>
        [HttpGet]
        public IEnumerable<ClassGroupDTO> Index()
        {
            return _dataService.Get();
        }

        // GET api/<ClassGroupsController>/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return Ok(_dataService.GetById(id));
        }

        // POST api/<ClassGroupsController>
        [HttpPost]
        public IActionResult Create([FromBody] ClassGroupDTO item)
        {
            return Ok(_dataService.Insert(item));
        }

        // PUT api/<ClassGroupsController>/5
        [HttpPut("{id}")]
        public void Edit([FromBody] ClassGroupDTO item, int id)
        {
            _dataService.Update(item, id);
        }

        // DELETE api/<ClassGroupsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataService.Delete(id);
        }
    }
}
