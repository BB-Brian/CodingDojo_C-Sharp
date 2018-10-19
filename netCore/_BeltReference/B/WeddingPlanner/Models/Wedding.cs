using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int WeddingId {get; set;}

        [Required(ErrorMessage = "Wedder One cannot be blank")]
        public string WedderOne {get; set;}


        [Required(ErrorMessage = "Wedder Two cannot be blank")]
        public string WedderTwo {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyy}")]
        public DateTime Date {get; set;}
        

        [Required(ErrorMessage = "Address cannot be blank")]
        public string Address {get; set;}

        public int UserId {get; set;}
        public User User {get; set;}
        public List<Guest> Guests {get; set;}
        public Wedding()
        {
            Guests = new List<Guest>();
        }
    }
}