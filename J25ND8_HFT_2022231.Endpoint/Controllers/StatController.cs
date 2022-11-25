using J25ND8_HFT_2022231.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace J25ND8_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPlaneLogic pl;
        IPassengerLogic spa;
        public StatController(IPlaneLogic pl, IPassengerLogic spa)
        {
            this.pl = pl;
            this.spa = spa;
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> PlanesWithSafeAirlines()
        {
            return pl.PlanesWithSafeAirlines();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> LongestTravelsPerAirlines()
        {
            return pl.LongestTravelsPerAirlines();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> AirlinesMostExpensiveTickets()
        {
            return spa.AirlinesMostExpensiveTickets();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGTicketPricesPerAirlines()
        {
            return spa.AVGTicketPricesPerAirlines();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountOfSoldFirstClassTicketsPerAirlines()
        {
            return spa.CountOfSoldFirstClassTicketsPerAirlines();
        }
    }
}
