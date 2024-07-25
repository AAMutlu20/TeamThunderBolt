namespace HomeworkPlatformAPI.Models
{
    public class AssignmentCategory
    {
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
