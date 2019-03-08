using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{

    public class TeamUserContext: DbContext
    {
        
        public TeamUserContext(DbContextOptions<TeamUserContext> options): base(options){

        }

        public DbSet<TeamUser> teamUsers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
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
        }
    }

}