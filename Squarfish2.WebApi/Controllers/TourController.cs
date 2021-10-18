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
    public class TourController : ControllerBase
    {
        ITourService tourService;
        public TourController(ITourService tourService)
        {
            this.tourService = tourService;
        }
        // GET: api/<TourController>
        [HttpGet]
        public async Task<IEnumerable<TourModel>> Get()
        {
            return await tourService.GetTours( TourModel.DefaultSearchFilters() );
        }

        // GET api/<TourController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TourController>
        [HttpPost]
        public async Task<TourModel> Post([FromBody] TourModel tour)
        {
           return await tourService.Add(tour);
        }

        [HttpPut("Confirm/{id}")]
        public async Task<bool> Confirm(int id)
        {
            return await tourService.Confirm(id);
        }

        [HttpPut("Cancel/{id}")]
        public async Task<bool> Cancel(int id)
        {
            return await tourService.Cancel(id);
        }


        // PUT api/<TourController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TourModel tour)
        {
             await tourService.Update(tour);
        }

        // DELETE api/<TourController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await tourService.Delete(id);
        }
    }
}
