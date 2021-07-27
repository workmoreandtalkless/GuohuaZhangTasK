using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
   public interface ITasksService
    {
        Task<List<TasksResponseModel>> GetTasks();
        Task<List<TasksResponseModel>> GetTasksByUserId(int uid);
       Task<TasksResponseModel> AddTask(TaskRequestModel model);
       Task<TasksResponseModel> GetTasksByUserIdandTitle(int uid, string title);
        Task<TasksResponseModel> GetTasksById(int id);
    }
}
