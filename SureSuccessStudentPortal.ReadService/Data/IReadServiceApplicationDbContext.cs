using Microsoft.EntityFrameworkCore;
using SureSuccessStudentPortal.ReadService.Entities;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.ReadService.Data
{
    public interface IReadServiceApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChanges();
    }
}
