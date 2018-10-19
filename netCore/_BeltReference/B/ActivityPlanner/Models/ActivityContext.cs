using Microsoft.EntityFrameworkCore;
 
namespace ActivityPlanner.Models
{
    public class ActivityContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options) { }

        public DbSet<User> users {get; set;}
        public DbSet<ActivityPlanned> activities {get; set;}
        public DbSet<Participant> participants {get; set;}
    }
}