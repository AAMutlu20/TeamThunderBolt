using HomeworkPlatformAPI.Models.Abstractions;

namespace HomeworkPlatformAPI.Models
{
    public class Category : BaseClass
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
