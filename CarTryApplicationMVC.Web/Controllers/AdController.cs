using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Ad;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTryApplicationMVC.Web.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _adService.GetAllAdForList(10, 1, "", "", "", 0, 2021, "", "", 16, 0, "", 0, 10000000);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string carBrandString, string carModelString, string carLocationString,
            int carProductionYearTo, int carProductionYearFrom, string driveTrainString, string fuelTypeString,
            int numberOfCylindersStringTo, int numberOfCylindersStringFrom, string carTypeBodyString, int odometerValueStringTo,
            int odometerValueStringFrom)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            //if (carBrandString is null || carModelString is null || carLocationString is null || driveTrainString is null || fuelTypeString is null
            //    || carTypeBodyString is null)
            //{
            //    carBrandString = String.Empty;
            //    carModelString = String.Empty;
            //    carLocationString = String.Empty;
            //    driveTrainString = String.Empty;
            //    fuelTypeString = String.Empty;
            //    carTypeBodyString = String.Empty;
            //}

            var model = _adService.GetAllAdForList(pageSize, pageNo.Value, carBrandString, carModelString, carLocationString,
            carProductionYearTo, carProductionYearFrom, driveTrainString, fuelTypeString,
            numberOfCylindersStringTo, numberOfCylindersStringFrom, carTypeBodyString, odometerValueStringTo,
            odometerValueStringFrom);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddAd()
        {
            return View(new NewAdVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAd(NewAdVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _adService.AddAd(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditAd(int id)
        {
            var customer = _adService.GetAllAdForEdit(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAd(NewAdVm model)
        {
            if (ModelState.IsValid)
            {
                _adService.UpdateAd(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }



    }
}
