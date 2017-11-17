using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Form()
        {
            return View();
        }

        [HttpGet]
        [Route("/result")]
        public IActionResult Result()
        {
            return View();
        }

        [HttpGet]
        [Route("/seachplate")]
        public IActionResult SearchPlate([FromQuery] string plate)
        {
            if (ModelState.IsValid)
            {
                CarRepository.GetByPlate(plate);
                return RedirectToAction("Result");
            }
            else
            {
                return View("Form");
            }
        }

        [HttpGet]
        [Route ("/searchpolice")]
        public IActionResult SearchPolice([FromQuery] string police)
        {
            return RedirectToAction("Result");
        }

        [HttpGet]
        [Route("/searchdiplomat")]
        public IActionResult SearchDiplomat([FromQuery] string diplomat)
        {
            return RedirectToAction("Result");
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult SearchBrand([FromRoute] string brand)
        {
            return RedirectToAction("Result");
        }

        [HttpGet]
        [Route("/api/search/{brand}")]
        public IActionResult ApiBrand([FromRoute] string brand)
        {
            var brandToReturn = CarRepository.GetBrand(brand);
            return Json(new Json() { Data = brandToReturn });
        }
    }
}
