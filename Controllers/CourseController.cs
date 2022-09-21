using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models;
using StudentApp.ViewModel;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : Controller
    {
        private readonly StudentAppDBContext _studentAppDBContext;
        public CourseController(StudentAppDBContext studentAppDBContext)
        {
            _studentAppDBContext = studentAppDBContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllCourses()
        {
            var Courses = await _studentAppDBContext.CourseDetailsTable.ToListAsync();
            return Ok(Courses);
        }

        //[HttpPost]

        //public async Task<IActionResult> AddCourses([FromBody] CourseDetailsViewModel courseRequest)
        //{
        //    courseRequest.CourseId = Guid.NewGuid();
        //    await _studentAppDBContext.Courses.AddAsync(courseRequest);
        //    await _studentAppDBContext.SaveChangesAsync();
        //    return Ok(courseRequest);

        //}
    }

  
}

 