using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BrightIdeas.Models;

namespace BrightIdeas
{
    public class Post : BaseEntity
    {
        [Key]
        public int PostId {get; set;}
        
        [Required]
        [MinLength(1, ErrorMessage= "Post cannot be blank")]
        public string Content {get; set;}
        
        public int  UserId {get; set;}
        public User User {get; set;}
        public List<Like> likes {get; set;}
        public Post()
        {
            likes = new List<Like>();
        }
    }
}