using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.DeleteService.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.DeleteService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly IDeleteServiceApplicationDbContext _context;

        public DeleteController(IDeleteServiceApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Students.Remove(customer);
            await _context.SaveChanges();
            return Ok("Successfully Deleted");
        }
    }
}
