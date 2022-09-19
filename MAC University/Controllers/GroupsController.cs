using MAC.Data.DTO;
using MAC.Data.Entities;
using MAC.Services.DataService.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupsController : ControllerBase
    {
        readonly IBaseCrudDataService<GroupDTO, Group> _dataService;

        public GroupsController(IBaseCrudDataService<GroupDTO, Group> dataService)
        {
            _dataService = dataService;
        }
        // GET: api/<GroupsController>
        [HttpGet]
        public IEnumerable<GroupDTO> Index()
        {
            return _dataService.Get();
        }

        // GET api/<GroupsController>/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return Ok(_dataService.GetById(id));
        }

        // POST api/<GroupsController>
        [HttpPost]
        public IActionResult Create([FromBody] GroupDTO item)
        {
            return Ok(_dataService.Insert(item));
        }

        // PUT api/<GroupsController>/5
        [HttpPut("{id}")]
        public void Edit([FromBody] GroupDTO item, int id)
        {
            _dataService.Update(item, id);
        }

        // DELETE api/<GroupsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataService.Delete(id);
        }
    }
}
