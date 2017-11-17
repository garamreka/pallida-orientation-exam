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

        public List<Licence_plates> GetByPlate(string plate)
        {
            return CarContext.Licence_plates.Where(p => p.Plate == plate).ToList();
        }

        public List<Licence_plates> GetBrand(string brand)
        {
            return CarContext.Licence_plates.Where(p => p.Car_brand == brand).ToList();
        }
    }
}
