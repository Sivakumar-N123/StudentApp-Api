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
            userView.Id = Guid.NewGuid();
           
            string[] output = userView.UserName.Split(' ');
            string profilestring="";
            foreach (string s in output)
            {
                profilestring = profilestring + s[0];
            }
            //userView.ProfileImage = profilestring;
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
            //user.ProfileImage = Convert.FromBase64String(userView.ProfileImage);
            user.IsStudent = userView.IsStudent;
            user.Password = userView.Password;
            user.IsActive = userView.IsActive;
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id, UserViewModel userView)
        {
            var user = await _studentAppDBContext.UserTable.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = userView.UserName;
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
            user.UserName = userView.UserName;
           
            user.IsStudent = userView.IsStudent;
            user.Password = userView.Password;
            user.IsActive = userView.IsActive;
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(user);
        }

      

    }
}
