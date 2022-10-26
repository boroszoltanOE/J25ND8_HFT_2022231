using J25ND8_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Logic.Interfaces
{
    public interface IAirlineLogic
    {
        void Create(Airline airline);
        void Update(Airline airline);
        void Delete(int id);
        Airline Read(int id);
        IEnumerable<Airline> ReadAll();
    }
}
