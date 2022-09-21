using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;

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
        //public async Task<IActionResult> AddCourse[FromBody] Course courseRequest)
        //    {
        //         courseRequest.Id = Guid.NewGuid(); 

        //         _studentAppDBContext.Course.Addsync(courseRequest);
             
        //    }
    }
 }