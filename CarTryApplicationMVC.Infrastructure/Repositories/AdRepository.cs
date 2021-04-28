using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteAd(int ad)
        {
            var item = _context.Ads.Find(ad);
            if (item != null)
            {
                _context.Ads.Remove(item);
                _context.SaveChanges();
            }
        }

        public void AddAd(Ad ad)
        {
            _context.Ads.Add(ad);
            _context.SaveChanges();
        }

        public void UpdateAd(Ad ad)
        {
            _context.Attach(ad);

            _context.Entry(ad).Property("AdName").IsModified = true;
            _context.Entry(ad).Property("AdDescription").IsModified = true;
            _context.Entry(ad).Property("AdPrice").IsModified = true;
           _context.Entry(ad.CarSpecification).Property("CarModelId").IsModified = true;
            _context.Entry(ad).Property("AdLocation").IsModified = true;
            _context.Entry(ad.CarSpecification).Property("FuelType").IsModified = true;
            _context.Entry(ad.CarSpecification).Property("DriveTrain").IsModified = true;
            _context.Entry(ad.CarSpecification).Property("OdometerValue").IsModified = true;
            _context.Entry(ad.CarSpecification).Property("NumberOfCylinders").IsModified = true;
            _context.SaveChanges();
        }

        public IQueryable<Tag> GetAllTag()
        {
            var tags = _context.Tags;
            return tags;
        }

        public IQueryable<Ad> GetAllActiveAds()
        {
            return _context.Ads.Where(p => p.IsActive).Include(p=>p.CarSpecification);
        }

        public Ad GetAd(int id)
        {
            return _context.Ads.Include(t=>t.CarSpecification.CarModel.CarBrand).FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<CarModel> GetAllCars()
        {
            var cars = _context.CarModels.Include(s => s.CarBrand);
            return cars;
        }

        public IQueryable<CarModel> GetAllCarModelByBrandId(int id)
        {
            var models = _context.CarModels.Include(s => s.CarBrand).Where(t=>t.CarBrandId == id);
            return models;
        }

        public IQueryable<CarModel> GetAllCarBrandByModelId(int id)
        {
            var models = _context.CarModels.Include(s => s.CarBrand).Where(t => t.Id == id);
            return models;
        }

    }
}
