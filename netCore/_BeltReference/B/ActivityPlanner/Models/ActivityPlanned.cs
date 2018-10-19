using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ActivityPlanner.Models;

namespace ActivityPlanner
{
    public class ActivityPlanned : BaseEntity
    {
        [Key]
        public int ActivityPlannedId {get; set;}
        public string Title {get; set;}
        public DateTime DateTime {get; set;}
        public int Duration {get; set;}
        public string DurationType {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public List<Participant> participants {get; set;}
        public ActivityPlanned()
        {
            participants = new List<Participant>();
        }
    }
}