using HomeworkPlatformAPI.DTOs.Abstractions;

namespace HomeworkPlatformAPI.DTOs.Responces
{
    public class AssignmentResponseDTO : BaseDTO
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
