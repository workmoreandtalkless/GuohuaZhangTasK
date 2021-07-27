using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TasksHistory> TasksHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //this is a virtual method from DbContext
        {
            modelBuilder.Entity<Users>(ConfigureUsers);
            modelBuilder.Entity<Tasks>(ConfigureTasks);
            modelBuilder.Entity<TasksHistory>(ConfigureTasksHistory);
        }
        private void ConfigureUsers(EntityTypeBuilder<Users> builder)
        {
            // specify all the fluent api rules for this model

            builder.ToTable("Users");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).HasMaxLength(50);
            builder.Property(m => m.Password).HasMaxLength(10).IsRequired();
            builder.Property(m => m.Fullname).HasMaxLength(50);
            builder.Property(m => m.Mobileno).HasMaxLength(50);

        }

        private void ConfigureTasks(EntityTypeBuilder<Tasks> builder)
        {
            // specify all the fluent api rules for this model

            builder.ToTable("Tasks");
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.Users).WithMany(m => m.Tasks).HasForeignKey(m => m.userid);
            builder.Property(m => m.Title).HasMaxLength(50);
            builder.Property(m => m.Priority).HasMaxLength(1);
            builder.Property(m => m.Remarks).HasMaxLength(500);
            
        }

        private void ConfigureTasksHistory(EntityTypeBuilder<TasksHistory> builder)
        {
            // specify all the fluent api rules for this model

            builder.ToTable("TasksHistory");
            builder.HasKey(m => m.TaskId);
            builder.HasOne(m => m.Users).WithMany(m => m.TasksHistories).HasForeignKey(m => m.UserId);
            builder.Property(m => m.UserId);
            builder.Property(m => m.Title).HasMaxLength(50);
            builder.Property(m => m.Description).HasMaxLength(500);
            builder.Property(m => m.Completed).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Remarks).HasMaxLength(500);

        }
    }
}
