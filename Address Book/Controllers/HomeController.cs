using Address_Book.Domain;
using Address_Book.Services.Customers.Interfaces;
using Address_Book.Services.DTO.WriteOnly;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService customerService;

        public HomeController(ICustomerService customerService)
        {
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
        public async Task<IActionResult> Details(Guid Id)
        {
            var customer = await customerService.GetCustomer(Id);

            if (customer == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id);
            }
            ViewBag.PageTitle = "Employee Details";
            return View(customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerCreateDTOw();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CustomerCreateDTOw model)
        {
            if (ModelState.IsValid)
            {
                var customer = await customerService.CreateCustomer(model);
                return RedirectToAction("details", new { Id = customer });
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            Customer customer = await customerService.GetCustomer(id);
            CustomerEditDTOw customerEditViewModel = new()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };
            return View(customerEditViewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(CustomerEditDTOw model)
        {
            if (ModelState.IsValid)
            {
                await customerService.UpdateCustomer(model);
                return RedirectToAction("index");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            Customer model = await customerService.GetCustomer(Id);
            if (ModelState.IsValid)
            {
                await customerService.DeleteCustomer(model.Id);
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
