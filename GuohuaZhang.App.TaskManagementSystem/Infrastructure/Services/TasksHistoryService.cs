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
    }
}
