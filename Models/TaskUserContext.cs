using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{

    public class TaskUserContext: DbContext
    {
        public TaskUserContext(DbContextOptions<TaskUserContext> options): base(options){

        }

        public DbSet<TaskUser> taskUsers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<TaskUser>()
                .HasKey(tu => new {tu.taskId, tu.userId});

                modelBuilder.Entity<TaskUser>()
                .HasOne(tu => tu.task)
                .WithMany(t => t.taskUsers)
                .HasForeignKey(tu => tu.taskId);

                modelBuilder.Entity<TaskUser>()
                .HasOne(tu => tu.user)
                .WithMany(u => u.taskUsers)
                .HasForeignKey(tu => tu.userId);
        }
    }

}