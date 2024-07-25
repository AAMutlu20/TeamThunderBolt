using HomeworkPlatformAPI.Models.Abstractions;

namespace HomeworkPlatformAPI.Models
{
    public class Assignment : BaseClass
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
