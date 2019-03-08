using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{

    public class TaskContext: DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options): base(options){

        }

        public DbSet<Task> tasks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Task>()
            .HasOne(t => t.activity)
            .WithMany(a => a.tasks)
            .HasForeignKey(t => t.activityId);
        }
    }

}