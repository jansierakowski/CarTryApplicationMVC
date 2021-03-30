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
        CarSpecification GetCarByAdId(int adId);
        void DeleteAd(int AdId);
        int AddAd(Ad Ads);
        int AddCarSpec(CarSpecification carSpecification);
        void UpdateAd(Ad ad);
        IQueryable<Tag> GetAllTag();
        IQueryable<CarModel> GetAllCars();
    }
}
