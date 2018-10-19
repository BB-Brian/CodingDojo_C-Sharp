using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage="First name must be at least 4 characters.")]
        public string fname{get; set;}

        [Required]
        [MinLength(4, ErrorMessage="Last name must be at least 4 characters.")]
        public string lname{get; set;}

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Age must be a positive number.")]        
        public int age{get; set;}

        [Required]
        [EmailAddress(ErrorMessage = "Must be valid email format")]
        public string email{get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters.")]
        public string password{get; set;}

    }

}