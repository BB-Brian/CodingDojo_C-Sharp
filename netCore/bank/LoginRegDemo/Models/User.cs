using System.ComponentModel.DataAnnotations;

namespace LoginRegDemo
{
    public class User
    {
        public int UserId {get; set;}

        [Required(ErrorMessage   = "Must have first name")]
        [MinLength(2)]

        public string FirstName {get; set;}
        [Required(ErrorMessage = "Must have last name")]
        [MinLength(2)]


        public string LastName {get; set;}

        [MinLength(2)]
        [Required(ErrorMessage = "Must have email")]


        public string Email {get; set;}
        [Required(ErrorMessage = "Must have must have password")]
        [MinLength(8)]
        public string Password {get; set;}

    }
}

