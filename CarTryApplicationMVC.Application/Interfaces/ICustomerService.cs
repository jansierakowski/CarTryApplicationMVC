using CarTryApplicationMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString);

        string AddCustomer(NewCustomerVm customer);

        CustomerDetailsVm GetCustomerDetail(string customerId);
        NewCustomerVm GetAllCustomerForEdit(string id);
        void UpdateCustomer(NewCustomerVm model);
        void DeleteCustomer(string id);
    }
}
