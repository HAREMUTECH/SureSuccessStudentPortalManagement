using Microsoft.AspNetCore.Mvc;
using SureSuccessStudentPortal.CreateService.Data;
using SureSuccessStudentPortal.CreateService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.CreateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private ICreateServiceApplicationDbContext _context;
        public CreateController(ICreateServiceApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentForCreation studentForCreation)
        {
            var student = new Student()
            {
                FirstName = studentForCreation.FirstName,
                LastName = studentForCreation.LastName,
                Country = studentForCreation.Country,
                Email = studentForCreation.Email,
                PhoneNo = studentForCreation.PhoneNo,
                State = studentForCreation.State
            };
            _context.Students.Add(student);
            await _context.SaveChanges();
            return Ok(student.Id);
        }
    }
}
