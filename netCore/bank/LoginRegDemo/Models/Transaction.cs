
using System;
using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get; set;}

        public double Amount {get; set;}

        public DateTime Date {get; set;}

        public Transaction()
        {
            Date = DatTime.Now;
        }



    }
}