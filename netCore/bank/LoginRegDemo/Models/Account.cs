using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo
{
    public class Account
    {
        [Key]
        public int AccountId {get; set;}

        public double Balance {get; set;}
        //[ForiegnKey]
        public int UserId {get; set;}

        public User User {get; set;}
        public List<Transaction> transactions { get; set; }
 
        public Account()
        {
            transactions = new List<Subscription>();
        }
    }
    
}