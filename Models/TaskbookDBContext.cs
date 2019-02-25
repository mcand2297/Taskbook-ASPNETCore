using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{
    public class TaskbookDBContext : DbContext
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

                //Team
                modelBuilder.Entity<Team>()
                .HasMany(t => t.activities)
                .WithOne(a => a.team)
                .HasForeignKey(t => t.activityId);

                //Activity
                modelBuilder.Entity<Activity>()
                .HasMany(a => a.responses)
                .WithOne(r => r.activity)
                .HasForeignKey(a => a.responseId);

                modelBuilder.Entity<Activity>()
                .HasMany(a => a.tasks)
                .WithOne(t => t.activity)
                .HasForeignKey(a => a.taskId);

                //Response
                modelBuilder.Entity<Response>()
                .HasOne(r => r.user)
                .WithOne(u => u.response)
                .HasForeignKey<User>(r => r.userId);


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