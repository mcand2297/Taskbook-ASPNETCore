using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{

    public class ActivityContext: DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options): base(options){

        }

        public DbSet<Activity> activities {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Activity>()
            .HasOne(a => a.team)
            .WithMany(t => t.activities)
            .HasForeignKey(a => a.teamId);

        }
    }

}