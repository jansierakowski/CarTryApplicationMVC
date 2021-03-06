﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;

namespace CarTryApplicationMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }
        public int AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IQueryable<Car> GetCarsAdsByCustomerId(int customerId)
        {
            var cars = _context.Cars.Where(a => a.Customer.Id == customerId);
            return cars;
        }

        public IQueryable<CustomerFeedback> GetCustomerFeedbeckByCustomerId(int customerId)
        {
            var customerFeedback = _context.CustomerFeedbacks.Where(a => a.Customer.Id == customerId);
            return customerFeedback;
        }

        public IQueryable<CustomerDetail> GetDetailCustomerInfotmationByCustomerId(int customerId)
        {
            var detialCustomer = _context.CustomerDetails.Where(a => a.Customer.Id == customerId);
            return detialCustomer;
        }
    }
}
