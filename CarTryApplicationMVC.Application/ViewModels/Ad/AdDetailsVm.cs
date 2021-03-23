using CarTryApplicationMVC.Application.Mapping;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class AdDetailsVm : IMapFrom<Domain.Model.Ad>
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public string AdName { get; set; }
        public int AdPrice { get; set; }
        public string AdDescription { get; set; }
        public string CarGeneration { get; set; }
        public int CarProductionYear { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarLocation { get; set; }
        public string FuelType { get; set; }
        public string DriveTrain { get; set; }
        public int OdometerValue { get; set; }
        public int NumberOfCylinders { get; set; }
        public string CarEquipment { get; set; }

        //public List<ContactDetailsListVm> PhoneNumbers { get; set; }


        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Ad, AdDetailsVm>()
                    //.ForMember(s => s.CarBrand, opt => opt.MapFrom(s => s.Car.CarBrand))
                    //.ForMember(s => s.CarGeneration, opt => opt.MapFrom(s => s.Car.CarGeneration))
                    //.ForMember(s => s.CarModel, opt => opt.MapFrom(s => s.Car.CarModel))
                    .ForMember(s => s.CarLocation, opt => opt.MapFrom(s => s.CarLocation))
                    .ForMember(s => s.OdometerValue, opt => opt.MapFrom(s => s.CarOdometerValue))
                    .ForMember(s => s.FuelType, opt => opt.MapFrom(s => s.CarFuelType))
                    .ForMember(s => s.CarEquipment, opt => opt.MapFrom(s => s.CarEquipments))
                    .ForMember(s => s.NumberOfCylinders, opt => opt.MapFrom(s => s.CarNumberOfCylinders))
                    .ForMember(s => s.DriveTrain, opt => opt.MapFrom(s => s.CarDriveTrain));

            profile.CreateMap<Domain.Model.CarModel, AdDetailsVm>()
                  .ForMember(s => s.CarBrand, opt => opt.MapFrom(s => s.Car.CarBrand))
                  .ForMember(s => s.CarModel, opt => opt.MapFrom(s => s.Model));


            //profile.CreateMap<Domain.Model.CarModel, AdDetailsVm>()

        }
    }
}
