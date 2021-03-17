using AutoMapper;
using CarTryApplicationMVC.Application.Mapping;
using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVm : IMapFrom<Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CustomerAdForListVm> Ad { get; set; }
        public List<AddressForListVm> Adresses { get; set; }
        public List<ContactDetailsListVm> PhoneNumbers { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(s => s.Name, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName))
                .ForMember(s => s.PhoneNumbers, opt => opt.Ignore())
                .ForMember(s => s.Adresses, opt => opt.Ignore())
                .ForMember(s => s.Ad, opt => opt.Ignore())
;        }

    }
}
