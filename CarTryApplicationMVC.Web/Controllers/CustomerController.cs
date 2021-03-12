using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarTryApplicationMVC.Application.Interfaces;
using CarTryApplicationMVC.Application.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CarTryApplicationMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;
        public CustomerController(ICustomerService custService)
        {
            _custService = custService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _custService.GetAllCustomerForList(2,1,"");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _custService.GetAllCustomerForList(pageSize,pageNo.Value,searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new NewCustomerVm());
        }

        [HttpPost]
        public IActionResult AddCustomer(NewCustomerVm model)
        {
            var id = _custService.AddCustomer(model);
            return RedirectToAction("Index");
        }



        //[HttpGet]
        //public IActionResult AddNewAddressForClient(int cumstomerId)
        //{

        //}

        //public IActionResult ViewCustomer(int customerId)
        //{
        //    var customerModel = customerService.GetCustomerDetails(customerId);
        //    return View(customerModel);
        //}
    }
}
