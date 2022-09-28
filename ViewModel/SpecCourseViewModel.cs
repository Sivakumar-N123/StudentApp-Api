using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class SpecCourseViewModel
    {
        [Key]
        public Guid SpecCourseId { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid SpecificationId { get; set; }
        public string SpecificationName { get; set; }

    }
}
