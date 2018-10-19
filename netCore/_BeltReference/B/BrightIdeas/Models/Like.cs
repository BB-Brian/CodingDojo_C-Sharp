using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BrightIdeas.Models;

namespace BrightIdeas
{
    public class Like : BaseEntity
    {
        [Key]
        public int LikeId {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public int PostId {get; set;}
        public Post Post {get; set;}
    }
}