﻿using Address_Book.DTO.Read;
using Address_Book.DTO.Write;
using Address_Book.Models;
using Address_Book.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService customerService;

        public HomeController(ICustomerService customerService)
        {
            //this._customerRepository = customerRepository;
            this.customerService = customerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await customerService.GetCustomerList();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int customerId)
        {
            var model = await customerService.GetCustomer(customerId);
            ViewBag.PageTitle = "Employee Details";
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await customerService.CreateCustomer(model);
                return RedirectToAction("details", new { customerId = customer });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Customer customer = await customerService.GetCustomer(id);
            CustomerEditViewModel customerEditViewModel = new()
            {
                Id = customer.Id,
                Name = customer.Name,
                DateOfBirth = customer.DateOfBirth,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };
            return View(customerEditViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await customerService.UpdateCustomer(model);
                return RedirectToAction("index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int customerId)
        {
            Customer model = await customerService.GetCustomer(customerId);
            if (ModelState.IsValid)
            {
                await customerService.DeleteCustomer(model.Id);
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
