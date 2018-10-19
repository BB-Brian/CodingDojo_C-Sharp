using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Auctions.Models;

namespace Auctions
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        [MinLength(2, ErrorMessage= "First Name must have at least 2 letters")]
        public string FirstName {get; set;}

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        [MinLength(2, ErrorMessage= "Last Name must have at least 2 letters")]
        public string LastName {get; set;}


        [Required]
        [MinLength(2, ErrorMessage= "Username must be between 3 and 20")]
        [MaxLength(20, ErrorMessage= "Username must be between 3 and 20")]
        public string Username {get; set;}
       
        [Required]
        [MinLength(8, ErrorMessage= "Password must have at least 8 characters.")]
        public string Password {get; set;}

        public int Balance {get; set;}

        public List<Auction> UserAuctions {get; set;}
        public List<Bid> UserBids {get; set;}
        public User()
        {
            Balance = 1000;
            UserAuctions = new List<Auction>();
            UserBids = new List<Bid>();
        }
    }
}