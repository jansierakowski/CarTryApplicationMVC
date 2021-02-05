using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Infrastructure.Repositories
{
    public class AdRepository : IAdRepository
    {
        private readonly Context _context;
        public AdRepository(Context context)
        {
            _context = context;
        }

        public void DeleteItem(int itemId)
        {
            var item = _context.Ads.Find(itemId);
            if (item != null)
            {
                _context.Ads.Remove(item);
                _context.SaveChanges();
            }
        }

        public int AddItem(Ad carAds)
        {
            _context.Ads.Add(carAds);
            _context.SaveChanges();
            return carAds.Id;
        }

        public IQueryable<Ad> GetCarAdsByAdType(string type)
        {
            var adType = _context.Ads.Where(i => i.AdType.AdvertisementType == type);
            return adType;
        }

        public Ad GetCarAdById(int carId)
        {
            var ad = _context.Ads.FirstOrDefault(i => i.Id == carId);
            return ad;
        }

        public IQueryable<Tag> GetAllTag()
        {
            var tags = _context.Tags;
            return tags;
        }
    }
}
