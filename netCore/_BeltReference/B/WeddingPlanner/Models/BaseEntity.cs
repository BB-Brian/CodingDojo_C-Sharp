using System;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class BaseEntity
    {
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}