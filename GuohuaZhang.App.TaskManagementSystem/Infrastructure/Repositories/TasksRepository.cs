using ApplicationCore.Entities;
using ApplicationCore.Entities;

using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TasksRepository : EfRepository<Tasks>, ITasksRepository
    {
        public TasksRepository(TaskDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> CheckTaskForUser(int uid, string Title)
        {
            var task = await _dbContext.Tasks.Where(t => t.userid == uid && t.Title == Title).AnyAsync();
            return task;
        }

        public async Task<Tasks> GetTaskByUserIdandTitle(int uid, string title)
        {
            var task = await _dbContext.Tasks.Where(t => t.userid == uid && t.Title == title).FirstOrDefaultAsync();
            return task;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return tasks;
        }

        public async Task<List<Tasks>> GetTasksByuserid(int uid)
        {
            var tasks = await _dbContext.Tasks.Where(t => t.userid == uid).ToListAsync();
            return tasks;
        }
    }
}
