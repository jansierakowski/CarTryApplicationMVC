using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllActiveCustomers();
        Customer GetCustomer(int customerId);
        int AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        IQueryable<CustomerDetail> GetDetailCustomerInfotmationByCustomerId(int customerId);
        IQueryable<Car> GetCarsAdsByCustomerId(int customerId);
        IQueryable<CustomerFeedback> GetCustomerFeedbeckByCustomerId(int customerId);

    }
}
