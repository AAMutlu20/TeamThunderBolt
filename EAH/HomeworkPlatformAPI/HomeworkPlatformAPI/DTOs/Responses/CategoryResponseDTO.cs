using HomeworkPlatformAPI.DTOs.Abstractions;

namespace HomeworkPlatformAPI.DTOs.Responces
{
    public class CategoryResponseDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Subject { get; set; }
    }
}
