using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuohuaZhang.App.TaskManagementSystemMVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _tasksService.GetTasksById(id);
            return View(task);
        }

        public async Task<IActionResult> NewTask()
        {
               
            return View();
        }

        public async Task<IActionResult> CreateNewTask(TaskRequestModel taskRequestModel)
        {
            if (!ModelState.IsValid)
            {
                //save to DB
                return View();
            }
            var taskResponse = _tasksService.AddTask(taskRequestModel);

            return RedirectToAction("Home/Index");
        }
    }
}
