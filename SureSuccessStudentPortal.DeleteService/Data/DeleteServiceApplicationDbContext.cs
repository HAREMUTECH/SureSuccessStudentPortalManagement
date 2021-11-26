using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.DeleteService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.DeleteService.Data
{
    public class DeleteServiceApplicationDbContext : DbContext, IDeleteServiceApplicationDbContext
    {
        public DeleteServiceApplicationDbContext(DbContextOptions<DeleteServiceApplicationDbContext> options)
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
