using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public List<Guest> RSVPs {get; set;}
        public User()
        {
            RSVPs = new List<Guest>();
        }
    }
}