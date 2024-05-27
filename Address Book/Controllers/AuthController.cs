using Address_Book.Services.Administration.Interface;
using Address_Book.Services.DTO.WriteOnly;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAdminService adminService;

        public AuthController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTOw model, string returnUrl)
        {

            if (string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                var result = await adminService.Register(model.FirstName, model.LastName, model.Email, model.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(model);
                }
                return Redirect(returnUrl);
            }

            return RedirectToAction("EmployeeNotFound", "home");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            try
            {
                var user = await adminService.IsEmailInUse(email);

                if (user)
                {
                    return Json(false);
                }
                else
                {
                    return Json(true);
                }
            }
            catch { throw; }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTOw model, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    var result = await adminService.Login(model.Email, model.Password, model.RememberMe);

                    if (result.Succeeded) return Redirect(returnUrl);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, result.Message);
                        return View(model);
                    }
                }

                return RedirectToAction("EmployeeNotFound", "home");
            }
            catch { throw; }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await adminService.Logout();
                return RedirectToAction("index", "home");
            }
            catch { throw; }
        }
    }
}
