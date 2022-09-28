using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class SpecCourseViewModel
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public string? CourseName { get; set; }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string SpecificationName { get; set; }

    }
}
