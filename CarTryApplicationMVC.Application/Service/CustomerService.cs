using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using CarTryApplicationMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public int AddCustomer(NewCustomerVm customer)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString)
        {
            var customers = _customerRepo.GetAllActiveCustomers().Where(p=>p.FirstName.StartsWith(searchString))
                .ProjectTo<CustomerForListVM>(_mapper.ConfigurationProvider).ToList();
            var customersToShow = customers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var customList = new ListCustomerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Customers = customersToShow,
                Count = customers.Count
            };
            return customList;

        }

        public CustomerDetailsVm GetCustomerDetail(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);

            customerVm.Adresses = new List<AddressForListVm>();
            customerVm.Cars = new List<CustomerCarForListVm>();
            customerVm.PhoneNumbers = new List<ContactDetailsListVm>();

            foreach (var car in customer.Cars)
            {
                var add = new CustomerCarForListVm()
                {
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    CarLocation = car.CarLocation,
                    CarProductionYear = car.CarProductionYear,
                    FuelType = car.FuelType
                    
                };
                customerVm.Cars.Add(add);
            }
            return customerVm;
        }
    }
}
