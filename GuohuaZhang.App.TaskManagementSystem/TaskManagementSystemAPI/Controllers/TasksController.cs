using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        //attribute based routing
        [HttpGet]
        [Route("TaskLists")]
        public async Task<IActionResult> GetTasks()
        {
            
            var tasks = await _tasksService.GetTasks();

            if (!tasks.Any())
            {
                return NotFound("No Movies Found");
            }
            //NewtonSoft Json
            //SYSTEM.TEXT.JSON IN .NET CORE
            return Ok(tasks);
        }

        [HttpPost]
        [Route("AddTask")]
        public async Task<IActionResult> AddTask([FromBody] TaskRequestModel model)
        {
            var createdTask = await _tasksService.AddTask(model);
          
            return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, createdTask);

        }

        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] TasksResponseModel model)
        {
            await _tasksService.UpdateTask(model);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id:int}",Name ="GetTaskById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _tasksService.GetTasksById(id);
            if (task == null) return NotFound("don't have this id");
            return Ok(task);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteTask(int id,int uid)
        {
            await _tasksService.DeleteTask(id,uid);
            return NoContent();
        }
/*        [HttpGet]
        [Route("{id:int}/Tasks",Name ="GetTasksByUserId")]
        public async Task<IActionResult> GetTasksByUserId(int uid)
        {
            var task = await _tasksService.GetTasksByUserId(uid);
            if (task == null) return NotFound("this use didn't have any task");

            return Ok(task);
        }
        [HttpGet]
        [Route("{id:int}/{title}/Tasks", Name = "GetTasksByIdandTitle")]
        public async Task<IActionResult> GetTasksByUserIdandTitle(int uid,string title)
        {
            var task = await _tasksService.GetTasksByUserIdandTitle(uid,title);
            if (task == null) return NotFound("this use didn't have any task");

            return Ok(task);
        }*/
    }
}
