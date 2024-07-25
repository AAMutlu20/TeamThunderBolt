using HomeworkPlatformAPI.DTOs.Abstractions;

namespace HomeworkPlatformAPI.DTOs.Requests
{
    public class AssignmentRequestDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
