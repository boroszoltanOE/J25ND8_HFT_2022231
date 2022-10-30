using J25ND8_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Logic.Interfaces
{
    public interface IPlaneLogic
    {
        //crud
        void Create(Plane plane);
        void Update(Plane plane);
        void Delete(int id);
        IEnumerable<Plane> ReadAll();
        Plane Read(int id);

        //non-crud
            //Plane-Airline
        IEnumerable<KeyValuePair<string, double>> PlanesWithSafeAirlines();
            //Plane-Airline
        IEnumerable<KeyValuePair<string, double>> LongestTravelsPerAirlines();
    }
}
