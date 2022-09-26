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

        public async Task<IActionResult> AddSpecification([FromBody] SpecificationViewModel specificationRequest)
        {
            specificationRequest.ID = Guid.NewGuid();
            await _studentAppDBContext.SpecificationTable.AddAsync(specificationRequest);
            await _studentAppDBContext.SaveChangesAsync();
            return Ok(specificationRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateSpecification([FromRoute] Guid id, SpecificationViewModel updateSpecificationRequest)
        {

            var Specificaton = await _studentAppDBContext.SpecificationTable.FindAsync(id);

            if (Specificaton == null)
           {
              return NotFound();
            }

           Specificaton.SpecificationName = updateSpecificationRequest.SpecificationName;


          await _studentAppDBContext.SaveChangesAsync();

          return Ok(Specificaton);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteSpecificaton([FromRoute] Guid id)
        {
           var specificaton = await _studentAppDBContext.SpecificationTable.FindAsync(id);
           if (specificaton == null)
           {
               return NotFound();
           }

            _studentAppDBContext.SpecificationTable.Remove(specificaton);
            await _studentAppDBContext.SaveChangesAsync();

            return Ok(specificaton);
        }
    }
}

