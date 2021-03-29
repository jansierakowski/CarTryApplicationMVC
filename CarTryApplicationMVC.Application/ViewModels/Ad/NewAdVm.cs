using CarTryApplicationMVC.Application.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarTryApplicationMVC.Domain.Model;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class NewAdVm : IMapFrom<Domain.Model.Ad>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AdName { get; set; }
        public int AdPrice { get; set; }
        public string AdPromotion { get; set; }
        public string AdDescription { get; set; }
        public string CarGeneration { get; set; }
        public int ProductionYear { get; set; }
        public int CarBrand { get; set; }
        public int CarModel { get; set; }
        public string Location { get; set; }
        public string FuelType { get; set; }
        public string DriveTrain { get; set; }
        public int OdometerValue { get; set; }
        public int NumberOfCylinders { get; set; }
        public string Equipment { get; set; }

        //public IEnumerable<SelectListItem> CarBrandList { get; set; }
        public List<SelectListItem> CarModelList { get; set; } 
        public List<SelectListItem> CarBrandList { get; set; } 
        public List<SelectListItem> AdPromotionList { get; set; } 


        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<NewAdVm, Domain.Model.Ad>()
                .ForPath(s => s.IsActive, opt => opt.MapFrom(s => true))
                .ForPath(s => s.CarSpecificationId, opt => opt.MapFrom(s => s.Id))

                .ForPath(s => s.CarSpecification.CarBrandId, opt => opt.MapFrom(s => s.CarBrand))
                .ForPath(s => s.CarSpecification.CarModelId, opt => opt.MapFrom(s => s.CarModel))

                .ForPath(s => s.CarSpecification.DriveTrain, opt => opt.MapFrom(s => s.DriveTrain))
                .ForPath(s => s.CarSpecification.FuelType, opt => opt.MapFrom(s => s.FuelType))
                .ForPath(s => s.CarSpecification.Generation, opt => opt.MapFrom(s => s.CarGeneration))
                .ForPath(s => s.CarSpecification.NumberOfCylinders, opt => opt.MapFrom(s => s.NumberOfCylinders))
                .ForPath(s => s.CarSpecification.OdometerValue, opt => opt.MapFrom(s => s.OdometerValue))
                .ForPath(s => s.CarSpecification.ProductionYear, opt => opt.MapFrom(s => s.ProductionYear))
                .ForPath(s => s.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                .ReverseMap();
        }
    }
}
