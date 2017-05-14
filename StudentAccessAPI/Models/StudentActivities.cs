

namespace StudentAccessAPI.Models
{
    public class StudentActivities
    {
        public int? Id { get; set; }
        public int? ActivityTypeId { get; set; }
        public int? StudentId { get; set; }

        public string Comment { get; set; }
        public string Content { get; set; }
        public string ActionTime { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }

        public bool? IsDone { get; set; }
    }
}
