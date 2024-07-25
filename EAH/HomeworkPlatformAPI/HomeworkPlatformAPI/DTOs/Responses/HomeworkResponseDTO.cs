using HomeworkPlatformAPI.DTOs.Abstractions;

namespace HomeworkPlatformAPI.DTOs.Responces
{
    public class HomeworkResponseDTO : BaseDTO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int AssignmentId { get; set; }
    }
}
