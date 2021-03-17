using CarTryApplicationMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Customer
{
    public class CustomerForListVm : IMapFrom<Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Customer, CustomerForListVm>()
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}
