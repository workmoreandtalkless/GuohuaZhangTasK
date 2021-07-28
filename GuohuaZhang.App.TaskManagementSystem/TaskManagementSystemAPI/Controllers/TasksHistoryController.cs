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
    public class TasksHistoryController : ControllerBase
    {
        private readonly ITasksHistoryService _tasksHistoryService;

        public TasksHistoryController(ITasksHistoryService tasksHistoryService)
        {
            _tasksHistoryService = tasksHistoryService;
        }

        //attribute based routing
        [HttpGet]
        [Route("TaskLists")]
        public async Task<IActionResult> GetTasksHistory()
        {

            var tasks = await _tasksHistoryService.GetTasksHistory();

            if (!tasks.Any())
            {
                return NotFound("No TasksHistory Found");
            }
            //NewtonSoft Json
            //SYSTEM.TEXT.JSON IN .NET CORE
            return Ok(tasks);
        }

        [HttpPost]
        [Route("AddTaskHistory")]
        public async Task<IActionResult> AddTask([FromBody] TaskHistoryRequestModel model)
        {
            var createdTask = await _tasksHistoryService.AddTaskHistory(model);

            return CreatedAtRoute("GetTaskHistoryById", new { id = createdTask.TaskId }, createdTask);

        }

        [HttpGet]
        [Route("{id:int}", Name = "GetTaskHistoryById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _tasksHistoryService.GetTasksHistoryById(id);
            if (task == null) return NotFound("don't have this Taskid");
            return Ok(task);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteTaskHistory(int id)
        {
            await _tasksHistoryService.DeleteTask(id);
            return NoContent();
        }
    }
}
