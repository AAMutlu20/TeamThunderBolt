using HomeworkPlatformAPI.DTOs.Abstractions;
using HomeworkPlatformAPI.Models;

namespace HomeworkPlatformAPI.DTOs.Requests
{
    public class HomeworkRequestDTO : BaseDTO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int AssignmentId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
