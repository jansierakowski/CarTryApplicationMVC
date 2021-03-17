using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Ad;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Application.Service
{
    public class AdService : IAdService
    {
        public readonly IAdRepository _adRepo;
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
            //adVm.PhoneNumbers = new List<ContactDetailsListVm>();

            return adVm;
        }

        public NewAdVm GetAllAdForEdit(int id)
        {
            var ad = _adRepo.GetAd(id);
            var adVm = _mapper.Map<NewAdVm>(ad);
            return adVm;
        }

        public ListAdForListVm GetAllAdForList(int pageSize, int pageNo, string carBrandString, string carModelString, string carLocationString,
            int carProductionYearTo, int carProductionYearFrom, string driveTrainString, string fuelTypeString, 
            int numberOfCylindersStringTo, int numberOfCylindersStringFrom, string carTypeBodyString, int odometerValueStringTo,
            int odometerValueStringFrom)
        {
            var ad = _adRepo.GetAllActiveAds().Where(p => p.Car.CarBrand.StartsWith(carBrandString) &&
                                                     p.Car.CarModel.StartsWith(carModelString) &&
                                                     p.Car.CarLocation.StartsWith(carLocationString) &&
                                                     p.Car.CarProductionYear <= carProductionYearTo &&
                                                     p.Car.CarProductionYear >= carProductionYearFrom &&
                                                     p.Car.DriveTrain.StartsWith(driveTrainString) &&
                                                     p.Car.FuelType.StartsWith(fuelTypeString) &&
                                                     p.Car.NumberOfCylinders <= numberOfCylindersStringTo &&
                                                     p.Car.NumberOfCylinders >= numberOfCylindersStringFrom &&
                                                     p.Car.CarTypeBody.Name.StartsWith(carTypeBodyString) &&
                                                     p.Car.OdometerValue <= odometerValueStringTo &&
                                                     p.Car.OdometerValue >= odometerValueStringFrom)
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
                CarProductionYearTo = carProductionYearTo,
                CarProductionYearFrom = carProductionYearFrom,
                DriveTrainString = driveTrainString,
                FuelTypeString = fuelTypeString,
                NumberOfCylindersStringTo = numberOfCylindersStringTo,
                NumberOfCylindersStringFrom = numberOfCylindersStringFrom,
                CarTypeBodyString = carTypeBodyString,
                OdometerValueStringTo = odometerValueStringTo,
                OdometerValueStringFrom = odometerValueStringFrom,

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
