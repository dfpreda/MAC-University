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
    public class BadgesController : ControllerBase
    {
        private IBaseCrudDataService<BadgeDTO, Badge> _dataService;

        public BadgesController(IBaseCrudDataService<BadgeDTO, Badge> dataService)
        {
            _dataService = dataService;
        }
        // GET: api/<BadgesController>
        [HttpGet]
        public IEnumerable<BadgeDTO> Index()
        {
            return _dataService.Get();
        }

        // GET api/<BadgesController>/5
        [HttpGet("{id}", Name = "getbadgebyid")]
        public ActionResult Details(int id)
        {
            return Ok(_dataService.GetById(id));
        }

        // POST api/<BadgesController>
        [HttpPost]
        public IActionResult Create([FromBody] BadgeDTO item)
        {
            return Ok(_dataService.Insert(item));
        }

        // PUT api/<BadgesController>/5
        [HttpPut("{id}")]
        public void Edit([FromBody] BadgeDTO item, int id)
        {
            _dataService.Update(item, id);
        }

        // DELETE api/<BadgesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataService.Delete(id);
        }
    }
}
