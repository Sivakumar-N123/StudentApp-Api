using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.ViewModel;

namespace StudentApp.Controllers
{
    
    [ApiController]
    [Route("api/SpecCourse")]
    public class SpecCourseController : ControllerBase
    {
        private readonly StudentAppDBContext _studentAppDBContext;
        public SpecCourseController(StudentAppDBContext studentAppDBContext)
        {
            _studentAppDBContext = studentAppDBContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllSpecCourse()
        {
            var SpecCourse = await _studentAppDBContext.SpecCourseTable.ToListAsync();
            return Ok(SpecCourse);
        }

        [HttpPost]

        public async Task<IActionResult> AddSpecCourse([FromBody] SpecCourseViewModel specCourseRequest)
        {
            specCourseRequest.SpecCourseId = Guid.NewGuid();
            await _studentAppDBContext.SpecCourseTable.AddAsync(specCourseRequest);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(specCourseRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateSpecCourse([FromRoute] Guid id, SpecCourseViewModel updateSpecCourseRequest)
        {

            var SpecCourse = await _studentAppDBContext.SpecCourseTable.FindAsync(id);

            if (SpecCourse == null)
            {
                return NotFound();
            }
            SpecCourse.CourseId = updateSpecCourseRequest.CourseId;
            SpecCourse.CourseName = updateSpecCourseRequest.CourseName;
            SpecCourse.SpecificationId = updateSpecCourseRequest.SpecificationId;
            SpecCourse.SpecificationName = updateSpecCourseRequest.SpecificationName;
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(SpecCourse);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteSpecCourse([FromRoute] Guid id)
        {
            var specCourse = await _studentAppDBContext.SpecCourseTable.FindAsync(id);
            if (specCourse == null)
            {
                return NotFound();
            }

            _studentAppDBContext.SpecCourseTable.Remove(specCourse);
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(specCourse);
        }
      
    }
}
