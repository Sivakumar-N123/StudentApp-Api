using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentController : Controller
    {
        private readonly StudentAppDBContext _studentAppDBContext;
        public StudentController(StudentAppDBContext studentAppDBContext)
        {
            _studentAppDBContext = studentAppDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentlist()
        {
            var students = await _studentAppDBContext.UserTable.ToListAsync();
            return Ok(students);
        }
    }
}
