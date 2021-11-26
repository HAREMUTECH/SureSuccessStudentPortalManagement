using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.ReadService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.ReadService.Data
{
    public class ReadServiceApplicationDbContext : DbContext, IReadServiceApplicationDbContext
    {
        public ReadServiceApplicationDbContext(DbContextOptions<ReadServiceApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
