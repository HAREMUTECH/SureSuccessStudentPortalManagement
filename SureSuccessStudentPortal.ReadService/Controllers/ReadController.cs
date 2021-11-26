using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.ReadService.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.ReadService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly IReadServiceApplicationDbContext _context;

        public ReadController(IReadServiceApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Students.ToListAsync();
            if (customers == null) return NotFound();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _context.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}
