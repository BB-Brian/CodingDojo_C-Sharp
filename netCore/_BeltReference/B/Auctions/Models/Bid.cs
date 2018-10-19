using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Auctions.Models;

namespace Auctions
{
    public class Bid : BaseEntity
    {
        [Key]
        public int BidId {get; set;}
        public int BidAmount {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public int AuctionId {get; set;}
        public Auction Auction {get; set;}
    }
}