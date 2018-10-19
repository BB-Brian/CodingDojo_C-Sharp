using Microsoft.EntityFrameworkCore;
 
namespace LoginRegDemo.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> User {get; set;}
        public DbSet<Guest> guests {get; set;}
        public DbSet<Wedding> weddings {get; set;}
    }
}