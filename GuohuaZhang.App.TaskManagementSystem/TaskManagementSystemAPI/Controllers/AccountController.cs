using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUsersService _usersService;
        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel model)
        {
            var createdUser = await _usersService.RegisterUser(model);
            return CreatedAtRoute("GetUser", new { id = createdUser.Id }, createdUser); //201
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _usersService.GetUserById(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("{Email}")]
        public async Task<IActionResult> EmailExists(string email)
        {
            var user = await _usersService.GetUser(email);
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _usersService.GetUser();
            if (users == null)
            {
                return NotFound("Users Not Found");
            }
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegisterRequestModel model)
        {
            await _usersService.UpdateUser(model);
            return Ok();
        }



    }
}
