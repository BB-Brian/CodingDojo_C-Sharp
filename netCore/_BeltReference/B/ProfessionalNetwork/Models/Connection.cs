using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProfessionalNetwork.Models;

namespace ProfessionalNetwork
{
    public class Connection : BaseEntity
    {
        [Key]
        public int ConnectionId {get; set;}
        
        [InverseProperty("Follower")]
        public int FollowerId {get; set;}
        public User Follower {get; set;}

        [InverseProperty("UserFollowed")]
        public int UserFollowedId {get; set;}
        public User UserFollowed {get; set;}

        // public List<User> Invitations {get; set;} = new List<User>();

    }
}