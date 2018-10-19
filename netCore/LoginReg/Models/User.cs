using System;
using System.ComponentModel.DataAnnotations;

namespace LoginReg
{
    public class User
    {
        // [Key]
        public int UserId {get;}
        
        [Required]
        [MinLength(2)]
        public string FirstName {get; set;}
        
        [Required]
        [MinLength(2)]
        public string LastName {get; set;}
        
        [Required]
        [MinLength(2)]
        public string Username {get; set;}
        
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        
        [Required]
        [MinLength(8)]
        public string Password {get; set;}
        
        [Required]
        // [Range(0-299)]
        public int Age {get; set;}
        
        [Required]
        [MinLength(2)]
        public DateTime DateOfBirth {get; set;}
    }
}