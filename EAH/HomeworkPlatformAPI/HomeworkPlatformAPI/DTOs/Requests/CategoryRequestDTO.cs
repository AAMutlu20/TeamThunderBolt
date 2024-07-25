using HomeworkPlatformAPI.DTOs.Abstractions;

namespace HomeworkPlatformAPI.DTOs.Requests
{
    public class CategoryRequestDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Subject { get; set; }
    }
}
