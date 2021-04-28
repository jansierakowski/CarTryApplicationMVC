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
        Customer GetCustomer(string customerId);
        string AddCustomer(Customer customer);
        void DeleteCustomer(string customerId);
        //IQueryable<Car> GetCarsAdsByCustomerId(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
