using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.ViewModel;

namespace StudentApp.Controllers
{
    
    [ApiController]
    [Route("api/specification")]
    public class SpecificationController : ControllerBase
    {
        private readonly StudentAppDBContext _studentAppDBContext;
        public SpecificationController(StudentAppDBContext studentAppDBContext)
        {
            _studentAppDBContext = studentAppDBContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllSpecification()
        {
            var Specification = await _studentAppDBContext.SpecificationTable.ToListAsync();
            return Ok(Specification);
        }

        [HttpPost]

        public async Task<IActionResult> AddCourses([FromBody] SpecificationViewModel specificationRequest)
        {
            specificationRequest.ID = Guid.NewGuid();
            await _studentAppDBContext.SpecificationTable.AddAsync(specificationRequest);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(specificationRequest);
        }
    }
}
