﻿using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
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


    }
}
