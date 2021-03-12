using CarTryApplicationMVC.Application.Mapping;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<NewCustomerVm, Domain.Model.Customer>()
                .ForMember(s => s.IsActive, opt => opt.MapFrom(s => 1));
        }
    }
    public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
    {
        public NewCustomerValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        }
    }
}