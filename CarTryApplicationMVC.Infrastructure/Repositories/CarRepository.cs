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

        public int AddItem(Car Cars)
        {
            _context.Cars.Add(Cars);
            _context.SaveChanges();
            return Cars.Id;
        }

        public void DeleteItem(int CarId)
        {
            var item = _context.Cars.Find(CarId);
            if (item != null)
            {
                _context.Cars.Remove(item);
                _context.SaveChanges();
            }
        }

        public IQueryable<Car> GetCarsByBrand(string carBrand)
        {
            var brand = _context.Cars.Where(a => a.CarBrand == carBrand);
            return brand;
        }
        public IQueryable<CarModel> GetCarsByModel(string model)
        {
            var carModel = _context.CarModels.Where(a => a.Model == model);
            return carModel;
        }

        public IQueryable<Ad> GetCarsByLocation(string location)
        {
            var carLocation = _context.Ads.Where(a => a.CarLocation == location);
            return carLocation;
        }
        
        public Car GetCarById(int id)
        {
            var carId = _context.Cars.FirstOrDefault(a => a.Id == id);
            return carId;
        }

        public IQueryable<CarModel> GetCarFeedbeckByCarModel(string carBrand, string carModel)
        {
            var carFeedback = _context.CarModels.Where(a => a.Car.CarBrand == carBrand && a.Model == carModel);
            return carFeedback;
        }

        public IQueryable<Car> GetAllCars()
        {
            var cars = _context.Cars;
            return cars;
        }
    }
}
