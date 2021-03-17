using CarTryApplicationMVC.Application.ViewModels.Ad;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.Interfaces
{
    public interface IAdService
    {
        ListAdForListVm GetAllAdForList(int pageSize, int pageNo, string carBrandString, string carModelString, string carLocationString,
            int carProductionYearTo, int carProductionYearFrom, string driveTrainString, string fuelTypeString,
            int numberOfCylindersStringTo, int numberOfCylindersStringFrom, string carTypeBodyString, int odometerValueStringTo,
            int odometerValueStringFrom);

        AdDetailsVm GetAdDetail(int adId);
        NewAdVm GetAllAdForEdit(int id);
        int AddAd(NewAdVm ad);
        void UpdateAd(NewAdVm model);
        void DeleteAd(int id);

    }
}
