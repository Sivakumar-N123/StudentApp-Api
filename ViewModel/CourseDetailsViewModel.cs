using System.ComponentModel.DataAnnotations;

namespace StudentApp.ViewModel
{
    public class CourseDetailsViewModel
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        
    }
}
