using CarTryApplicationMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Customer
{
    public class CustomerForListVM : IMapFrom<Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Customer, CustomerForListVM>()
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}
