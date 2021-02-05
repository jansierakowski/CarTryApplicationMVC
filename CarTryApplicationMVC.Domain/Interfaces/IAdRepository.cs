using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Domain.Interfaces
{
    public interface IAdRepository
    {
        void DeleteItem(int AdId);
        int AddItem(Ad Ads);
        IQueryable<Ad> GetCarAdsByAdType(string type);
        Ad GetCarAdById(int itemId);
        IQueryable<Tag> GetAllTag();
        
    }
}
