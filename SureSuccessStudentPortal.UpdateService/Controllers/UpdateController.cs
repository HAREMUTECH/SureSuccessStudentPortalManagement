using Microsoft.AspNetCore.Mvc;
using SureSuccessStudentPortal.UpdateService.Data;
using SureSuccessStudentPortal.UpdateService.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.UpdateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IUpdateServiceApplicationDbContext _context;

        public UpdateController(IUpdateServiceApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Student student)
        {
            var stutudentData = _context.Students.Where(a => a.Id == id).FirstOrDefault();

            if (stutudentData == null) return NotFound();
            else
            {
                stutudentData.FirstName = student.FirstName;
                stutudentData.LastName = student.LastName;
                stutudentData.Email = student.Email;
                stutudentData.PhoneNo = student.PhoneNo;
                stutudentData.Country = student.Country;
                stutudentData.State = student.State;
                await _context.SaveChanges();
                return Ok(student.Id);
            }
        }
    }
}
