using CarTryApplicationMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class AdForListVm : IMapFrom<Domain.Model.Ad>
    {
        public int Id { get; set; }
        public string AdName { get; set; }
        public int AdPrice { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarLocation { get; set; }
        public string FuelType { get; set; }
        public int OdometerValue { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Ad, AdForListVm>()
                .ForMember(s => s.CarBrand, opt => opt.MapFrom(s => s.Car.CarBrand))
                .ForMember(s => s.CarModel, opt => opt.MapFrom(s => s.Car.CarModel))
                .ForMember(s => s.CarLocation, opt => opt.MapFrom(s => s.CarLocation))
                .ForMember(s => s.OdometerValue, opt => opt.MapFrom(s => s.CarOdometerValue))
                .ForMember(s => s.FuelType, opt => opt.MapFrom(s => s.CarFuelType));
        }



    }
}
