using J25ND8_HFT_2022231.Models;
using J25ND8_HFT_2022231.Repository.Data;
using J25ND8_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Repository.Repositories
{
    public class PassengerRepository : Repository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(AirPortDbContext ctx) : base(ctx)
        {

        }
    }
}
