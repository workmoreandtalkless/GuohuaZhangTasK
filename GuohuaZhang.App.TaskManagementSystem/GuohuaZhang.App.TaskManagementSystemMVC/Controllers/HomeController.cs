using ApplicationCore.ServiceInterfaces;
using GuohuaZhang.App.TaskManagementSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GuohuaZhang.App.TaskManagementSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly ITasksHistoryService _taskHistoryService;
        private readonly ITasksService _taskService;
        public HomeController(ITasksHistoryService taskHistoryService, ITasksService taskService)
        {
            _taskHistoryService = taskHistoryService;
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            /*var taskshistories = await _taskHistoryService.GetRecentTask();
            ViewBag.TasksHistoryCount = taskshistories.Count();*/

            var recentTask = await _taskService.GetTasks();
            return View(recentTask);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
