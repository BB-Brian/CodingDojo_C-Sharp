using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Auctions.Models;

namespace Auctions
{
    public class Auction : BaseEntity
    {
        [Key]
        public int AuctionId {get; set;}
        
        [Required]
        [MinLength(3, ErrorMessage= "Product name must be greather than 3 characters")]
        public string Product {get; set;}

        [Required]
        public int StartingBid {get; set;}

        [Required]
        [MinLength(1, ErrorMessage= "Description cannot be blank")]
        public string Description {get; set;}

        [Required(ErrorMessage= "Auction end date required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyy}")]
        public DateTime EndDate {get; set;}
        
        public int  UserId {get; set;}
        public User User {get; set;}
        public List<Bid> bids {get; set;}
        public Auction()
        {
            bids = new List<Bid>();
        }
    }
}