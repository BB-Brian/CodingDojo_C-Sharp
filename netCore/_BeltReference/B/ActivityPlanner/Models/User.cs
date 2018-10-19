using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ActivityPlanner.Models;

namespace ActivityPlanner
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        // public List<Activity> CreatedActivities {get; set;}
        // public User()
        // {
        //     CreatedActivities = new List<Activity>();
        // }

        // public List<Participant> = ActivitiesAttending {get; set}
    
    }
}