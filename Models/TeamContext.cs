using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{

    public class TeamContext: DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options): base(options){

        }

        public DbSet<Team> teams {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Team>()
                .HasMany(t => t.activities)
                .WithOne(a => a.team)
                .HasForeignKey(t => t.activityId);
        }
    }

}