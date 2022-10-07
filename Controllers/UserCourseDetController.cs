using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.ViewModel;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseDetController : ControllerBase
    {
        private readonly StudentAppDBContext _studentAppDBContext;
        public UserCourseDetController(StudentAppDBContext studentAppDBContext)
        {
            _studentAppDBContext = studentAppDBContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetUserCourseDet()
        {
            var det = await _studentAppDBContext.CourseDet.ToListAsync();
            return Ok(det);
        }

        [HttpPost]

        public async Task<IActionResult> PutUserCourseDet([FromBody] UserCourseDet getdata)
        {
            getdata.Id = Guid.NewGuid();
            await _studentAppDBContext.CourseDet.AddAsync(getdata);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(getdata);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUserCourseDet([FromRoute] Guid id)
        {
            var deleteDet = await _studentAppDBContext.CourseDet.FindAsync(id);
            if (deleteDet == null)
            {
                return NotFound();
            }

            _studentAppDBContext.CourseDet.Remove(deleteDet);
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(deleteDet);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateSpecCourse([FromRoute] Guid id, UserCourseDet updateUserCourseDet)
        {

            var UpdateCourse = await _studentAppDBContext.CourseDet.FindAsync(id);

            if (UpdateCourse == null)
            {
                return NotFound();
            }

            UpdateCourse.username = updateUserCourseDet.username;
            UpdateCourse.Course = updateUserCourseDet.Course;
            UpdateCourse.Spec = updateUserCourseDet.Spec;



            await _studentAppDBContext.SaveChangesAsync();

            return Ok(UpdateCourse);
        }

    }
}
