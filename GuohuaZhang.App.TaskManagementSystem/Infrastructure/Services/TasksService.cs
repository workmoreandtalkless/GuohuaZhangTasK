using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly ICurrentUser _currentUser;
        public TasksService(ITasksRepository tasksRepository , ICurrentUser currentUser)
        {
            _tasksRepository = tasksRepository;
            _currentUser = currentUser;
        }

        public async Task<TasksResponseModel> AddTask(TaskRequestModel model)
        {
            var task = await _tasksRepository.CheckTaskForUser(model.userid,model.Title);
            
            if (task)
            {
                throw new ConflictException("User has aready been asign this task");
            }

            var entity = new Tasks
            {
                userid = model.userid,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks
            };
           var task1 = await _tasksRepository.AddAsync(entity);
            var taskmodel = new TasksResponseModel
            {
                Id = task1.Id,
                userid = model.userid,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks

            };

            return taskmodel;
        }

        public async Task DeleteTask(int id,int uid)
        {
            if(_currentUser.UserId!=uid)
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to Delete Review");
            var task = await _tasksRepository.ListAsync(t => t.userid == uid && t.Id == id);
            await _tasksRepository.DeleteAsync(task.First());
        }

        public async Task DeleteTask(int id)
        {
            var taskHistory = await _tasksRepository.ListAsync(t => t.Id == id);
            await _tasksRepository.DeleteAsync(taskHistory.First());
        }

        /*  public Task DeleteTask()
          {

          }*/

        public async Task<List<TasksResponseModel>> GetTasks()
        {
            var tasks = await _tasksRepository.GetTasks();

            var tasksModels = new List<TasksResponseModel>();
            foreach(var task in tasks)
            {
                tasksModels.Add(new TasksResponseModel
                {
                    Id = task.Id,
                    userid = task.userid,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks

                });
            }

            return tasksModels;
        }

        public async Task<TasksResponseModel> GetTasksById(int id)
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            var taskModel = new TasksResponseModel
            {
                Id = task.Id,
                userid = task.userid,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Remarks = task.Remarks

            };

            return taskModel;

        }

        public async Task<List<TasksResponseModel>> GetTasksByUserId(int uid)
        {
            var tasks = await _tasksRepository.GetTasksByuserid(uid);
            var tasksModels = new List<TasksResponseModel>();
            foreach (var task in tasks)
            {
                tasksModels.Add(new TasksResponseModel
                {
                    Id = task.Id,
                    userid = task.userid,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks

                });
            }

            return tasksModels;
        }

        public async Task<TasksResponseModel> GetTasksByUserIdandTitle(int uid, string title)
        {
            var task = await _tasksRepository.GetTaskByUserIdandTitle(uid, title);
            var taskModel = new TasksResponseModel
            {
                userid = task.userid,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Remarks = task.Remarks

            };

            return taskModel;
        }

        public async Task UpdateTask(TasksResponseModel model)
        {
           /* if(_currentUser.UserId!= model.userid)
            {
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to Review");
            }*/

            var entity = new Tasks
            {   Id = model.Id,
                userid = model.userid,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Remarks = model.Remarks
            };

            await _tasksRepository.UpdateAsync(entity);
        }
    }
}
