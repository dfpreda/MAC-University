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
    public class ClassesController : ControllerBase
    {
        private IClassDataService _dataService;

        public ClassesController(IClassDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<ClassesController>
        [HttpGet]
        public IEnumerable<ClassDTO> Index()
        {
            return _dataService.Get();
        }

        // GET api/<ClassesController>/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return Ok(_dataService.GetById(id));
        }

        // POST api/<ClassesController>
        [HttpPost]
        public IActionResult Create([FromBody] ClassDTO item)
        {
            return Ok(_dataService.Insert(item));
        }

        // PUT api/<ClassesController>/5
        [HttpPut("{id}")]
        public void Edit([FromBody] ClassDTO item, int id)
        {
            _dataService.Update(item, id);
        }

        // DELETE api/<ClassesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataService.Delete(id);
        }
    }
}
