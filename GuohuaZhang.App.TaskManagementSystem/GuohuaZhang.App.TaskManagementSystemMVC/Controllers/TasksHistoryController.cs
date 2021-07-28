﻿using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuohuaZhang.App.TaskManagementSystemMVC.Controllers
{
    public class TasksHistoryController : Controller
    {
        private readonly ITasksHistoryService _tasksHistoryService;
        public TasksHistoryController(ITasksHistoryService tasksHistoryService)
        {
            _tasksHistoryService = tasksHistoryService;

        }
        public async Task<IActionResult> ShowHistory()
            
        {
            var taskHistory = await _tasksHistoryService.GetRecentTask();
            return View(taskHistory);
        }
    }
}