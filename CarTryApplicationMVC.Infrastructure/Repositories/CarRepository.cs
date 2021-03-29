using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly Context _context;
        public CarRepository(Context context)
        {
            _context = context;
        }

        public int AddItem(CarSpecification Cars)
        {
            _context.CarSpecifications.Add(Cars);
            _context.SaveChanges();
            return Cars.Id;
        }

        public void DeleteItem(int CarId)
        {
            var item = _context.CarSpecifications.Find(CarId);
            if (item != null)
            {
                _context.CarSpecifications.Remove(item);
                _context.SaveChanges();
            }
        }

        public IQueryable<CarModel> GetCarsByBrand(string carBrand)
        {
            var brand = _context.CarModels.Where(a => a.CarBrand.Brand == carBrand);
            return brand;
        }
        public IQueryable<CarModel> GetCarsByModel(string model)
        {
            var carModel = _context.CarModels.Where(a => a.Model == model);
            return carModel;
        }

        public IQueryable<Ad> GetCarsByLocation(string location)
        {
            var carLocation = _context.Ads.Where(a => a.AdLocation == location);
            return carLocation;
        }
        
        public CarSpecification GetCarById(int id)
        {
            var carId = _context.CarSpecifications.FirstOrDefault(a => a.Id == id);
            return carId;
        }

        public IQueryable<CarModel> GetAllCars()
        {
            var cars = _context.CarModels;
            return cars;
        }
    }
}
