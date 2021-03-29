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
        int AddItem(CarSpecification Cars);
        IQueryable<CarModel> GetCarsByBrand(string carBrand);
        //IQueryable<Car> GetCarsByModel(string model);
        IQueryable<Ad> GetCarsByLocation(string location);

        CarSpecification GetCarById(int id);
       // IQueryable<CarFeedback> GetCarFeedbeckByCarModel(string model);
        IQueryable<CarModel> GetAllCars();

    }
}
