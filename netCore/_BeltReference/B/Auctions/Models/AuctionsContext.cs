using System;
using Microsoft.EntityFrameworkCore;
 
namespace Auctions.Models
{
    public class AuctionsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AuctionsContext(DbContextOptions<AuctionsContext> options) : base(options) { }

        public DbSet<User> users {get; set;}
        public DbSet<Auction> auctions {get; set;}
        public DbSet<Bid> bids {get; set;}
    }
}