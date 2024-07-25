using System.ComponentModel.DataAnnotations;

namespace HomeworkPlatformAPI.DTOs.Requests
{
    public class UserRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
