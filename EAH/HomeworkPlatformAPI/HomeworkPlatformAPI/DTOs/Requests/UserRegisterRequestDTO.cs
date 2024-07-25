using System.ComponentModel.DataAnnotations;

namespace HomeworkPlatformAPI.DTOs.Requests
{
    public class UserRegisterRequestDTO
    {

        [EmailAddress]
        public string Email { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
