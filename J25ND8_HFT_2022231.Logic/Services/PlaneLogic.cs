using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Models;
using J25ND8_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Logic.Services
{
    public class PlaneLogic : IPlaneLogic
    {
        IPlaneRepository planeRepo;
        public PlaneLogic(IPlaneRepository planeRepo)
        {
            this.planeRepo = planeRepo;
        }

        public void Create(Plane plane)
        {
            planeRepo.Create(plane);
        }

        public void Delete(int id)
        {
            planeRepo.Delete(id);
        }


        public Plane Read(int id)
        {
            return planeRepo.Read(id) ?? throw new ArgumentException("There is no plane with this id!");
        }

        public IEnumerable<Plane> ReadAll()
        {
            return planeRepo.ReadAll();
        }

        public void Update(Plane plane)
        {
            planeRepo.Update(plane);
        }
        //non-crud

        public IEnumerable<KeyValuePair<string, double>> PlanesWithSafeAirlines()
        {
            return from x in planeRepo.ReadAll()
                   where x.Airline.SafetyPoint >= 5.0
                   select new KeyValuePair<string, double>(x.Type,x.Airline.SafetyPoint);
        }
    }
}
