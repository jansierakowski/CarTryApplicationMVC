using CarTryApplicationMVC.Application.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class NewAdVm : IMapFrom<Domain.Model.Ad>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int CarModelId { get; set; }
        public string AdName { get; set; }
        public int AdPrice { get; set; }
        public string AdPromotion { get; set; }
        public string AdDescription { get; set; }
        public string CarGeneration { get; set; }
        public int CarProductionYear { get; set; }
        public int CarBrand { get; set; }
        public int CarModel { get; set; }
        public string CarLocation { get; set; }
        public string FuelType { get; set; }
        public string DriveTrain { get; set; }
        public int OdometerValue { get; set; }
        public int NumberOfCylinders { get; set; }
        public string CarEquipment { get; set; }

        //public IEnumerable<SelectListItem> CarBrandList { get; set; }
        public List<SelectListItem> CarModelList { get; set; } 
        public List<SelectListItem> CarBrandList { get; set; } 
        public List<SelectListItem> AdPromotionList { get; set; } 


        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<NewAdVm, Domain.Model.Ad>()
                .ForMember(s => s.IsActive, opt => opt.MapFrom(s => true))
                .ForMember(s => s.CarId, opt => opt.MapFrom(s => s.CarBrand))
                //.ForMember(s=>s.Car.CarModel.Select(t=>t.Id),opt=>opt.MapFrom(s=>s.CarModel))
                .ForMember(s => s.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                   //.ForPath(s => s.Car.CarModel.Select(t => t.Id).FirstOrDefault(), opt => opt.MapFrom(src => src.CarModel))
                   .ReverseMap();
        }
    }
}
