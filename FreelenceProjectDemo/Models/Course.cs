namespace FreelenceProjectDemo.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public int MajorId { get; set; }

        public Major Major { get; set; }

    }
}