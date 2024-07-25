using Microsoft.AspNetCore.Identity;

namespace HomeworkPlatformAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public UserType Type { get; set; }
        //public ICollection<Assignment> Assignments { get; set; }
    }

    /*public enum UserType
    {
        Student,
        Teacher,
        Admin
    }*/
}
