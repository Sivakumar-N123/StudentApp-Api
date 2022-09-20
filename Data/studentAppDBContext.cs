
using Microsoft.EntityFrameworkCore;

using StudentApp.ViewModel;


namespace StudentApp.Data
{
    public class StudentAppDBContext: DbContext
    {
        public StudentAppDBContext(DbContextOptions<StudentAppDBContext>options): base(options)
        {
                
        }
        public DbSet<UserViewModel> UserTable { get; set; }
        public DbSet<SpecificationViewModel> SpecificationTable { get; set; }
        public DbSet<CourseDetailsViewModel> CourseDetailsTable { get; set; }
    }
}
