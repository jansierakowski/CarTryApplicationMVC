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

        public IQueryable<Car> GetCarsByBodyType(string bodyType)
        {

            var body = _context.Cars.Where(a => a.CarTypeBody.Name == bodyType);
            return body;
        }
        public IQueryable<Car> GetCarsByBrand(string carBrand)
        {
            var brand = _context.Cars.Where(a => a.CarBrand == carBrand);
            return brand;
        }
        public IQueryable<Car> GetCarsByModel(string model)
        {
            var carModel = _context.Cars.Where(a => a.CarModel == model);
            return carModel;
        }

        public IQueryable<Car> GetCarsByLocation(string location)
        {
            var carLocation = _context.Cars.Where(a => a.CarLocation == location);
            return carLocation;
        }

        public IQueryable<Car> GetCarsBYear(int year)
        {
            var carYear = _context.Cars.Where(a => a.CarProductionYear == year);
            return carYear;
        }

        public IQueryable<Car> GetCarsByFuelType(string fuel)
        {
            var fuelType = _context.Cars.Where(a => a.FuelType == fuel);
            return fuelType;
        }        
        
        public IQueryable<Car> GetCarsByDriveTrain(string drivetrain)
        {
            var carDriveTrain = _context.Cars.Where(a => a.FuelType == drivetrain);
            return carDriveTrain;
        }

        public IQueryable<Car> GetCarsByNumberOfCylinder(int cylinder)
        {
            var carNumberOfCylinder = _context.Cars.Where(a => a.NumberOfCylinders == cylinder);
            return carNumberOfCylinder;
        }

        public Car GetCarById(int id)
        {
            var carId = _context.Cars.FirstOrDefault(a => a.Id == id);
            return carId;
        }

        public IQueryable<CarFeedback> GetCarFeedbeckByCarModel(string model)
        {
            var carFeedback = _context.CarFeedbacks.Where(a => a.Car.CarModel == model);
            return carFeedback;
        }

        public IQueryable<Car> GetAllCars()
        {
            var cars = _context.Cars;
            return cars;
        }
    }
}
