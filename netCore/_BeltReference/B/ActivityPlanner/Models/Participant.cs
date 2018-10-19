using System.ComponentModel.DataAnnotations;
using ActivityPlanner.Models;

namespace ActivityPlanner
{
    public class Participant : BaseEntity
    {
        [Key]
        public int ParticipantId {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public int ActivityPlannedId {get; set;}
        public ActivityPlanned Activity {get; set;}
    }
}