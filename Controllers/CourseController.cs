using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
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

        [HttpPost]

        public async Task<IActionResult> AddCourses([FromBody] CourseDetailsViewModel courseRequest)
        {
            courseRequest.CourseId = Guid.NewGuid();
            await _studentAppDBContext.CourseDetailsTable.AddAsync(courseRequest);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(courseRequest);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] Guid id, CourseDetailsViewModel updateCourseRequest)
        {

            var Course = await _studentAppDBContext.CourseDetailsTable.FindAsync(id);

            if (Course == null)
            {
                return NotFound();
            }

            Course.CourseName = updateCourseRequest.CourseName;


            await _studentAppDBContext.SaveChangesAsync();

            return Ok(Course);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid id)
        {
            var course = await _studentAppDBContext.CourseDetailsTable.FindAsync(id);

            if (course == null)
            {
                return NotFound(); 
            }

            _studentAppDBContext.CourseDetailsTable.Remove(course);
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(course);
        } 
    }
}

 