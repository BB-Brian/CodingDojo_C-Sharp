using System;
using ActivityPlanner.Models;

namespace ActivityPlanner
{
    public class BaseEntity
    {
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}