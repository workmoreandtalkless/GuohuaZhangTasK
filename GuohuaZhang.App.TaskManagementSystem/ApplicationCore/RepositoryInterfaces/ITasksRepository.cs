using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
   public interface ITasksRepository :IAsyncRepository<Tasks>
    {
        Task<List<Tasks>> GetTasks();
        Task<List<Tasks>> GetTasksByuserid(int uid);
        Task<bool> CheckTaskForUser(int uid, string Title);
        Task<Tasks> GetTaskByUserIdandTitle(int uid, string title);
    }
}
