using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace J25ND8_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        IPlaneLogic pl;

        public PlaneController(IPlaneLogic pl)
        {
            this.pl = pl;
        }
        [HttpGet]
        public IEnumerable<Plane> ReadAll()
        {
            return pl.ReadAll();
        }
        [HttpGet("{id}")]
        public Plane Read(int id)
        {
            return pl.Read(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
        [HttpPost]
        public void Post([FromBody] Plane plane)
        {
            pl.Create(plane);
        }
        [HttpPut]
        public void Update([FromBody] Plane plane)
        {
            pl.Update(plane);
        }
        
    }
}
