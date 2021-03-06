using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuohuaZhang.App.TaskManagementSystemMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly ICurrentUser _currentUser;
        private readonly IUsersService _usersService;

        public UserController(ITasksService tasksService, ICurrentUser currentUser,IUsersService usersService)
        {
            _tasksService = tasksService;
            _currentUser = currentUser;
            _usersService = usersService;
        }
        public async Task<IActionResult> Finish(int id)
        {
            var taskResponse = await _tasksService.GetTasksById(id);
            return View(taskResponse);
        }

        public async Task<IActionResult> ConfirmFinished(TasksResponseModel taskResponse)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return LocalRedirect("~/Account/Login");
            }
            await _usersService.ConfirmFinished(taskResponse);
            return RedirectToAction("Index", "Home");
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return LocalRedirect("~/Account/Login");
            }
            await _tasksService.DeleteTask(id);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Update(int id)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return LocalRedirect("~/Account/Login");
            }
            var taskResponse = await _tasksService.GetTasksById(id);
            return View(taskResponse);
         
        }

        public async Task<IActionResult> UpdateTask(TasksResponseModel tasksResponseModel)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return LocalRedirect("~/Account/Login");
            }
            await _tasksService.UpdateTask(tasksResponseModel);

            return RedirectToAction("Index", "Home");

        }
    }
}
