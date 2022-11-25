using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace J25ND8_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        IAirlineLogic al;
        public AirlineController(IAirlineLogic al)
        {
            this.al = al;
        }
        [HttpGet]
        public IEnumerable<Airline> ReadAll()
        {
            return al.ReadAll();
        }
        [HttpGet("{id}")]
        public Airline Read(int id)
        {
            return al.Read(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.Delete(id);
        }
        [HttpPost]
        public void Post([FromBody] Airline airline)
        {
            al.Create(airline);
        }
        [HttpPut]
        public void Update([FromBody] Airline airline)
        {
            al.Update(airline);
        }
    }
}
