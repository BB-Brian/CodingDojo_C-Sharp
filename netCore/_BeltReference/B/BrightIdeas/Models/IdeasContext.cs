using Microsoft.EntityFrameworkCore;
 
namespace BrightIdeas.Models
{
    public class IdeasContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public IdeasContext(DbContextOptions<IdeasContext> options) : base(options) { }

        public DbSet<User> users {get; set;}
        public DbSet<Post> posts {get; set;}
        public DbSet<Like> likes {get; set;}
    }
}