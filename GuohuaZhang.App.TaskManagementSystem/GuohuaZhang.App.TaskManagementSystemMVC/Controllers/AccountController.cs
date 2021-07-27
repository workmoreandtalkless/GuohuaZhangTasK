﻿using ApplicationCore.Models;
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

            return View();
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

            var user = await _userService.Login(model.Email, model.Password);

            if (user == null)
            {
                // wrong password
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.GivenName, user.FirstName),
                 new Claim(ClaimTypes.Surname, user.LastName),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // identity object

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect("~/");

            // HttpContext
            // URL, Http method type, form body, browser, Ip address, 

            // correct pasword
            // display, FirstName, LastName, Email
            // Button/Link Logout
            // Cookie Based Authentication....

            // 10:00 AM you login website success
            // created a MovieShopAuthCookie => 2 hours
            // Claims, firstname, lastname, id, email - encrypt this info and store in cookie
            // Every time you make a send a request from browser to server => Cookies are sent to server automatiaclly

            // make sure user is login successfully
            // movies/details/22 => Buy Button
            // when u click on BUY Button => POST
            // Purchase table => movieid, userid
            // user/buymovie => should take userid from cookie and send to Database
            // 10:15 AM you wanna buy a movie 
            // 10:30 AM you wanna fav a movie

            return View();
        }

    }
}
