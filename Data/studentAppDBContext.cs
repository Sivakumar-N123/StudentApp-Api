
using Microsoft.EntityFrameworkCore;

using StudentApp.ViewModel;


namespace StudentApp.Data
{
    public class StudentAppDBContext: DbContext
    {
        internal readonly object Course;
        internal object Courses;

        public StudentAppDBContext(DbContextOptions<StudentAppDBContext>options): base(options)
        {
                
        }
        public DbSet<UserViewModel> UserTable { get; set; }
        public DbSet<SpecificationViewModel> SpecificationTable { get; set; }
        public DbSet<CourseDetailsViewModel> CourseDetailsTable { get; set; }
    }
}
