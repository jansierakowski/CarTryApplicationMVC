using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Ad;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Application.Service
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _adRepo;
        private readonly IMapper _mapper;

        public AdService(IAdRepository adRepo, IMapper mapper)
        {
            _adRepo = adRepo;
            _mapper = mapper;
        }

        public int AddAd(NewAdVm ad)
        {
            var ads = _mapper.Map<Ad>(ad);
            var id = _adRepo.AddAd(ads);

            return id;
        }

        public void DeleteAd(int id)
        {
            _adRepo.DeleteAd(id);
        }

        public AdDetailsVm GetAdDetail(int adId)
        {
            var ad = _adRepo.GetAd(adId);
            var adVm = _mapper.Map<AdDetailsVm>(ad);
            return adVm;
        }

        public NewAdVm GetCarForDropDownList()
        {
            var cars = _adRepo.GetAllCars().ToList();

            List<SelectListItem> carBrandList = new List<SelectListItem>();
            List<SelectListItem> carModelList = new List<SelectListItem>();

            if (cars != null)
            {
                foreach (var car in cars.Select(t=>t.CarBrand).Distinct())
                {
                    carBrandList.Add(new SelectListItem
                    {
                        Text = car.Brand,
                        Value = car.Id.ToString(),
                    });
                }

                //foreach (var car in cars)
                //{
                //    carModelList.Add(new SelectListItem
                //    {
                //        Text = car.Model,
                //        Value = car.Id.ToString()
                //    });

                //}

                var dropDownList = new NewAdVm()
                {
                    CarBrandList = carBrandList,
                    CarModelList = carModelList
                };

                return dropDownList;
            }
            return new NewAdVm();
        }

        public int GetBrandSelectedValue(int ModelId)
        {
            var cars = _adRepo.GetAllCarBrandByModelId(ModelId);
            int brandId = cars.Select(t => t.CarBrandId).FirstOrDefault();

            return brandId;
        }

        public List<SelectListItem> GetCarModelForDropDownList(int id)
        {
            List<SelectListItem> carModelList = new List<SelectListItem>();
            var cars = _adRepo.GetAllCarModelByBrandId(id).ToList();

            foreach (var car in cars)
            {
                carModelList.Add(new SelectListItem
                {
                    Text = car.Model,
                    Value = car.Id.ToString()
                });

            }
            return carModelList;
        }


        public NewAdVm GetAllAdForEdit(int id)
        {
            var ad = _adRepo.GetAd(id);
            var carbrand = GetCarForDropDownList();
            var adVm = _mapper.Map<NewAdVm>(ad);
            adVm.CarBrandList = carbrand.CarBrandList;
            adVm.CarModelList = carbrand.CarModelList;
            return adVm;
        }

        public ListAdForListVm GetAllAdForList(int pageSize, int pageNo, string carBrandString, string carModelString, string carLocationString,
                                               string driveTrainString, string fuelTypeString, string carTypeBodyString)
        {
            var ad = _adRepo.GetAllActiveAds().Where(p => p.AdLocation.StartsWith(carLocationString) &&
                                                    p.CarSpecification.CarModel.CarBrand.Brand.StartsWith(carBrandString) &&
                                                    p.CarSpecification.CarModel.Model.StartsWith(carModelString) &&
                                                     //p.Car.CarProductionYear <= carProductionYearTo &&
                                                     //p.Car.CarProductionYear >= carProductionYearFrom &&
                                                     p.CarSpecification.DriveTrain.StartsWith(driveTrainString) &&
                                                     p.CarSpecification.FuelType.StartsWith(fuelTypeString))
                                                     //p.Car.NumberOfCylinders <= numberOfCylindersStringTo &&
                                                     //p.Car.NumberOfCylinders >= numberOfCylindersStringFrom &&
                                                     //p.Car.CarTypeBody.Name.StartsWith(carTypeBodyString)) //&&
                                                     //p.Car.OdometerValue <= odometerValueStringTo &&
                                                     //p.Car.OdometerValue >= odometerValueStringFrom))
                                                     .ProjectTo<AdForListVm>(_mapper.ConfigurationProvider).ToList();

            var adListToShow = ad.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();


            var adList = new ListAdForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                Count = ad.Count,
                Ads = adListToShow,

                CarBrandString = carBrandString,
                CarModelString = carModelString,
                CarLocationString = carLocationString,
                //CarProductionYearTo = carProductionYearTo,
                //CarProductionYearFrom = carProductionYearFrom,
                DriveTrainString = driveTrainString,
                FuelTypeString = fuelTypeString,
                //NumberOfCylindersStringTo = numberOfCylindersStringTo,
                //NumberOfCylindersStringFrom = numberOfCylindersStringFrom,
                CarTypeBodyString = carTypeBodyString,
                //OdometerValueStringTo = odometerValueStringTo,
                //OdometerValueStringFrom = odometerValueStringFrom,

            };
            return adList;

        }

        public void UpdateAd(NewAdVm model)
        {
            var ad = _mapper.Map<Ad>(model);
            _adRepo.UpdateAd(ad);
        }
    }
}


