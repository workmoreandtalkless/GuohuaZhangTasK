using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITasksHistoryService
    {
        Task<List<TasksHistoryCardResponseModel>> GetRecentTask();
        Task<List<TasksHistoryCardResponseModel>>GetTasksHistory();
        Task<TaskHistoryResponseModel> AddTaskHistory(TaskHistoryRequestModel model);
        Task<TaskHistoryResponseModel> GetTasksHistoryById(int id);
        Task DeleteTask(int id);
        Task<int> GetCount();
    }
}
