using CarApp.Entities;

namespace CarApp.Repositories
{
    public class CarRepository
    {
        CarContext CarContext;

        public CarRepository(CarContext carContext)
        {
            this.CarContext = carContext;
        }
    }
}
