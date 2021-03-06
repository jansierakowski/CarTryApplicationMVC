﻿using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Ad;
using CarTryApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public AdController(IAdService adService, UserManager<ApplicationUser> userManager)
        {
            _adService = adService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _adService.GetAllAdForList(8, 1, "", "", "", "", "", "");
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


            var model = _adService.GetAllAdForList(pageSize, pageNo.Value, carBrandString, carModelString, carLocationString,
            driveTrainString, fuelTypeString, carTypeBodyString);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddAd()
        {
            string user = _userManager.GetUserId(HttpContext.User);
            var model = _adService.GetCarForDropDownList();
            model.CustomerId = user;
            return View(model);
        }

        [HttpGet]
        public JsonResult GetModelList(int BrandId)
        {
            var modelist = _adService.GetCarModelForDropDownList(BrandId);
            return Json(modelist);

        }

        [HttpGet]
        public JsonResult GetBrandSelectedValue(int ModelId)
        {
            var modelist = _adService.GetBrandSelectedValue(ModelId);

            return Json(new { model = modelist });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAd(NewAdVm model)
        {
            if (ModelState.IsValid)
            {
                _adService.AddAd(model);
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
