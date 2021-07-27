using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuohuaZhang.App.TaskManagementSystemMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
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
            /* //save the data only when Model validation passes
             if (!ModelState.IsValid)
             {
                 //save to DB
                 return View();
             }
             var createUser = await _userService.RegisterUser(model);
             //redirect to login page

             //Model Binding not case senstive
             return RedirectToAction("Login");*/

            return View();
        }
    }
}
