using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;

namespace J25ND8_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        IPassengerLogic pl;
        public PassengerController(IPassengerLogic pl)
        {
            this.pl = pl;
        }
        [HttpGet]
        public IEnumerable<Passenger> ReadAll()
        {
            return pl.ReadAll();
        }
        [HttpGet("{id}")]
        public Passenger Read(int id)
        {
            return pl.Read(id);
        }
        [HttpPost]
        public void Post([FromBody] Passenger passenger)
        {
            pl.Create(passenger);
        }
        [HttpPut]
        public void Update([FromBody] Passenger passenger)
        {
            pl.Update(passenger);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        { 
            pl.Delete(id);
        }
        
    }
}
