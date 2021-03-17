using CarTryApplicationMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Ad
{
    public class NewAdVm : IMapFrom<Domain.Model.Ad>
    {
        public int Id { get; set; }


        public string AdName { get; set; }
        public int AdPrice { get; set; }
        public string AdPromotion { get; set; }
        public string AdDescription { get; set; }
        public int CarId { get; set; }
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

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<NewAdVm, Domain.Model.Ad>()
                .ForMember(s => s.IsActive, opt => opt.MapFrom(s => true)).ReverseMap();
            profile.CreateMap<NewAdVm, Domain.Model.Car>().ReverseMap();
        }
    }
}
