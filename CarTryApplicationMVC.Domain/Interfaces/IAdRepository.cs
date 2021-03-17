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
        int AddAd(Ad Ads);
        void UpdateAd(Ad ad);
        Ad GetCarAdById(int itemId);
        IQueryable<Tag> GetAllTag();

    }
}
