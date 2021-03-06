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
        public string AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void DeleteCustomer(string customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _context.Customers.Where(p => p.IsActive);
        }


        public Customer GetCustomer(string customerId)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == customerId);
        }


        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);

            _context.Entry(customer).Property("FirstName").IsModified = true;
            _context.Entry(customer).Property("LastName").IsModified = true;
            _context.SaveChanges();
        }
    }
}
