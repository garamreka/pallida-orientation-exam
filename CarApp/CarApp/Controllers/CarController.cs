using Microsoft.AspNetCore.Mvc;
using CarApp.Repositories;
using CarApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarApp.Controllers
{
    public class CarController : Controller
    {
        CarRepository CarRepository;

        public CarController(CarRepository carRepository)
        {
            this.CarRepository = carRepository;
        }

        [HttpGet]
        [Route ("")]
        public IActionResult Form(Licence_plates licence_PlateFromForm)
        {
            return View(licence_PlateFromForm);
        }

        [HttpGet]
        [Route("/result")]
        public IActionResult Result()
        {
            return View();
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult SearchPlate([FromQuery] string plate)
        {
            if (ModelState.IsValid)
            {
                var selectedCar = CarRepository.GetCarByPlate(plate);
                return View("Result", selectedCar);
            }
            else
            {
                return View("Form");
            }
        }

        [HttpGet]
        [Route ("/policecars")]
        public IActionResult Police()
        {
            return View(CarRepository.GetPoliceCars());
        }

        [HttpGet]
        [Route("/diplomats")]
        public IActionResult Diplomat()
        {
            return View(CarRepository.GetDiplomats());
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult Brand([FromRoute] string brand)
        {
            return View(CarRepository.GetBrand(brand));
        }

        [HttpGet]
        [Route("/api/search/{brand}")]
        public IActionResult ApiBrand([FromRoute] string brand)
        {
            var brandToReturn = CarRepository.GetBrand(brand);
            return Json(new Response() { Data = brandToReturn });
        }
    }
}
