using Microsoft.AspNetCore.Mvc;
using Squarfish2.Business.Abstraction;
using Squarfish2.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Squarfish2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourLeaderController : ControllerBase
    {
        ILeaderService tourLeaderService;
        public TourLeaderController(ILeaderService tourLeaderService)
        {
            this.tourLeaderService = tourLeaderService;
        }

        // GET: api/<TourLeaderController>
        [HttpGet]
        public async Task<IEnumerable<LeaderModel>> Get()
        {
            return await tourLeaderService.GetAll();
        }

        // GET api/<TourLeaderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TourLeaderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TourLeaderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TourLeaderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
