using Microsoft.EntityFrameworkCore;
 
namespace LoginReg.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> users;
        // make sure "users" is lowercased - due to MySql's auto lowercasing setting - which can be overwritten in MySql by changing the setting for it

    }
}