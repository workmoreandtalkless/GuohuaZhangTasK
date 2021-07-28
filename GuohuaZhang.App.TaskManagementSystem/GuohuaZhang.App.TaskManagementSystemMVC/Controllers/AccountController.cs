using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GuohuaZhang.App.TaskManagementSystemMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ITasksService _tasksService;
        public AccountController(IUsersService usersService , ITasksService tasksService)
        {
            _usersService = usersService;
            _tasksService = tasksService;
        }
        //method for register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            //save the data only when Model validation passes
            if (!ModelState.IsValid)
            {
                //save to DB
                return View();
            }
            var createUser = await _usersService.RegisterUser(model);
            //redirect to login page

            //Model Binding not case senstive
            return RedirectToAction("Login");

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _usersService.Login(model.Email, model.Password);

            if (user == null)
            {
                // wrong password
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Name, user.FullName),
                 new Claim(ClaimTypes.MobilePhone, user.Mobileno),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // identity object
            // HttpContext : 

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect("~/");

 

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Profile(int id)
        {
           /* var user = await _tasksService.GetTasksByUserId(id);*/
            var user = await _usersService.GetUserById(id);
            return View(user);
        }
        public async Task<IActionResult> EditProfile(int id)
        {
            var user = await _usersService.EidtProfile(id);

            return View(user);

        }
    }
}
