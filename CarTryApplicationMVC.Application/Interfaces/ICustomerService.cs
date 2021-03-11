using CarTryApplicationMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomerForList(int pageSize, int pageNo, string searchString);

        int AddCustomer(NewCustomerVm customer);

        CustomerDetailsVm GetCustomerDetail(int customerId);
    }
}
