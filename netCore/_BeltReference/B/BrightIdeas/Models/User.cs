using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrightIdeas.Models;

namespace BrightIdeas
    {
    public class User: BaseEntity
    {
        [Key]
        public int UserId {get;set;}


        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage= "Name must have at least 2 letters")]
        public string Name {get;set;}


        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Alias can only contain letters")]
        [Required]
        [MinLength(2, ErrorMessage= "Alias must have at least 2 letters")]
        public string Alias {get;set;}


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$", ErrorMessage = "Invalid email format.")]
        public string Email {get;set;}


        [Required]
        [MinLength(8, ErrorMessage= "Password must have at least 8 characters.")]
        public string Password {get;set;}

        public List<Post> userpostlist {get; set;}
        public List<Like> userlikelist {get; set;}

        public User()
        {
            userpostlist = new List<Post>();
            userlikelist = new List<Like>();
        }
    }
}