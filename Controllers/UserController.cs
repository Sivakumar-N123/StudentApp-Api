using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.ViewModel;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route( "api/[Controller]")]
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
            var students = await _studentAppDBContext.UserTable.Where(e => e.IsActive != false).ToListAsync();

            return Ok(students);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Index([FromRoute] string name)
        {
            var emp = await _studentAppDBContext.UserTable.FirstOrDefaultAsync(e => e.Email == name);
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserViewModel userView )
        {   
      
            await _studentAppDBContext.UserTable.AddAsync(userView);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(userView);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditUser([FromRoute]int id, UserViewModel userView)
        {
            var user = await _studentAppDBContext.UserTable.FindAsync(id); 
            if(user==null)
            {
                return NotFound();
            }

            user.StudentName = userView.StudentName;
            user.Email = userView.Email;
            user.IsStudent = userView.IsStudent;
            user.Password = userView.Password;
            user.IsActive = userView.IsActive;
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id, UserViewModel userView)
        {
            var user = await _studentAppDBContext.UserTable.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.StudentName = userView.StudentName;
            user.Email = userView.Email;
            user.IsStudent = userView.IsStudent;
            user.Password = userView.Password;
            user.IsActive = false;
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{Email}")]
        public async Task<IActionResult> EditUser([FromRoute]string Email, UserViewModel userView)
        {
            var user = await _studentAppDBContext.UserTable.FirstOrDefaultAsync(e => e.Email == Email);
            if (user == null)
            {
                return NotFound();
            }
            user.StudentName = userView.StudentName;
            user.IsStudent = userView.IsStudent;
            user.Password = userView.Password;
            user.IsActive = userView.IsActive;
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(user);
        }

      

    }
}
