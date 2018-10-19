using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage= "First Name must have at least 2 letters")]
        public string FirstName {get; set;}

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage= "Last Name must have at least 2 letters")]
        public string LastName {get; set;}


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$", ErrorMessage = "Invalid email format.")]
        public string Email {get; set;}
       
        [Required]
        [MinLength(8, ErrorMessage= "Password must have at least 8 characters.")]
        public string Password {get; set;}

        public List<Wedding> UserWeddings {get; set;}
        public List<Guest> UserRSVPs {get; set;}
        public User()
        {
            UserWeddings = new List<Wedding>();
            UserRSVPs = new List<Guest>();
        }
    }
}