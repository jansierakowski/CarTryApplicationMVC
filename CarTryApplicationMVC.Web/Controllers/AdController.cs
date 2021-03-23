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
            var model = _adService.GetAllAdForList(10, 1, "","", "", "", "", "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string carBrandString, string carModelString, string carLocationString,
                string driveTrainString, string fuelTypeString, string carTypeBodyString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (carBrandString is null)
            {
                carBrandString = String.Empty;
               
            }
            if (carModelString is null)
            {
                carModelString = String.Empty;
            }

            if (carLocationString is null)
            {
                carLocationString = String.Empty;
            }
            if (driveTrainString is null)
            {
                driveTrainString = String.Empty;
            }
            if (fuelTypeString is null)
            {
                fuelTypeString = String.Empty;
            }
            if (carTypeBodyString is null)
            {
                carTypeBodyString = String.Empty;
            }


            var model = _adService.GetAllAdForList(pageSize, pageNo.Value, carBrandString,carModelString, carLocationString,
            driveTrainString, fuelTypeString, carTypeBodyString);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddAd()
        {
            var model =_adService.GetCarForDropDownList();
            return View(model);
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

        [HttpGet]
        public IActionResult DetailAd(int id)
        {
            var ad = _adService.GetAdDetail(id);
            return View(ad);
        }



    }
}
