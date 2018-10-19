using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProfessionalNetwork.Models;

namespace ProfessionalNetwork
{
    public class User : BaseEntity
    {

        [Key]
        public int UserId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage= "Name must have at least 2 letters")]
        public string Name {get; set;}


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$", ErrorMessage = "Invalid email format.")]
        public string Email {get; set;}
       
        [Required]
        [MinLength(8, ErrorMessage= "Password must have at least 8 characters.")]
        public string Password {get; set;}
        
        [Required]
        public string Description {get; set;}
        

        public List<Connection> Followers {get; set;}

        public List<Connection> UsersFollowed {get; set;}

        public User()
        {
            Followers = new List<Connection>();
            UsersFollowed = new List<Connection>();
            // Invitations = new List<Connection>();
        }

        
        // public List<Connection> Invitations {get; set;}

    }
}