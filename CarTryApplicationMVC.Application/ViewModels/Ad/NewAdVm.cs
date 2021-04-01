using CarTryApplicationMVC.Application.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarTryApplicationMVC.Domain.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class NewAdVm : IMapFrom<Domain.Model.Ad>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [DisplayName("Tytuł ogłoszenia")]
        public string AdName { get; set; }
        [DisplayName("Cena")]
        public decimal? AdPrice { get; set; }
        [DisplayName("Sposób promowania")]
        public string AdPromotion { get; set; }
        [DisplayName("Opis ogłoszenia")]
        public string AdDescription { get; set; }
        [DisplayName("Rok produkcji")]
        public int? ProductionYear { get; set; }
        [DisplayName("Marka")]
        public int? CarBrandIdFromList { get; set; }
        [DisplayName("Model")]
        public int CarModelIdFromList { get; set; }
        [DisplayName("Generacja")]
        public string CarGeneration { get; set; }
        [DisplayName("Lokalizacja")]
        public string Location { get; set; }
        [DisplayName("Przebieg")]
        public int? OdometerValue { get; set; }
        [DisplayName("Typ paliwa")]
        public string FuelType { get; set; }
        [DisplayName("Typ napędu")]
        public string DriveTrain { get; set; }
        [DisplayName("Ilość cylindrów")]
        public int? NumberOfCylinders { get; set; }
        [DisplayName("Wyposażenie")]
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
                .ForPath(s=>s.AdLocation, opt=>opt.MapFrom(s=>s.Location))
                .ForPath(s => s.CarSpecification.CarModelId, opt => opt.MapFrom(s => s.CarModelIdFromList))
                .ForPath(s => s.CarSpecification.DriveTrain, opt => opt.MapFrom(s => s.DriveTrain))
                .ForPath(s => s.CarSpecification.FuelType, opt => opt.MapFrom(s => s.FuelType))
                .ForPath(s => s.CarSpecification.Generation, opt => opt.MapFrom(s => s.CarGeneration))
                .ForPath(s => s.CarSpecification.NumberOfCylinders, opt => opt.MapFrom(s => s.NumberOfCylinders))
                .ForPath(s => s.CarSpecification.OdometerValue, opt => opt.MapFrom(s => s.OdometerValue))
                .ForPath(s => s.CarSpecification.ProductionYear, opt => opt.MapFrom(s => s.ProductionYear))
                .ForPath(s => s.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                .ReverseMap();
        }

        public class NewAdValidation : AbstractValidator<NewAdVm>
        {
            public NewAdValidation()
            {
                RuleFor(x => x.AdName).NotNull();
                RuleFor(x => x.AdName).MaximumLength(25);
                RuleFor(x => x.AdDescription).NotNull();
                RuleFor(x => x.AdDescription).MaximumLength(255);
                RuleFor(x => x.AdPrice).NotNull();
                RuleFor(x => x.DriveTrain).NotNull();
                RuleFor(x => x.DriveTrain).MaximumLength(10);
                RuleFor(x => x.FuelType).NotNull();
                RuleFor(x => x.FuelType).MaximumLength(10);
                RuleFor(x => x.Location).NotNull();
                RuleFor(x => x.Location).MaximumLength(40);
                RuleFor(x => x.OdometerValue).NotNull();
                RuleFor(x => x.ProductionYear).NotNull();
                RuleFor(x => x.NumberOfCylinders).NotNull();
                RuleFor(x => x.Equipment).NotNull();
                RuleFor(x => x.CarGeneration).NotNull();
            }
        }
    }
}
