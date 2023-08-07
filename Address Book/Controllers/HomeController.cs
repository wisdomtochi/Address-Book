using Address_Book.Models;
using Address_Book.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _customerRepository.CustomersList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var model = _customerRepository.GetCustomer(id ?? 1);
            ViewBag.PageTitle = "Employee Details";
            return View(model);
        }

        [HttpGet]
        public IActionResult Create([FromRoute] int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };
                var customer = _customerRepository.Add(newCustomer);
                return RedirectToAction("details", new { customer.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Customer customer = _customerRepository.GetCustomer(id);
            CustomerEditViewModel customerEditViewModel = new CustomerEditViewModel
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
        public IActionResult Edit(CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _customerRepository.GetCustomer(model.Id);
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.DateOfBirth = model.DateOfBirth;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;

                _customerRepository.Update(customer);
                return RedirectToAction("index");
            }
            return View();
        }

    }
}
