using CarTryApplicationMVC.Application.ViewModels.Ad;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.Interfaces
{
    public interface IAdService
    {
        ListAdForListVm GetAllAdForList(int pageSize, int pageNo, string carBrandString, string carModelString, string carLocationString,
            string driveTrainString, string fuelTypeString, string carTypeBodyString);

        AdDetailsVm GetAdDetail(int adId);
        NewAdVm GetAllAdForEdit(int id);
        int AddAd(NewAdVm ad);
        void UpdateAd(NewAdVm model);
        void DeleteAd(int id);
        NewAdVm GetCarForDropDownList();
        List<SelectListItem> GetCarModelForDropDownList(int id);
        int GetBrandSelectedValue(int ModelId);
    }
}
