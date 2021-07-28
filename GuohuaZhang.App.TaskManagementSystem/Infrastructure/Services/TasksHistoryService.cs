using ApplicationCore.Entities;
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
    public class TasksHistoryService : ITasksHistoryService
    {
        private readonly ITasksHistoryRepository _tasksHistoryRepository;
        public TasksHistoryService(ITasksHistoryRepository tasksHistoryRepository)
        {
            _tasksHistoryRepository = tasksHistoryRepository;
        }

        public async Task<TaskHistoryResponseModel> AddTaskHistory(TaskHistoryRequestModel model)
        {
            var entity = new TaskHistory
            {
                TaskId = model.TaskId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Remarks = model.Remarks
            };
            var task1 = await _tasksHistoryRepository.AddAsync(entity);
            var taskmodel = new TaskHistoryResponseModel
            {
                TaskId = task1.TaskId,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Remarks = model.Remarks

            };

            return taskmodel;
        }

        public async Task DeleteTask(int id)
        {
            
            var taskHistory = await _tasksHistoryRepository.ListAsync(t => t.TaskId == id);
            await _tasksHistoryRepository.DeleteAsync(taskHistory.First());
        }

        public async Task<List<TasksHistoryCardResponseModel>> GetRecentTask()
        {
            var taskHistories = await _tasksHistoryRepository.GetRecent30Task();

            var taskCard = new List<TasksHistoryCardResponseModel>();

            foreach(var TaskHistory in taskHistories)
            {
                taskCard.Add(new TasksHistoryCardResponseModel
                {
                    TaskId = TaskHistory.TaskId,
                    UserId = TaskHistory.UserId,
                    Title = TaskHistory.Title,
                    Description = TaskHistory.Description,
                    DueDate = TaskHistory.DueDate,
                    Completed = TaskHistory.Completed,
                    Remarks = TaskHistory.Remarks

                });
            }

            return taskCard;
        }

        public async Task<List<TasksHistoryCardResponseModel>> GetTasksHistory()
        {
            var tasksHistories = await _tasksHistoryRepository.ListAllAsync();
            var taskCard = new List<TasksHistoryCardResponseModel>();

            foreach (var TaskHistory in tasksHistories)
            {
                taskCard.Add(new TasksHistoryCardResponseModel
                {
                    TaskId = TaskHistory.TaskId,
                    UserId = TaskHistory.UserId,
                    Title = TaskHistory.Title,
                    Description = TaskHistory.Description,
                    DueDate = TaskHistory.DueDate,
                    Completed = TaskHistory.Completed,
                    Remarks = TaskHistory.Remarks

                });
            }

            return taskCard;
        }

        public async Task<TaskHistoryResponseModel> GetTasksHistoryById(int id)
        {
            var taskHistory = await _tasksHistoryRepository.GetByIdAsync(id);
            var taskModel = new TaskHistoryResponseModel
            {
                TaskId = taskHistory.TaskId,
                UserId = taskHistory.UserId,
                Title = taskHistory.Title,
                Description = taskHistory.Description,
                DueDate = taskHistory.DueDate,
                Remarks = taskHistory.Remarks

            };

            return taskModel;
        }
    }
}
