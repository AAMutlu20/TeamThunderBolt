using HomeworkPlatformAPI.Models.Abstractions;

namespace HomeworkPlatformAPI.Models
{
    public class Homework : BaseClass
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
