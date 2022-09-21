using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.ViewModel;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly StudentAppDBContext _studentAppDBContext;
        public UserController(StudentAppDBContext studentAppDBContext)
        {
            _studentAppDBContext = studentAppDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentlist()
        {
            var students = await _studentAppDBContext.UserTable.ToListAsync();
            return Ok(students);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddNewUser([FromBody] UserViewModel userView)
        //{
        //    userView.Id = Guid.NewGuid();


        //}

    }
}
