using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Domain.Interfaces
{
    public interface ICarRepository
    {
        void DeleteItem(int CarId);
        int AddItem(Car Cars);
        IQueryable<Car> GetCarsByBodyType(string bodyType);
        IQueryable<Car> GetCarsByBrand(string carBrand);
        IQueryable<Car> GetCarsByModel(string model);
        IQueryable<Ad> GetCarsByLocation(string location);
        
        Car GetCarById(int id);
        IQueryable<CarFeedback> GetCarFeedbeckByCarModel(string model);
        IQueryable<Car> GetAllCars();

    }
}
