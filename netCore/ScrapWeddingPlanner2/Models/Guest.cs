using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class Guest : BaseEntity
    {
        [Key]
        public int GuestId {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public int WeddingId {get; set;}
        public Wedding Wedding {get; set;}
    }
}