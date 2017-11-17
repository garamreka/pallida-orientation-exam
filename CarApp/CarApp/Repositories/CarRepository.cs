using CarApp.Entities;
using CarApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarApp.Repositories
{
    public class CarRepository
    {
        CarContext CarContext;

        public CarRepository(CarContext carContext)
        {
            this.CarContext = carContext;
        }

        public List<Licence_plates> GetCarByPlate(string plate)
        {
            return CarContext.Licence_plates.Where(p => p.Plate == plate).ToList();
        }

        public List<Licence_plates> GetPoliceCars()
        {
            return CarContext.Licence_plates.Where(p => p.Plate.Contains("RB")).ToList();
        }

        public List<Licence_plates> GetDiplomats()
        {
            return CarContext.Licence_plates.Where(p => p.Plate.Contains("DT")).ToList();
        }

        public List<Licence_plates> GetBrand(string brand)
        {
            return CarContext.Licence_plates.Where(p => p.Car_brand == brand).ToList();
        }
    }
}
