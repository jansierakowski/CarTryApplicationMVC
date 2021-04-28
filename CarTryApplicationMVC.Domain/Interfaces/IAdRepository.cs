using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Domain.Interfaces
{
    public interface IAdRepository
    {
        IQueryable<Ad> GetAllActiveAds();
        Ad GetAd(int id);
        void DeleteAd(int AdId);
        void AddAd(Ad Ads);
        void UpdateAd(Ad ad);
        IQueryable<Tag> GetAllTag();
        IQueryable<CarModel> GetAllCars();
        IQueryable<CarModel> GetAllCarModelByBrandId(int id);
        IQueryable<CarModel> GetAllCarBrandByModelId(int id);
    }
}
