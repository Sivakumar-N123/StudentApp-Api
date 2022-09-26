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
            var students = await _studentAppDBContext.UserTable.ToListAsync();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserViewModel userView )
        {
            userView.Id = Guid.NewGuid();
            await _studentAppDBContext.UserTable.AddAsync(userView);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(userView);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditUser([FromRoute]Guid id, UserViewModel userView)
        {
            var user = await _studentAppDBContext.UserTable.FindAsync(id); 
            if(user==null)
            {
                return NotFound();
            }
            user.UserName = userView.UserName;
            user.Email = userView.Email;
            user.IsStudent = userView.IsStudent;
            user.Password = userView.Password;
            user.IsActive = user.IsActive;
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _studentAppDBContext.UserTable.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _studentAppDBContext.UserTable.Remove(user);
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(user);
        }

    }
}
