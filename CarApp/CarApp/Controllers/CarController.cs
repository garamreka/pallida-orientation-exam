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
        Licence_plates licence_Plates;

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

        [HttpPost]
        [Route("/seach")]
        public IActionResult SearchPlate(Licence_plates licence_PlateFromForm)
        {
            licence_Plates.Plate = licence_PlateFromForm.Plate;

            if (ModelState.IsValid)
            {
                CarRepository.GetByPlate(licence_Plates.Plate);
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
            CarRepository.GetPoliceCars();
            return RedirectToAction("Result");
        }

        [HttpGet]
        [Route("/searchdiplomat")]
        public IActionResult SearchDiplomat([FromQuery] string diplomat)
        {
            CarRepository.GetDiplomats();
            return RedirectToAction("Result");
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult Brand([FromRoute] string brand)
        {
            var brandToReturn = CarRepository.GetBrand(brand);
            return View(brandToReturn);
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
