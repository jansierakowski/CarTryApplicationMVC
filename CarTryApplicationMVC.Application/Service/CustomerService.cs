using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;
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
            var cust = _mapper.Map<Customer>(customer);
            var id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public NewCustomerVm GetAllCustomerForEdit(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVm = _mapper.Map<NewCustomerVm>(customer);
            return customerVm;
        }

        public ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString)
        {
            var customers = _customerRepo.GetAllActiveCustomers().Where(p => p.FirstName.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
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
            customerVm.Ad = new List<CustomerAdForListVm>();
            customerVm.PhoneNumbers = new List<ContactDetailsListVm>();

            if (customer.Ads != null)
            {
                foreach (var ad in customer.Ads)
                {
                    var add = new CustomerAdForListVm()
                    {
                        AdName = ad.AdName,
                        AdPrice = ad.AdPrice,
                        //CarBrand = ad.CarSpecification.Ca,
                        //CarModel = ad.CarSpecification.CarModelName,
                        CarProductionYear = ad.CarSpecification.ProductionYear,
                        CarLocation = ad.AdLocation,
                        FuelType = ad.CarSpecification.FuelType


                    };
                    customerVm.Ad.Add(add);
                }
            }
            return customerVm;
        }

        public void UpdateCustomer(NewCustomerVm model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepo.UpdateCustomer(customer);
        }
    }
}
