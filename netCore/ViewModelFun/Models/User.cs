namespace ViewModelFun.Models
{
    public class User
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public User(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
        }
    }
}