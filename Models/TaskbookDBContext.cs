using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{
    public class TaskbookDBContext : IdentityDbContext<User>
    {

        public TaskbookDBContext(DbContextOptions<TaskbookDBContext> options): base(options){
            
        }

        public DbSet<Activity> activities {get; set;}
        public DbSet<Response> responses {get; set;}
        public DbSet<Task> tasks {get; set;}
        public DbSet<Team> teams {get; set;}
        public DbSet<User> users {get; set;}
        public DbSet<TeamUser> teamUsers {get; set;}
        public DbSet<TaskUser> taskUsers {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);
                
            //Activity
            modelBuilder.Entity<Activity>()
            .HasOne(a => a.team)
            .WithMany(t => t.activities)
            .HasForeignKey(a => a.teamId);

            //Task
            modelBuilder.Entity<Task>()
            .HasOne(t => t.activity)
            .WithMany(a => a.tasks)
            .HasForeignKey(t => t.activityId);

            //Response
            modelBuilder.Entity<Response>()
            .HasOne(r => r.activity)
            .WithMany(a => a.responses)
            .HasForeignKey(r => r.activityId);

            modelBuilder.Entity<Response>()
            .HasOne(r => r.user)
            .WithOne(u => u.response)
            .HasForeignKey<User>(u => u.responseId);

            //TeamUser
            modelBuilder.Entity<TeamUser>()
            .HasKey(tu => new {tu.teamId, tu.userId});

            modelBuilder.Entity<TeamUser>()
            .HasOne(tu => tu.team)                          //muchos teamUsers tiene un team
            .WithMany(t => t.teamUsers)                     //un team tiene muchos teamUsers
            .HasForeignKey(tu => tu.teamId);                //un team user tiene una llave foranea de team

            modelBuilder.Entity<TeamUser>()
            .HasOne(tu => tu.user)
            .WithMany(u => u.teamUsers)
            .HasForeignKey(tu => tu.userId);

            //TaskUser
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