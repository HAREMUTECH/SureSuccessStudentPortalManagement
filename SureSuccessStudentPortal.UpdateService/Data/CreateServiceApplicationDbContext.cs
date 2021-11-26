using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.UpdateService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.UpdateService.Data
{
    public class UpdateServiceApplicationDbContext : DbContext, IUpdateServiceApplicationDbContext
    {
        public UpdateServiceApplicationDbContext(DbContextOptions<UpdateServiceApplicationDbContext> options)
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
