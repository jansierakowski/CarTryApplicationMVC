﻿using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
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

        public int AddAd(Ad ad)
        {
            _context.Ads.Add(ad);
            _context.SaveChanges();
            return ad.Id;
        }

        public void UpdateAd(Ad ad)
        {
            _context.Attach(ad);

            _context.Entry(ad).Property("AdName").IsModified = true;
            _context.Entry(ad).Property("AdDescription").IsModified = true;
            _context.Entry(ad).Property("AdPrice").IsModified = true;
            _context.Entry(ad.Car).Property("CarBrand").IsModified = true;
            _context.Entry(ad.Car).Property("CarModel").IsModified = true;
            _context.Entry(ad.Car).Property("CarLocation").IsModified = true;
            _context.Entry(ad.Car).Property("FuelType").IsModified = true;
            _context.Entry(ad.Car).Property("DriveTrain").IsModified = true;
            _context.Entry(ad.Car).Property("OdometerValue").IsModified = true;
            _context.Entry(ad.Car).Property("NumberOfCylinders").IsModified = true;
            _context.SaveChanges();
        }

        public IQueryable<Tag> GetAllTag()
        {
            var tags = _context.Tags;
            return tags;
        }

        public IQueryable<Ad> GetAllActiveAds()
        {
            return _context.Ads.Where(p => p.IsActive);
        }

        public Ad GetAd(int id)
        {
            return _context.Ads.FirstOrDefault(p => p.Id == id);
        }
        public Car GetCarByAdId(int adId)
        {
            var ad = _context.Ads.FirstOrDefault(p => p.Id == adId);
            return _context.Cars.Include(p=>p.CarModel).FirstOrDefault(p => p.Id == ad.CarId);
        }
       
        public CarModel GetCarModelByAdId(int adId)
        {
            var car = GetCarByAdId(adId);
            return _context.CarModels.FirstOrDefault(p => p.CarId == car.Id);
        }


        public IQueryable<Car> GetAllCars()
        {
            var cars = _context.Cars.Include(p => p.CarModel);
            return cars;
        }

        public IQueryable<CarModel> GetAllModels()
        {
            var cars = _context.CarModels;
            return cars;
        }




    }
}
