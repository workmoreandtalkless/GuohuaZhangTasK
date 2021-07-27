using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TasksHistoryRepository : EfRepository<TasksHistory>, ITasksHistoryRepository
    {
        public TasksHistoryRepository(TaskDbContext dbContext) : base(dbContext)
        {

        }
    }
}
