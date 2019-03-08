using Microsoft.EntityFrameworkCore;

namespace Taskbook_ASPNETCore.Models{

    public class ResponseContext: DbContext
    {
        public ResponseContext(DbContextOptions<ResponseContext> options): base(options){

        }

        public DbSet<Response> responses {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Response>()
            .HasOne(r => r.activity)
            .WithMany(a => a.responses)
            .HasForeignKey(r => r.activityId);
        }
    }

}