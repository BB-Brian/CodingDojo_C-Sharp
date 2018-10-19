using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LoginRegDemo.Models
{
    public class Account
    {
        [Key]
        public int AccountId {get; set;}
        public double Balance {get; set;}

        public int UserId {get; set;}

        public User User {get; set;}

        public List<Transaction> transactions { get; set; }
 
        public Account ()
        {
            transactions = new List<Transaction>();
        }

    }
}