using Microsoft.EntityFrameworkCore;
 
namespace ProfessionalNetwork.Models
{
    public class NetworkContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public NetworkContext(DbContextOptions<NetworkContext> options) : base(options) { }

        public DbSet<User> users {get; set;}
        public DbSet<Connection> connections {get; set;}
        
        // public DbSet<Invitation> invitations {get; set;}
    }
}